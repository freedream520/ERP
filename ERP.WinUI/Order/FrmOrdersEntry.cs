using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.CacheData;
using System.Collections;
using CZZD.ERP.Common;
using System.IO;
using System.Text.RegularExpressions;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOrdersEntry : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _operateMode = CConstant.ORDER_NEW;
        private string _oldSlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
        private int attachedNumber = 0;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrdersEntry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrdersEntry(string slipNumber)
        {
            InitializeComponent();
            _oldSlipNumber = slipNumber;
        }
        #endregion

        #region init  页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOrdersEntry_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region 订单类型的初始化
            //订单类型的初始化            
            cboSlipType.ValueMember = "CODE";
            cboSlipType.DisplayMember = "NAME";
            cboSlipType.DataSource = CCacheData.OrderSlipType;
            #endregion

            #region 税率的初始化
            //税率的初始化  
            DataTable dtTaxation = CCacheData.Taxation.Copy();
            dtTaxation.Columns.Add("DISP_TAX_RATE", Type.GetType("System.String"));
            foreach (DataRow row in dtTaxation.Rows)
            {
                row["DISP_TAX_RATE"] = CConvert.ToString(row["TAX_RATE"]) + "%";
            }
            cboTax.ValueMember = "CODE";
            cboTax.DisplayMember = "DISP_TAX_RATE";
            cboTax.DataSource = dtTaxation;
            #endregion

            #region 通货的初始化
            //通货的初始化
            cboCurrency.ValueMember = "CODE";
            cboCurrency.DisplayMember = "NAME";
            cboCurrency.DataSource = CCacheData.Currency;
            #endregion

            init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void init()
        {
            //订单输入 
            if (CConstant.ORDER_NEW.Equals(CTag))
            {
                this.Text = "订单输入";
                
                setStatus(true);
                initSlipNumber();
                this.btnOrderDelete.Visible = false;
                //this.btnExport.Location = new Point(btnExport.Location.X + 95, btnExport.Location.Y);
                this.btnAttached.Location = new Point(btnAttached.Location.X + 95, btnAttached.Location.Y);
            }
            //历史记录
            if (CConstant.ORDER_HISTORY.Equals(CTag))
            {
                this.Text = "历史记录";
                
                setStatus(false);
                initHistoryData();
                this.btnAttached.Visible = false;
                this.btnSave.Visible = false;
                this.btnOrderDelete.Visible = false;
            }
            //订单修正    
            else if (CConstant.ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "订单修正";
                
                setStatus(true);
                initData();
                this.cboSlipType.Enabled = false;
            }
            //订单承认        
            else if (CConstant.ORDER_VERIFY.Equals(CTag))
            {
                this.Text = "订单承认";
                
                setStatus(false);
                initData();
                this.btnAttached.Visible = false;
                this.btnOrderDelete.Text = "不承认";
                this.btnSave.Text = "承认";
            }
            //复制订单     
            else if (CConstant.ORDER_COPY.Equals(CTag))
            {
                this.Text = "复制订单";
                initSlipNumber();
                
                setStatus(true);
                initData();
            }
            else if (CConstant.ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "订单详细";
                
                setStatus(false);
                initData();
                this.btnAttached.Visible = false;
                this.btnOrderDelete.Visible = false;
                this.btnSave.Visible = false;
            }
        }

        private void initHistoryData()
        {
            BllHistoryOrderHeaderTable headerTable = bOrderHeader.GetHistoryModel(_oldSlipNumber);
            this.cboSlipType.SelectedValue = headerTable.SLIP_TYPE;
            this.txtSlipNumber.Text = headerTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = headerTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = headerTable.CUSTOMER_NAME;
            this.txtEndCustomerCode.Text = headerTable.ENDER_CUSTOMER_CODE;
            this.txtEndCustomerName.Text = headerTable.ENDER_CUSTOMER_NAME;
            this.txtDeliveryPointCode.Text = headerTable.DELIVERY_POINT_CODE;
            this.txtDeliveryPointName.Text = headerTable.DELIVERY_POINT_NAME;
            this.txtOwnerPoNumber.Text = headerTable.OWNER_PO_NUMBER;
            this.txtSlipDate.Text = string.Format("{0:d}", headerTable.SLIP_DATE);
            this.txtDepartualDate.Text = string.Format("{0:d}", headerTable.DEPARTUAL_DATE);
            this.txtWarehouseCode.Text = headerTable.DEPARTUAL_WAREHOUSE_CODE;
            this.txtWarehouseName.Text = headerTable.DEPARTUAL_WAREHOUSE_NAME;
            foreach (DataRow dr in CCacheData.Taxation.Rows)
            {
                if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(headerTable.TAX_RATE) * 100)
                {
                    this.cboTax.SelectedValue = dr["CODE"];
                    break;
                }
            }

            this.cboCurrency.SelectedValue = headerTable.CURRENCY_CODE;
            this.txtOwnerPoNumber.Text = headerTable.OWNER_PO_NUMBER;
            this.txtCustomerPoNumber.Text = headerTable.CUSTOMER_PO_NUMBER;
            this.txtSerialNumber.Text = headerTable.SERIAL_NUMBER;
            this.txtOrderDeposit.Text = CConvert.ToString(headerTable.ORDER_DEPOSIT);
            this.txtShipmentDeposit.Text = CConvert.ToString(headerTable.SHIPMENT_DEPOSIT);
            this.txtMemo.Text = headerTable.MEMO;

            this.txtAmountIncludedTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_INCLUDED_TAX);
            this.txtAmountWithoutTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_WITHOUT_TAX);
            this.txtTaxAmount.Text = string.Format("{0:N2}", headerTable.TAX_AMOUNT);
            attachedNumber = CConvert.ToInt32(headerTable.ATTACHED_FLAG);
            this.txtCheckNumber.Text = headerTable.CHECK_NUMBER;
            this.txtCheckDate.Value = CConvert.ToDateTime(headerTable.CHECK_DATE);
            this.txtQuotesNumber.Text = headerTable.QUOTES_NUMBER;
            this.txtShippedDeposit.Text = CConvert.ToString(headerTable.SHIPPED_DEPOSIT);
            this.txtSerialType.Text = headerTable.SERIAL_TYPE;

            if (headerTable.ORDER_DEPOSIT_DATE != null)
            {
                txtOrderDepositDate.Checked = true;
                txtOrderDepositDate.Value = CConvert.ToDateTime(headerTable.ORDER_DEPOSIT_DATE);
            }

            if (headerTable.SHIPMENT_DEPOSIT_DATE != null)
            {
                txtShipmentDepositDate.Checked = true;
                txtShipmentDepositDate.Value = CConvert.ToDateTime(headerTable.SHIPMENT_DEPOSIT_DATE);
            }

            if (headerTable.SHIPPED_DEPOSIT_DATE != null)
            {
                txtShippedDepositDate.Checked = true;
                txtShippedDepositDate.Value = CConvert.ToDateTime(headerTable.SHIPPED_DEPOSIT_DATE);
            }

            foreach (BllHistoryOrderLineTable lineModel in headerTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                dgvr.Cells["No"].Value = lineModel.LINE_NUMBER;
                dgvr.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                dgvr.Cells["OLD_CODE"].Value = lineModel.PRODUCT_CODE;
                dgvr.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                dgvr.Cells["MODEL_NUMBER"].Value = lineModel.PRODUCT_SPEC;
                dgvr.Cells["QUANTITY"].Value = lineModel.QUANTITY;
                dgvr.Cells["UNIT_CODE"].Value = lineModel.UNIT_CODE;
                dgvr.Cells["UNIT_NAME"].Value = lineModel.UNIT_NAME;
                dgvr.Cells["PRICE"].Value = lineModel.PRICE;
                dgvr.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                dgvr.Cells["MEMO"].Value = lineModel.MEMO;
            }
        }

        /// <summary>
        /// 订单数据初始化
        /// </summary>
        private void initData()
        {
            BllOrderHeaderTable headerTable = bOrderHeader.GetModel(_oldSlipNumber);
            this.cboSlipType.SelectedValue = headerTable.SLIP_TYPE;
            this.txtSlipNumber.Text = headerTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = headerTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = headerTable.CUSTOMER_NAME;
            this.txtEndCustomerCode.Text = headerTable.ENDER_CUSTOMER_CODE;
            this.txtEndCustomerName.Text = headerTable.ENDER_CUSTOMER_NAME;
            this.txtDeliveryPointCode.Text = headerTable.DELIVERY_POINT_CODE;
            this.txtDeliveryPointName.Text = headerTable.DELIVERY_POINT_NAME;
            this.txtOwnerPoNumber.Text = headerTable.OWNER_PO_NUMBER;
            this.txtSlipDate.Text = string.Format("{0:d}", headerTable.SLIP_DATE);
            this.txtDepartualDate.Text = string.Format("{0:d}", headerTable.DEPARTUAL_DATE);
            this.txtWarehouseCode.Text = headerTable.DEPARTUAL_WAREHOUSE_CODE;
            this.txtWarehouseName.Text = headerTable.DEPARTUAL_WAREHOUSE_NAME;
            //this.cboTax.Text = Math.Round(CConvert.ToDouble(headerTable.TAX_RATE)*100.001,2)+"%";
            foreach (DataRow dr in CCacheData.Taxation.Rows)
            {
                if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(headerTable.TAX_RATE) * 100)
                {
                    this.cboTax.SelectedValue = dr["CODE"];
                    break;
                }
            }

            this.cboCurrency.SelectedValue = headerTable.CURRENCY_CODE;
            this.txtOwnerPoNumber.Text = headerTable.OWNER_PO_NUMBER;
            this.txtCustomerPoNumber.Text = headerTable.CUSTOMER_PO_NUMBER;
            this.txtSerialNumber.Text = headerTable.SERIAL_NUMBER;
            this.txtOrderDeposit.Text = CConvert.ToString(headerTable.ORDER_DEPOSIT);
            this.txtShipmentDeposit.Text = CConvert.ToString(headerTable.SHIPMENT_DEPOSIT);
            this.txtMemo.Text = headerTable.MEMO;
            this.txtSerialType.Text = headerTable.SERIAL_TYPE;

            this.txtAmountIncludedTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_INCLUDED_TAX);
            this.txtAmountWithoutTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_WITHOUT_TAX);
            this.txtTaxAmount.Text = string.Format("{0:N2}", headerTable.TAX_AMOUNT);
            attachedNumber = CConvert.ToInt32(headerTable.ATTACHED_FLAG);
            this.txtCheckNumber.Text = headerTable.CHECK_NUMBER;
            this.txtCheckDate.Value = CConvert.ToDateTime(headerTable.CHECK_DATE);
            this.txtQuotesNumber.Text = headerTable.QUOTES_NUMBER;
            this.txtDiscount.Text = CConvert.ToString(headerTable.DISCOUNT);
            this.txtShippedDeposit.Text = CConvert.ToString(headerTable.SHIPPED_DEPOSIT);

            if (headerTable.ORDER_DEPOSIT_DATE != null)
            {
                txtOrderDepositDate.Checked = true;
                txtOrderDepositDate.Value = CConvert.ToDateTime(headerTable.ORDER_DEPOSIT_DATE);
            }

            if (headerTable.SHIPMENT_DEPOSIT_DATE != null)
            {
                txtShipmentDepositDate.Checked = true;
                txtShipmentDepositDate.Value = CConvert.ToDateTime(headerTable.SHIPMENT_DEPOSIT_DATE);
            }

            if (headerTable.SHIPPED_DEPOSIT_DATE != null)
            {
                txtShippedDepositDate.Checked = true;
                txtShippedDepositDate.Value = CConvert.ToDateTime(headerTable.SHIPPED_DEPOSIT_DATE);
            }

            foreach (BllOrderLineTable lineModel in headerTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                dgvr.Cells["No"].Value = lineModel.LINE_NUMBER;
                dgvr.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                dgvr.Cells["OLD_CODE"].Value = lineModel.PRODUCT_CODE;
                dgvr.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                dgvr.Cells["MODEL_NUMBER"].Value = lineModel.PRODUCT_SPEC;
                dgvr.Cells["QUANTITY"].Value = lineModel.QUANTITY;
                dgvr.Cells["UNIT_CODE"].Value = lineModel.UNIT_CODE;
                dgvr.Cells["UNIT_NAME"].Value = lineModel.UNIT_NAME;
                dgvr.Cells["PRICE"].Value = lineModel.PRICE;
                dgvr.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                dgvr.Cells["MEMO"].Value = lineModel.MEMO;
                BaseProductTable productTable = bProduct.GetModel(lineModel.PRODUCT_CODE);
                if (productTable != null)
                {
                    dgvr.Cells["SALES_PRICE"].Value = productTable.SALES_PRICE;
                    dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                }
                if (lineModel.PRODUCT_CODE.Substring(0,4) == "9999")
                {
                    dgvr.Cells["NAME"].ReadOnly = false;
                    dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                }
                else
                {
                    dgvr.Cells["NAME"].ReadOnly = true;
                    dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 页面控件初始化
        /// </summary>
        /// <param name="flag"></param>
        private void setStatus(bool flag)
        {
            this.cboSlipType.Enabled = flag;
            this.txtCustomerCode.Enabled = flag;
            this.txtEndCustomerCode.Enabled = flag;
            this.txtDeliveryPointCode.Enabled = flag;
            this.txtOwnerPoNumber.Enabled = flag;
            this.txtSlipDate.Enabled = flag;
            this.txtDepartualDate.Enabled = flag;
            this.txtWarehouseCode.Enabled = flag;
            this.cboTax.Enabled = flag;
            this.cboCurrency.Enabled = flag;
            this.txtOwnerPoNumber.Enabled = flag;
            this.txtCustomerPoNumber.Enabled = flag;
            this.txtSerialNumber.Enabled = flag;
            this.txtOrderDeposit.Enabled = flag;
            this.txtShipmentDeposit.Enabled = flag;
            this.txtMemo.Enabled = flag;
            this.btnCustomer.Enabled = flag;
            this.btnEndCustomer.Enabled = flag;
            this.btnDeliveryPoint.Enabled = flag;
            this.btnWarehouse.Enabled = flag;
            this.txtCheckNumber.Enabled = flag;
            this.txtCheckDate.Enabled = flag;
            this.btnAppendant.Enabled = flag;
            this.btnAddRow.Enabled = flag;
            this.btnDeleteRow.Enabled = flag;
            this.dgvData.ReadOnly = !flag;
            this.txtOrderDeposit.Enabled = flag;
            this.txtShipmentDeposit.Enabled = flag;
            this.txtOrderDepositDate.Enabled = flag;
            this.txtShipmentDepositDate.Enabled = flag;
            this.txtQuotesNumber.Enabled = flag;
            this.txtShippedDeposit.Enabled = flag;
            this.txtShippedDepositDate.Enabled = flag;
            this.txtSerialType.Enabled = flag;

            if (!flag)
            {
                foreach (DataGridViewColumn dgvc in dgvData.Columns)
                {
                    dgvc.ReadOnly = true;
                }

                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            dgvData.Columns[2].Visible = flag;

        }

        #region 订单编号的初始化
        /// <summary>
        /// 订单编号的初始化
        /// </summary>
        public void initSlipNumber()
        {
            //订单编号的初始化
            string maxSlipNumber = bOrderHeader.GetMaxSlipNumber(UserTable.COMPANY_CODE, CConvert.ToString(cboSlipType.SelectedValue));
            int number = CConvert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = UserTable.COMPANY_CODE + "-" + CConvert.ToString(cboSlipType.SelectedValue) + "-" + CConvert.ToString(number).PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }
        #endregion


        #endregion

        #region 重绘datagridview表头
        /// <summary>
        /// 重绘datagridview表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex == -1 && (e.ColumnIndex == 1))
            {
                CellPainting(dgv, 2, "商品编号", e);

                e.Handled = true;
            }

            if (e.RowIndex != -1 && (e.ColumnIndex == 1))
            {
                DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
                Color color = System.Drawing.SystemColors.Info;
                dgvr.Cells["CODE"].Style.BackColor = color;
                dgvr.Cells["QUANTITY"].Style.BackColor = color;
                dgvr.Cells["PRICE"].Style.BackColor = color;
                dgvr.Cells["MEMO"].Style.BackColor = color;
            }

        }
        #endregion

        #region DataGridView 行点击事件
        /// <summary>
        /// 行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BtnProduct"].Index)
                {
                    FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frm.BaseMasterTable != null)
                        {
                            DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                            string code = frm.BaseMasterTable.Code;
                            BaseProductTable productTable = null;
                            if (code == "9999")
                            {
                                dgvr.Cells["NAME"].ReadOnly = false;
                                dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                                productTable = bProduct.GetModel(code.Substring(0, 4));
                            }
                            else
                            {
                                dgvr.Cells["NAME"].ReadOnly = true;
                                dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                                productTable = bProduct.GetModel(code);
                            }
                            if (productTable != null)
                            {
                                if (!productTable.CODE.Equals(dgvr.Cells["OLD_CODE"].Value)) //商品编号未变换
                                {
                                    dgvr.Cells["CODE"].Value = productTable.CODE;
                                    dgvr.Cells["OLD_CODE"].Value = productTable.CODE;
                                    dgvr.Cells["NAME"].Value = productTable.NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                    dgvr.Cells["QUANTITY"].Value = 1;
                                    dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                    dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                    dgvr.Cells["SALES_PRICE"].Value = productTable.SALES_PRICE;
                                    dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                                    if (string.IsNullOrEmpty(txtCustomerCode.Text))
                                    {
                                        dgvr.Cells["PRICE"].Value = productTable.SALES_PRICE;
                                    }
                                    else
                                    {
                                        dgvr.Cells["PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                                    }

                                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                                    CalculateAmount();
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvr.Cells["CODE"].Value = "";
                                dgvr.Cells["OLD_CODE"].Value = "";
                                dgvr.Cells["NAME"].Value = "";
                                dgvr.Cells["MODEL_NUMBER"].Value = "";
                                dgvr.Cells["QUANTITY"].Value = "0";
                                dgvr.Cells["UNIT_NAME"].Value = "";
                                dgvr.Cells["UNIT_CODE"].Value = "";
                                dgvr.Cells["SALES_PRICE"].Value = "0";
                                dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = "0";
                                dgvr.Cells["PRICE"].Value = "0";
                                dgvr.Cells["AMOUNT"].Value = "0";
                                dgvr.Cells["CODE"].Selected = true;
                                CalculateAmount();
                            }
                        }
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region DataGridView 行添加
        /// <summary>
        ///  DataGridView 行添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if ("".Equals(CConvert.ToString(dr.Cells["CODE"].Value).Trim()))
                {
                    dr.Cells["CODE"].Selected = true;
                    return;
                }
            }
            int currentRowIndex = dgvData.Rows.Add(1);
            DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
            dgvr.Cells[1].Selected = true;
            dgvr.Cells["NAME"].ReadOnly = true;
            dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
            dgvr.Cells["QUANTITY"].Value = "0";
            dgvr.Cells["PRICE"].Value = "0";
            dgvr.Cells["AMOUNT"].Value = "0";
        }

        /// <summary>
        /// DataGridView 行添加No的顺序的初始写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
        }
        #endregion

        #region DataGridView 行删除
        /// <summary>
        /// DataGridView 行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    dgvData.Rows.Remove(dgvData.CurrentRow);
                    reSetNo();
                    CalculateAmount();
                }
            }
        }

        /// <summary>
        /// DataGridView 行NUMBER的重新排序
        /// </summary>
        private void reSetNo()
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                dr.Cells["No"].Value = dr.Index + 1;
            }
        }
        #endregion

        #region DataGridView 验证
        /// <summary>
        /// 列编辑完成后的验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["CODE"].Index)
                {
                    string code = CConvert.ToString(dgvr.Cells["CODE"].Value).Trim();
                    if (code != "")
                    {
                        #region 商品
                        BaseProductTable productTable = null;
                        if (code.Length >= 4 && code.Substring(0, 4) == "9999")
                        {
                            dgvr.Cells["NAME"].ReadOnly = false;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                            productTable = bProduct.GetModel(code.Substring(0, 4));
                        }
                        else
                        {
                            dgvr.Cells["NAME"].ReadOnly = true;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                            productTable = bProduct.GetModel(code);
                        }
                        if (productTable != null)
                        {
                            if (!code.Equals(dgvr.Cells["OLD_CODE"].Value))
                            {
                                
                                dgvr.Cells["CODE"].Value = code;
                                dgvr.Cells["OLD_CODE"].Value = code;
                                dgvr.Cells["NAME"].Value = productTable.NAME;
                                dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                if (CConvert.ToInt32(dgvr.Cells["QUANTITY"].Value) == 0)
                                {
                                    dgvr.Cells["QUANTITY"].Value = 1;
                                }
                                dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dgvr.Cells["SALES_PRICE"].Value = productTable.SALES_PRICE;
                                dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                                if (string.IsNullOrEmpty(txtCustomerCode.Text))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.SALES_PRICE;
                                }
                                else
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                                }

                                dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                                

                                CalculateAmount();
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvr.Cells["CODE"].Value = "";
                            dgvr.Cells["OLD_CODE"].Value = "";
                            dgvr.Cells["NAME"].Value = "";
                            dgvr.Cells["MODEL_NUMBER"].Value = "";
                            dgvr.Cells["QUANTITY"].Value = "0";
                            dgvr.Cells["UNIT_CODE"].Value = "";
                            dgvr.Cells["UNIT_NAME"].Value = "";
                            dgvr.Cells["SALES_PRICE"].Value = "0";
                            dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = "0";
                            dgvr.Cells["PRICE"].Value = "0";
                            dgvr.Cells["AMOUNT"].Value = "0";
                            dgvr.Cells["CODE"].Selected = true; ;
                            CalculateAmount();
                        }
                        #endregion 
                    }
                    else
                    {
                        dgvr.Cells["CODE"].Value = "";
                        dgvr.Cells["OLD_CODE"].Value = "";
                        dgvr.Cells["NAME"].Value = "";
                        dgvr.Cells["MODEL_NUMBER"].Value = "";
                        dgvr.Cells["QUANTITY"].Value = "0";
                        dgvr.Cells["UNIT_CODE"].Value = "";
                        dgvr.Cells["UNIT_NAME"].Value = "";
                        dgvr.Cells["SALES_PRICE"].Value = "0";
                        dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = "0";
                        dgvr.Cells["PRICE"].Value = "0";
                        dgvr.Cells["AMOUNT"].Value = "0";
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["QUANTITY"].Index)
                {
                    string quantity = CConvert.ToString(dgvr.Cells["QUANTITY"].Value);

                    if (quantity == "")
                    {
                        dgvr.Cells["QUANTITY"].Value = 0;
                    }
                    else
                    {
                        dgvr.Cells["QUANTITY"].Value = CConvert.ToDecimal(quantity);
                    }
                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(quantity) * CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                    CalculateAmount();
                }
                else if (e.ColumnIndex == dgvData.Columns["PRICE"].Index)
                {
                    string price = CConvert.ToString(dgvr.Cells["PRICE"].Value);

                    if (price == "")
                    {
                        dgvr.Cells["PRICE"].Value = 0;
                    }
                    else
                    {
                        dgvr.Cells["PRICE"].Value = CConvert.ToDecimal(price);
                    }
                    //if (string.IsNullOrEmpty(txtCustomerCode.Text))
                    //{
                    //    dgvr.Cells["SALES_PRICE"].Value = price;
                    //}
                    //else
                    //{
                    //    dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = price;
                    //}

                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(price) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                    CalculateAmount();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CellValidated error!", ex);
            }
        }

        /// <summary>
        /// 行编辑完成后的验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region 总金额计算
        /// <summary>
        /// 总金额计算
        /// </summary>
        private void CalculateAmount()
        {
            decimal IncludedTaxAmount = 0;
            decimal WithoutTaxAmount = 0;
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                IncludedTaxAmount += CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
            }

            decimal taxation = CConvert.ToDecimal(cboTax.Text.Replace("%", ""));
            WithoutTaxAmount = WithoutAmount(IncludedTaxAmount, taxation / 100);

            txtAmountIncludedTax.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount, 2));

            txtAmountWithoutTax.Text = string.Format("{0:N2}", Math.Round(WithoutTaxAmount, 2));
            txtTaxAmount.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount - WithoutTaxAmount, 2));
        }
        #endregion

        #region 税率的选择变更
        /// <summary>
        /// 税率的选择变更
        /// </summary>
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }
        #endregion

        #region 出库仓库
        /// <summary>
        /// 仓库选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 仓库输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouseCode.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouseCode.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("出库仓库不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouseCode.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }

        }
        #endregion

        #region 代理店
        /// <summary>
        /// 代理店选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "TYPE = 1");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    if (!frm.BaseMasterTable.Code.Equals(txtCustomerCode.Tag))
                    {
                        txtCustomerCode.Tag = frm.BaseMasterTable.Code;
                        ReSetPrice();
                    }

                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 代理店输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            string _tag = "";
            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode, "TYPE = 1");
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                    _tag = baseMaster.Code;
                }
                else
                {
                    MessageBox.Show("代理店不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                    _tag = "";
                }
            }
            else
            {
                txtCustomerName.Text = "";
                _tag = "";
            }

            if (!_tag.Equals(txtCustomerCode.Tag))
            {
                txtCustomerCode.Tag = _tag;
                ReSetPrice();
            }
        }
        #endregion

        #region 需要家
        /// <summary>
        /// 需要家选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "TYPE = 2");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtEndCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtEndCustomerName.Text = frm.BaseMasterTable.Name;
                    DataSet ds = bOrderHeader.GetDelivery(txtEndCustomerCode.Text);
                    if (ds.Tables[0] != null)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtDeliveryPointCode.Text = CConvert.ToString(row["DELIVERY_CODE"]);
                            txtDeliveryPointName.Text = CConvert.ToString(row["ADDRESS_FIRST"]);
                        }
                    }
                    txtDeliveryPointCode.Focus();
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 需要家输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndCustomerCode_Leave(object sender, EventArgs e)
        {

            string endCustomerCode = txtEndCustomerCode.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode, "TYPE = 2");
                if (baseMaster != null)
                {

                    txtEndCustomerCode.Text = baseMaster.Code;
                    txtEndCustomerName.Text = baseMaster.Name;


                }
                else
                {
                    MessageBox.Show("需要家不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEndCustomerCode.Text = "";
                    txtEndCustomerName.Text = "";
                    txtEndCustomerCode.Focus();
                }
            }
            else
            {
                txtEndCustomerName.Text = "";
            }
        }
        #endregion

        #region 纳入先
        /// <summary>
        ///  纳入先选择按钮事件
        /// </summary>
        private void btnDeliveryPoint_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DELIVERY", "", txtEndCustomerCode.Text);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDeliveryPointCode.Text = frm.BaseMasterTable.Code;
                    txtDeliveryPointName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 纳入先输入验证
        /// </summary>
        private void txtDeliveryPointCode_Leave(object sender, EventArgs e)
        {
            string deliveryPointCode = txtDeliveryPointCode.Text.Trim();
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text))
            {
                strWhere = "CUSTOMER_CODE = '" + txtEndCustomerCode.Text + "'";
            }
            if (deliveryPointCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DELIVERY", deliveryPointCode, strWhere);
                if (baseMaster != null)
                {
                    txtDeliveryPointCode.Text = baseMaster.Code;
                    txtDeliveryPointName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("纳入先不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryPointCode.Text = "";
                    txtDeliveryPointName.Text = "";
                    txtDeliveryPointCode.Focus();
                }
            }
            else
            {
                txtDeliveryPointName.Text = "";
            }
        }
        #endregion

        #region 附属品的选择
        /// <summary>
        /// 附属品的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppendant_Click(object sender, EventArgs e)
        {
            FrmAppendant frm = new FrmAppendant();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                foreach (ListItem li in frm.resultData)
                {
                    string code = li.Value;
                    decimal quantity = li.Quantity;
                    BaseProductTable productTable = bProduct.GetModel(code);
                    if (productTable != null)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        dgvr.Cells["CODE"].Value = productTable.CODE;
                        dgvr.Cells["OLD_CODE"].Value = productTable.CODE;
                        dgvr.Cells["NAME"].Value = productTable.NAME;
                        dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                        dgvr.Cells["QUANTITY"].Value = quantity;
                        dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                        dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                        dgvr.Cells["SALES_PRICE"].Value = productTable.SALES_PRICE;
                        dgvr.Cells["CUSTOMER_SALES_PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                        if (string.IsNullOrEmpty(txtCustomerCode.Text))
                        {
                            dgvr.Cells["PRICE"].Value = productTable.SALES_PRICE;
                        }
                        else
                        {
                            dgvr.Cells["PRICE"].Value = productTable.CUSTOMER_SALES_PRICE;
                        }

                        dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    }
                }
                CalculateAmount();
            }

            frm.Dispose();

        }
        #endregion

        #region 数据保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckHeaderInput())
            {
                return;
            }

            if (!CheckLineInput())
            {
                return;
            }

            BllOrderHeaderTable OHTable = new BllOrderHeaderTable();
            BllOrderLineTable OLTable = null;
            //订单类型
            OHTable.SLIP_TYPE = CConvert.ToString(cboSlipType.SelectedValue);
            //订单编号
            OHTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
            //代理店
            if (!"".Equals(txtCustomerCode.Text.Trim()))
            {
                OHTable.CUSTOMER_CODE = txtCustomerCode.Text.Trim();
            }
            //需要家
            OHTable.ENDER_CUSTOMER_CODE = txtEndCustomerCode.Text.Trim();
            //纳入先
            OHTable.DELIVERY_POINT_CODE = txtDeliveryPointCode.Text.Trim();
            //出库仓库
            OHTable.DEPARTUAL_WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
            //机器编号
            OHTable.SERIAL_NUMBER = txtSerialNumber.Text.Trim();
            //出库预定日
            OHTable.DEPARTUAL_DATE = txtDepartualDate.Value;
            //订单日期
            OHTable.SLIP_DATE = txtSlipDate.Value;
            //纳期
            OHTable.DUE_DATE = OHTable.DEPARTUAL_DATE;
            //本社订单编号
            OHTable.OWNER_PO_NUMBER = txtOwnerPoNumber.Text.Trim();
            //合同编号
            OHTable.CUSTOMER_PO_NUMBER = txtCustomerPoNumber.Text.Trim();
            //通货
            OHTable.CURRENCY_CODE = CConvert.ToString(cboCurrency.SelectedValue);
            //下单时的预付款
            OHTable.ORDER_DEPOSIT = CConvert.ToDecimal(txtOrderDeposit.Text.Trim());
            //下单时的预付款时间
            if (txtOrderDepositDate.Checked)
            {
                OHTable.ORDER_DEPOSIT_DATE = txtOrderDepositDate.Value;
            }
            //出库时的预付款
            OHTable.SHIPMENT_DEPOSIT = CConvert.ToDecimal(txtShipmentDeposit.Text.Trim());
            //出库时的预付款时间
            if (txtShipmentDepositDate.Checked)
            {
                OHTable.SHIPMENT_DEPOSIT_DATE = txtShipmentDepositDate.Value;
            }
            //备注
            OHTable.MEMO = txtMemo.Text.Trim();
            //状态 OR 出荷状况
            OHTable.STATUS_FLAG = CConstant.UN_SHIPMENT;
            //含税金额
            OHTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(txtAmountIncludedTax.Text.Trim());
            //税金
            OHTable.TAX_AMOUNT = CConvert.ToDecimal(txtTaxAmount.Text.Trim());
            //税后金额
            OHTable.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(txtAmountWithoutTax.Text.Trim());
            //销售人员
            OHTable.SALES_EMPLOYEE_CODE = UserTable.CODE;
            //创建人           
            OHTable.CREATE_USER = UserTable.CODE;
            //最后更新人
            OHTable.LAST_UPDATE_USER = UserTable.CODE;
            //公司编号
            OHTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            //承认状态
            OHTable.VERIFY_FLAG = CConstant.VERIFY;
            //税率
            OHTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
            //引当区分
            OHTable.ALLOATION_FLAG = CConstant.ALLOATION_UN;
            //更新回数
            OHTable.UPDATED_COUNT = 0;
            //添付资料
            if (attachedNumber > 0)
            {
                OHTable.ATTACHED_FLAG = CConstant.EXIST_ATTACHED;
            }
            else
            {
                OHTable.ATTACHED_FLAG = CConstant.NO_ATTACHED;
            }
            //检查编号
            OHTable.CHECK_NUMBER = txtCheckNumber.Text;
            //检查时间
            if (txtCheckDate.Checked)
            {
                OHTable.CHECK_DATE = txtCheckDate.Value;
            }
            OHTable.QUOTES_NUMBER = txtQuotesNumber.Text;
            OHTable.DISCOUNT = CConvert.ToDecimal(txtDiscount.Text);
            //出库回收款
            OHTable.SHIPPED_DEPOSIT = CConvert.ToDecimal(txtShippedDeposit.Text);
            //出库回收款时间
            if (txtShippedDepositDate.Checked)
            {
                OHTable.SHIPPED_DEPOSIT_DATE = txtShippedDepositDate.Value;
            }
            //机种
            OHTable.SERIAL_TYPE = txtSerialType.Text.Trim();

            //明细的整理
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                OLTable = new BllOrderLineTable();
                OLTable.SLIP_NUMBER = OHTable.SLIP_NUMBER;
                //明细编号
                OLTable.LINE_NUMBER = dgvr.Index + 1;
                //商品编号
                OLTable.PRODUCT_CODE = CConvert.ToString(dgvr.Cells["CODE"].Value);
                // 数量
                OLTable.QUANTITY = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                //单位编号
                OLTable.UNIT_CODE = CConvert.ToString(dgvr.Cells["UNIT_CODE"].Value);
                //单价
                OLTable.PRICE = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                //金额
                OLTable.AMOUNT = CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
                //货币编号
                OLTable.CURRENCY_CODE = CConvert.ToString(cboCurrency.SelectedValue);
                //备注
                OLTable.MEMO = CConvert.ToString(dgvr.Cells["MEMO"].Value);
                //明细状态
                OLTable.STATUS_FLAG = CConstant.INIT_STATUS;

                if (OLTable.PRODUCT_CODE.Length >= 4 && OLTable.PRODUCT_CODE.Substring(0,4) == "9999")
                {
                    OLTable.PRODUCT_NAME = CConvert.ToString(dgvr.Cells["NAME"].Value);

                    OLTable.PRODUCT_SPEC = CConvert.ToString(dgvr.Cells["MODEL_NUMBER"].Value);
                }
                if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))　// 订单输入
                {
                    OLTable.SHIPMENT_QUANTITY = 0;
                    OLTable.ALLOATION_QUANTITY = 0;
                }
                //
                if (OLTable.PRODUCT_CODE != "")
                {
                    OHTable.AddItem(OLTable);
                }
            }

            int result = 0;
            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))　// 订单输入
            {
                string message = "";
                BCustomer bcut = new BCustomer();
                if (txtCustomerCode.Text != "")
                {
                    DataTable bd = bcut.GetList(" CODE='" + txtCustomerCode.Text + "'").Tables[0];
                    message = "【提示】订单请款公司为：" + bd.Rows[0]["CLAIM_NAME"] + "\r\n";
                }
                else if (txtEndCustomerCode.Text != "")
                {
                    DataTable bd1 = bcut.GetList(" CODE='" + txtEndCustomerCode.Text + "'").Tables[0];
                    message = "【提示】订单请款公司为：" + bd1.Rows[0]["CLAIM_NAME"] + "\r\n";
                }
                if (CConvert.ToDecimal(txtAmountIncludedTax.Text) == 0)
                {
                    message += "【警告】含税金额为0；";
                }
                if (!string.IsNullOrEmpty(message))
                {
                    if (MessageBox.Show(message, "订单保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        return;
                    }
                }

                try
                {
                    string slipNumber = bOrderHeader.Add(OHTable);
                    if (slipNumber == null)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        initSlipNumber();
                        if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName))
                        {
                            DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName);
                            di.MoveTo(_attachedDirectory + slipNumber);
                        }
                        _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }

                }
                catch (IOException iex)
                {
                    _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Logger.Error("附件上传失败。", iex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("新建订单保存失败。", ex);
                }
            }
            else if (CConstant.ORDER_MODIFY.Equals(CTag)) //订单修正
            {
                BllOrderHeaderTable oldOHTable = bOrderHeader.GetModel(_oldSlipNumber);
                //承认状态
                OHTable.VERIFY_FLAG = oldOHTable.VERIFY_FLAG;
                //引当区分
                OHTable.ALLOATION_FLAG = oldOHTable.ALLOATION_FLAG;
                //更新回数
                OHTable.UPDATED_COUNT = oldOHTable.UPDATED_COUNT + 1;
                //下单时的预付款时间
                if (txtOrderDepositDate.Checked)
                {
                    OHTable.ORDER_DEPOSIT_DATE = txtOrderDepositDate.Value;
                }
                //出库时的预付款时间
                if (txtShipmentDepositDate.Checked)
                {
                    OHTable.SHIPMENT_DEPOSIT_DATE = txtShipmentDepositDate.Value;
                }

                try
                {
                    result = bOrderHeader.Update(OHTable);
                    if (result <= 0)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("订单修改保存失败。", ex);
                }
            }
            else if (CConstant.ORDER_VERIFY.Equals(CTag))   //订单承认
            {
                try
                {
                    //预付金额
                    decimal depositAmount = (new BDepositArr()).GetArrAmount(_oldSlipNumber);

                    if (OHTable.ORDER_DEPOSIT / 100 > depositAmount / OHTable.AMOUNT_INCLUDED_TAX)
                    {
                        MessageBox.Show("销售时预付款金额未支付或支付不足。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!bOrderHeader.UpdateVerify(_oldSlipNumber, CConstant.VERIFY))
                    {
                        MessageBox.Show("订单承认失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单承认成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单承认失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("订单承认失败。", ex);
                }
            }

        }
        #endregion

        #region 订单取消
        /// <summary>
        /// 订单取消
        /// </summary>
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (_oldSlipNumber != "")
            {
                if (CConstant.ORDER_MODIFY.Equals(CTag)) //订单修正
                {
                    if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        try
                        {
                            if (!bOrderHeader.Delete(_oldSlipNumber))
                            {
                                MessageBox.Show("订单取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                initPage();
                                _dialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("订单取消失败！请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logger.Error("订单取消失败。", ex);
                        }
                    }
                }
                else if (CConstant.ORDER_VERIFY.Equals(CTag))   //订单承认
                {
                    try
                    {
                        if (!bOrderHeader.UpdateVerify(_oldSlipNumber, CConstant.NO_VERIFY))
                        {
                            MessageBox.Show("订单承认失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("订单承认保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            initPage();
                            _dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("订单承认保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("订单承认保存失败。", ex);
                    }

                    return;

                }
            }
        }
        #endregion

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前主表数据验证
        /// </summary>
        private bool CheckHeaderInput()
        {
            string message = "";
            if (string.IsNullOrEmpty(this.txtEndCustomerCode.Text))
            {
                message += "需要家不能为空。\r\n";
            }

            if (string.IsNullOrEmpty(this.txtDeliveryPointCode.Text))
            {
                message += "纳入先不能为空。\r\n";
            }

            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text))
            {
                message += "出库仓库不能为空。\r\n";
            }

            if (message.Length > 0)
            {
                MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据保存前明细数据验证
        /// </summary>
        private bool CheckLineInput()
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (CConvert.ToString(row.Cells["CODE"].Value) == "")
                {
                    MessageBox.Show("商品名称不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(row.Cells["QUANTITY"].Value) == "")
                {
                    MessageBox.Show("销售数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) == 0)
                {
                    MessageBox.Show("销售数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(row.Cells["PRICE"].Value) == "")
                {
                    MessageBox.Show("销售单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 数据保存成功后页面初始化
        /// <summary>
        /// 数据保存成功后页面初始化
        /// </summary>
        private void initPage()
        {
            this.cboSlipType.SelectedIndex = 0;
            this.txtSlipNumber.Text = "";
            this.txtCustomerCode.Text = "";
            this.txtCustomerName.Text = "";
            this.txtEndCustomerCode.Text = "";
            this.txtEndCustomerName.Text = "";
            this.txtDeliveryPointCode.Text = "";
            this.txtDeliveryPointName.Text = "";
            this.txtOwnerPoNumber.Text = "";
            this.txtSlipDate.Value = DateTime.Now;
            this.txtDepartualDate.Value = DateTime.Now;
            this.txtWarehouseCode.Text = "";
            this.txtWarehouseName.Text = "";
            this.cboTax.SelectedIndex = 0;
            this.cboCurrency.SelectedIndex = 0;
            this.txtOwnerPoNumber.Text = "";
            this.txtCustomerPoNumber.Text = "";
            this.txtSerialNumber.Text = "";
            this.txtOrderDeposit.Text = "";
            this.txtShipmentDeposit.Text = "";
            this.txtMemo.Text = "";
            this.txtCheckNumber.Text = "";
            this.txtCheckDate.Checked = false;
            this.txtQuotesNumber.Text = "";
            this.txtSerialType.Text = "";
            this.txtShippedDeposit.Text = "";
            this.txtShippedDepositDate.Checked = false;
            this.txtAmountIncludedTax.Text = CConvert.ToString(0.0);
            this.txtAmountWithoutTax.Text = CConvert.ToString(0.0);
            this.txtTaxAmount.Text = CConvert.ToString(0.0);

            this.dgvData.Rows.Clear();
        }

        #endregion

        #region 页面关闭
        /// <summary>
        /// 页面关闭
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 页面关闭后的返回值
        /// </summary>
        private void FrmOrdersEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }
        #endregion

        #region 订单类型发生变化时
        /// <summary>
        /// 订单类型发生变化时
        /// </summary>
        private void cboSlipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))
            {
                initSlipNumber();
            }
        }
        #endregion

        #region 附件添加
        /// <summary>
        /// 附件的添加
        /// </summary>
        private void btnAttached_Click(object sender, EventArgs e)
        {
            FrmAttached frm = null;
            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))
            {
                frm = new FrmAttached(_tmpAttachedDirectoryName, _attachedDirectory);
            }
            else
            {
                frm = new FrmAttached(_oldSlipNumber, _attachedDirectory);
            }

            if (frm != null)
            {
                frm.ShowDialog(this);
                attachedNumber = frm.AttachedNumber;
                frm.Dispose();
            }
        }
        #endregion

        #region 输入控制
        /// <summary>
        /// 文本框输入控制 Integer
        /// </summary>
        private void TextBox_Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //全角转半角
            if (e.KeyChar >= 65296 && e.KeyChar <= 65305)
            {
                e.KeyChar -= Convert.ToChar(65248);
            }
            InputInteger(sender, e);
        }

        /// <summary>
        /// 文本框输入控制 Amount
        /// </summary>
        private void TextBox_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputAmount(sender, e);
        }

        //单位格KeyPress事务
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //全角转半角
            if (e.KeyChar >= 65296 && e.KeyChar <= 65305)
            {
                e.KeyChar -= Convert.ToChar(65248);
            }
        } 

        bool HasAttachEvent = false;

        /// <summary>
        /// DataGridView输入控制
        /// </summary>
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
                    {
                        //获取列序号
                        int columnIndex = dgvData.CurrentCell.ColumnIndex;
                        //单位格转化成文本框
                        TextBox tb = e.Control as TextBox;
                        //委托单位格KeyPress事务
                        if (c.KeyChar >= 65296 && c.KeyChar <= 65305)
                        {
                            c.KeyChar -= Convert.ToChar(65248);
                        }
                        InputDouble(o, c);
                    }
                    else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE")
                    {
                        //获取列序号
                        int columnIndex = dgvData.CurrentCell.ColumnIndex;
                        //单位格转化成文本框
                        TextBox tb = e.Control as TextBox;
                        //委托单位格KeyPress事务
                        if (c.KeyChar >= 65296 && c.KeyChar <= 65305)
                        {
                            c.KeyChar -= Convert.ToChar(65248);
                        }
                        InputAmount(o, c);
                    }
                    else
                    {
                        return;
                    }

                    //if (this.dgvData.CurrentCell.ColumnIndex == 1) return; // 第二列不验证
                    //if (!char.IsNumber(c.KeyChar)) c.Handled = true;
                });

                this.HasAttachEvent = true;
            }

            

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderDeposit.Focused)
            {
                if (CConvert.ToInt32(txtOrderDeposit.Text.Trim()) > 100)
                {
                    MessageBox.Show("销售时预付款只能输入1到100之间的整数!");
                    txtOrderDeposit.Text = "";
                }
            }
            if (txtShipmentDeposit.Focused)
            {
                if (CConvert.ToInt32(txtShipmentDeposit.Text.Trim()) > 100)
                {
                    MessageBox.Show("出库时预付款只能输入1到100之间的整数!");
                    txtShipmentDeposit.Text = "";
                }
            }
            if (txtShippedDeposit.Focused)
            {
                if (CConvert.ToInt32(txtShippedDeposit.Text.Trim()) > 100)
                {
                    MessageBox.Show("出库后回收款只能输入1到100之间的整数!");
                    txtShippedDeposit.Text = "";
                }
            }
        }
        #endregion

        private void ReSetPrice()
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) != 0)
                {
                    continue;
                }
                if (CConvert.ToString(dgvr.Cells["CODE"].Value) != "")
                {
                    if (string.IsNullOrEmpty(txtCustomerCode.Text))
                    {
                        dgvr.Cells["PRICE"].Value = dgvr.Cells["SALES_PRICE"].Value;
                    }
                    else
                    {
                        dgvr.Cells["PRICE"].Value = dgvr.Cells["CUSTOMER_SALES_PRICE"].Value;
                    }

                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                }
            }
            CalculateAmount();
        }




    }//end class
}
