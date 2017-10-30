using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmMonthCalculate : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BInvoice bInvoice = new BInvoice();
        BExchange bExchange = new BExchange();

        public FrmMonthCalculate()
        {
            InitializeComponent();
        }

        private void FrmMonthCalculate_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 计算
        /// </summary>
        private void btnCal_Click(object sender, EventArgs e)
        {
            //当月的采购数据
            #region
            string where = " BP.SLIP_DATE >='" + txtDateTime.Value.ToString("yyyy/MM/01") + "' AND BP.SLIP_DATE <'" + txtDateTime.Value.AddMonths(1).ToString("yyyy/MM/01") + "' ";
            DataTable purchaseDt = bInvoice.GetPurchaseInfo(where).Tables[0];
            //销售数据的整理，外币的转换
            DataTable pDt = purchaseDt.Clone();
            DataRow pDr = null;
            string currentProductCode = "";
            foreach (DataRow dr in purchaseDt.Rows)
            {
                decimal exchange = 1;
                string currencyCode = CConvert.ToString(dr["CURRENCY_CODE"]);
                if (!CConstant.EXCHANGE_RMB.Equals(currencyCode))
                {
                    exchange = bExchange.GetExchange(CConvert.ToDateTime(txtDateTime.Value.ToString("yyyy/MM/01")), currencyCode, CConstant.EXCHANGE_RMB);
                }

                //总金额=发票金额*汇率+税+包装金额*汇率
                decimal amount = CConvert.ToDecimal(dr["INVOICE_AMOUNT"]) * exchange + CConvert.ToDecimal(dr["TAX_AMOUNT"]) + CConvert.ToDecimal(dr["PACKING_AMOUNT"]) * exchange;

                string productCode = CConvert.ToString(dr["PRODUCT_CODE"]);
                if (currentProductCode != productCode)
                {
                    if (!string.IsNullOrEmpty(currentProductCode))
                    {
                        pDt.Rows.Add(pDr);
                    }
                    currentProductCode = productCode;
                    pDr = pDt.NewRow();
                    pDr["RECEIPT_WAREHOUSE_CODE"] = dr["RECEIPT_WAREHOUSE_CODE"];
                    pDr["PRODUCT_CODE"] = dr["PRODUCT_CODE"];
                    pDr["QUANTITY"] = dr["QUANTITY"];
                    pDr["INVOICE_AMOUNT"] = amount;

                }
                else
                {
                    pDr["INVOICE_AMOUNT"] = CConvert.ToDecimal(pDr["INVOICE_AMOUNT"]) + amount;
                    pDr["QUANTITY"] = CConvert.ToDecimal(pDr["QUANTITY"]) + CConvert.ToDecimal(dr["QUANTITY"]);
                }
            }
            if (pDr != null)
            {
                pDt.Rows.Add(pDr);
            }
            #endregion

            //当月的销售数据
            where = " BS.SLIP_DATE >='" + txtDateTime.Value.ToString("yyyy/MM/01") + "' AND BS.SLIP_DATE <'" + txtDateTime.Value.AddMonths(1).ToString("yyyy/MM/01") + "' ";
            DataTable salesDt = bInvoice.GetSalesInfo(where).Tables[0];

            //上个月的月末数据
            where = " YEAR_MONTH ='" + txtDateTime.Value.AddMonths(-1).ToString("yyyyMM") + "' ";
            DataTable previousMonthStockDt = bInvoice.GetPreviousMonthStockData(where).Tables[0];

            //上个月存在的数据的整理
            #region
            DataTable insertDt = previousMonthStockDt.Clone();
            DataRow insertDr = null;
            foreach (DataRow dr in previousMonthStockDt.Rows)
            {
                insertDr = insertDt.NewRow();
                insertDr["YEAR"] = txtDateTime.Value.ToString("yyyy");
                insertDr["MONTH"] = txtDateTime.Value.ToString("MM");
                insertDr["YEAR_MONTH"] = txtDateTime.Value.ToString("yyyyMM");
                insertDr["WAREHOUSE_CODE"] = dr["WAREHOUSE_CODE"];
                insertDr["PRODUCT_CODE"] = dr["PRODUCT_CODE"];
                insertDr["PREVIOUS_AMOUNT"] = dr["AMOUNT"];
                insertDr["PREVIOUS_QUANTITY"] = dr["STOCK"];
                insertDr["PREVIOUS_PRICE"] = dr["PRICE"];
                foreach (DataRow purchaseDr in purchaseDt.Rows)
                {
                    if (CConvert.ToString(purchaseDr["PRODUCT_CODE"]).Equals(dr["PRODUCT_CODE"]))
                    {
                        insertDr["PURCHASE_QUANTITY"] = purchaseDr["QUANTITY"];
                        insertDr["PURCHASE_AMOUNT"] = purchaseDr["INVOICE_AMOUNT"];
                        purchaseDt.Rows.Remove(purchaseDr);
                        break;
                    }
                }
                foreach (DataRow sDr in salesDt.Rows)
                {
                    if (CConvert.ToString(sDr["PRODUCT_CODE"]).Equals(dr["PRODUCT_CODE"]))
                    {
                        insertDr["SALES_QUANTITY"] = sDr["QUANTITY"];
                        salesDt.Rows.Remove(sDr);
                        break;
                    }
                }
                decimal price = 0;
                try
                {
                    price = (CConvert.ToDecimal(insertDr["PREVIOUS_AMOUNT"]) + CConvert.ToDecimal(insertDr["PURCHASE_AMOUNT"])) / (CConvert.ToDecimal(insertDr["PREVIOUS_QUANTITY"]) + CConvert.ToDecimal(insertDr["PURCHASE_AMOUNT"]));
                }
                catch (Exception ex) { }
                insertDr["PRICE"] = price;
                insertDr["SALES_AMOUNT"] = price * CConvert.ToDecimal(insertDr["SALES_QUANTITY"]);
                insertDr["STOCK"] = CConvert.ToDecimal(insertDr["PREVIOUS_QUANTITY"]) + CConvert.ToDecimal(insertDr["PURCHASE_QUANTITY"]) - CConvert.ToDecimal(insertDr["SALES_QUANTITY"]);
                insertDr["AMOUNT"] = price * CConvert.ToDecimal(insertDr["STOCK"]);
                insertDr["STATUS_FLAG"] = CConstant.INIT_STATUS;
                insertDr["CREATE_USER"] = UserTable.CODE;
                insertDr["LAST_UPDATE_USER"] = UserTable.CODE;
                insertDt.Rows.Add(insertDr);
            }
            #endregion


            //当月采购数据的整理
            #region
            foreach (DataRow purchaseDr in purchaseDt.Rows)
            {
                insertDr = insertDt.NewRow();
                insertDr["YEAR"] = txtDateTime.Value.ToString("yyyy");
                insertDr["MONTH"] = txtDateTime.Value.ToString("MM");
                insertDr["YEAR_MONTH"] = txtDateTime.Value.ToString("yyyyMM");
                insertDr["WAREHOUSE_CODE"] = purchaseDr["RECEIPT_WAREHOUSE_CODE"];
                insertDr["PRODUCT_CODE"] = purchaseDr["PRODUCT_CODE"];
                insertDr["PREVIOUS_AMOUNT"] = 0;
                insertDr["PREVIOUS_QUANTITY"] = 0;
                insertDr["PREVIOUS_PRICE"] = 0;
                insertDr["PURCHASE_QUANTITY"] = purchaseDr["QUANTITY"];
                insertDr["PURCHASE_AMOUNT"] = purchaseDr["INVOICE_AMOUNT"];
                foreach (DataRow sDr in salesDt.Rows)
                {
                    if (CConvert.ToString(sDr["PRODUCT_CODE"]).Equals(purchaseDr["PRODUCT_CODE"]))
                    {
                        insertDr["SALES_QUANTITY"] = sDr["QUANTITY"];
                        salesDt.Rows.Remove(sDr);
                        break;
                    }
                }
                decimal price = 0;
                try
                {
                    price = (CConvert.ToDecimal(insertDr["PREVIOUS_AMOUNT"]) + CConvert.ToDecimal(insertDr["PURCHASE_AMOUNT"])) / (CConvert.ToDecimal(insertDr["PREVIOUS_QUANTITY"]) + CConvert.ToDecimal(insertDr["PURCHASE_AMOUNT"]));
                }
                catch (Exception ex) { }
                insertDr["PRICE"] = price;
                insertDr["SALES_AMOUNT"] = price * CConvert.ToDecimal(insertDr["SALES_QUANTITY"]);
                insertDr["STOCK"] = CConvert.ToDecimal(insertDr["PREVIOUS_QUANTITY"]) + CConvert.ToDecimal(insertDr["PURCHASE_QUANTITY"]) - CConvert.ToDecimal(insertDr["SALES_QUANTITY"]);
                insertDr["AMOUNT"] = price * CConvert.ToDecimal(insertDr["STOCK"]);
                insertDr["STATUS_FLAG"] = CConstant.INIT_STATUS;
                insertDr["CREATE_USER"] = UserTable.CODE;
                insertDr["LAST_UPDATE_USER"] = UserTable.CODE;
                insertDt.Rows.Add(insertDr);
            }
            #endregion

            try
            {
                if (bInvoice.AddMonthlyStock(insertDt) > 0)
                {
                    MessageBox.Show("计算完成！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("计算失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("计算失败，请重试或与系统管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("月末计算：", ex);
            }

        }


    }//end class
}
