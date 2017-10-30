using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderEntry : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int _operateMode = CConstant.PURCHASE_NEW;
        private int count;
        private BllPurchaseOrderTable _currentPurchaseOrderTable = null;
        //private string _oldSlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        public BllPurchaseOrderTable CurrentPurchaseOrderTable
        {
            set { _currentPurchaseOrderTable = value; }
            get { return _currentPurchaseOrderTable; }
        }

        public FrmPurchaseOrderEntry()
        {
            InitializeComponent();
        }

        private void FrmOrderImport_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region 订单类型的初始化
            cboPurchaseSlipType.ValueMember = "CODE";
            cboPurchaseSlipType.DisplayMember = "NAME";
            cboPurchaseSlipType.DataSource = CCacheData.PurchaseSlipType;
            #endregion

            #region 税率的初始化
            //税率的初始化  
            DataTable dtTaxation = CCacheData.Taxation.Copy();
            dtTaxation.Columns.Add("DISP_TAX_RATE", Type.GetType("System.String"));
            foreach (DataRow row in dtTaxation.Rows)
            {
                row["DISP_TAX_RATE"] = row["TAX_RATE"].ToString() + "%";
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

            #region 含税单价的初始化
            cboPriceTax.ValueMember = "CODE";
            cboPriceTax.DisplayMember = "NAME";
            cboPriceTax.DataSource = CCacheData.PRICE_TAX;
            cboPriceTax.SelectedIndex = 1;
            #endregion

            if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
            {
                initSlipNumber();
                btnOrderDelete.Visible = false;
            }
            else if (CConstant.PURCHASE_ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "采购订单修正";
                init();
                cboPurchaseSlipType.Enabled = false;

            }
            else if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "采购订单详细";
                setStatus(false);
                init();
                btnOrderDelete.Visible = false;
                cboPurchaseSlipType.Enabled = false;
            }
        }

        #region 页面的初始化
        public void init()
        {
            if (_currentPurchaseOrderTable != null)
            {
                this.cboPurchaseSlipType.SelectedValue = _currentPurchaseOrderTable.SLIP_TYPE;
                this.txtPurchaseSlipNumber.Text = _currentPurchaseOrderTable.SLIP_NUMBER;
                this.txtSupplierCode.Text = _currentPurchaseOrderTable.SUPPLIER_CODE;
                this.txtSupplierName.Text = bCommon.GetBaseMaster("SUPPLIER", _currentPurchaseOrderTable.SUPPLIER_CODE).Name;
                this.txtWarehouseCode.Text = _currentPurchaseOrderTable.RECEIPT_WAREHOUSE_CODE;
                this.txtWarehouseName.Text = bCommon.GetBaseMaster("WAREHOUSE", _currentPurchaseOrderTable.RECEIPT_WAREHOUSE_CODE).Name;
                this.txtPackingMethod.Text = _currentPurchaseOrderTable.PACKING_METHOD;
                this.txtMemo.Text = _currentPurchaseOrderTable.MEMO;
                this.txtPayment.Text = _currentPurchaseOrderTable.PAYMENT_CONDITION;
                this.txtOrderNumber.Text = _currentPurchaseOrderTable.ORDER_SLIP_NUMBER;
                this.txtSupplierOrderCode.Text = _currentPurchaseOrderTable.SUPPLIER_ORDER_NUMBER;
                this.txtPurchaseQuotation.Text = _currentPurchaseOrderTable.PURCHASE_QUOTATION_NUMBER;
                this.entryDate.Text = Convert.ToString(_currentPurchaseOrderTable.SLIP_DATE);
                this.dueDate.Text = Convert.ToString(_currentPurchaseOrderTable.DUE_DATE);
                foreach (DataRow dr in CCacheData.Taxation.Rows)
                {
                    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(_currentPurchaseOrderTable.TAX_RATE) * 100)
                    {
                        this.cboTax.SelectedValue = dr["CODE"];
                        break;
                    }
                }

                this.cboCurrency.SelectedValue = _currentPurchaseOrderTable.CURRENCY_CODE;
                BllPurchaseOrderLineTable OLTable = new BllPurchaseOrderLineTable();
                DataSet ds = bPurchaseOrder.GetPurchaseOrderList(_currentPurchaseOrderTable.SLIP_NUMBER);
                bool isFirst = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (isFirst)
                    {
                        cboPriceTax.SelectedValue = CConvert.ToString(dr["INCLUDED_TAX_STATUS"]);
                        isFirst = false;
                    }
                    string code = CConvert.ToString(dr["PRODUCT_CODE"]);
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                    dgvr.Cells["NO"].Value = dr["LINE_NUMBER"];
                    dgvr.Cells["PRODUCT_CODE"].Value = dr["PRODUCT_CODE"];
                    dgvr.Cells["OLD_CODE"].Value = dr["PRODUCT_CODE"];
                    
                    dgvr.Cells["QUANTITY"].Value = dr["QUANTITY"];
                    dgvr.Cells["UNIT_NAME"].Value = dr["UNIT_NAME"];
                    dgvr.Cells["UNIT_CODE"].Value = dr["UNIT_CODE"];
                    dgvr.Cells["PRICE"].Value = dr["PRICE"];
                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dr["QUANTITY"]) * CConvert.ToDecimal(dr["PRICE"]);
                    dgvr.Cells["MEMO"].Value = dr["MEMO"];

                    BaseProductTable product = null;
                    if (code.Length >=4 && code.Substring(0, 4) == "9999")
                    {
                        dgvr.Cells["NAME"].Value = dr["PRODUCT_NAME"];
                        dgvr.Cells["MODEL_NUMBER"].Value = dr["PRODUCT_SPEC"];
                        dgvr.Cells["NAME"].ReadOnly = false;
                        dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                        product = new BProduct().GetModel(code.Substring(0,4));
                    }
                    else
                    {
                        dgvr.Cells["NAME"].ReadOnly = true;
                        dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                        product = new BProduct().GetModel(code);
                        if (product != null)
                        {
                            dgvr.Cells["NAME"].Value = product.NAME;
                            dgvr.Cells["MODEL_NUMBER"].Value = product.SPEC + " " + product.MODEL_NUMBER;
                        }
                    }
                    if (product != null)
                    {
                        
                        if (product.FROMSET_FLAG == 1)
                        {
                            dgvr.Cells["FROMSET"].Value = "否";
                        }
                        else
                        {
                            dgvr.Cells["FROMSET"].Value = "是";
                        }

                        dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = product.PURCHASE_PRICE_INCLUDED_TAX;
                        dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = product.PURCHASE_PRICE_WITHOUT_TAX;
                    }
                }

                CalculateAmount();
                btnOrderDelete.Visible = true;
            }
        }

        private void setStatus(bool flag)
        {
            this.cboPurchaseSlipType.Enabled = flag;
            this.txtPurchaseSlipNumber.Enabled = flag;
            this.txtSupplierCode.Enabled = flag;
            this.txtPackingMethod.Enabled = flag;
            this.txtOrderNumber.Enabled = flag;
            this.entryDate.Enabled = flag;
            this.txtSupplierOrderCode.Enabled = flag;
            this.txtWarehouseCode.Enabled = flag;
            this.cboTax.Enabled = flag;
            this.cboCurrency.Enabled = flag;
            this.cboPriceTax.Enabled = flag;
            this.dueDate.Enabled = flag;
            this.txtPayment.Enabled = flag;
            this.txtMemo.Enabled = flag;
            this.btnSupplier.Enabled = flag;
            this.btnWarehouse.Enabled = flag;
            this.btnSave.Enabled = flag;
            this.btnOrderDelete.Enabled = flag;
            this.btnProductInfo.Enabled = flag;
            this.btnAddRow.Enabled = flag;
            this.btnDeleteRow.Enabled = flag;
            this.btnSave.Visible = flag;
            this.btnOrderDelete.Visible = flag;
            this.btnOrders.Enabled = flag;
            this.txtPurchaseQuotation.Enabled = flag;
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
        #endregion

        #region 订单编号的初始化
        /// <summary>
        /// 订单编号的初始化
        /// </summary>
        public void initSlipNumber()
        {
            //订单编号的初始化
            string maxSlipNumber = bPurchaseOrder.GetMaxSlipNumber(UserTable.COMPANY_CODE, CConvert.ToString(cboPurchaseSlipType.SelectedValue));
            int number = Convert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = UserTable.COMPANY_CODE + "-" + CConvert.ToString(cboPurchaseSlipType.SelectedValue) + "-" + number.ToString().PadLeft(4, '0');
            txtPurchaseSlipNumber.Text = slipNumber;
        }
        #endregion

        #region 重绘表头
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex == -1 && (e.ColumnIndex == 1))
            {
                CellPainting(dgv, 2, "商品编号", e);
                e.Handled = true;
            }
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
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                dgvr.Cells["No"].Value = dgvr.Index + 1;
            }
        }
        #endregion

        #region 总金额计算
        /// <summary>
        /// 总金额计算
        /// </summary>
        private void CalculateAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                totalAmount += Convert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
            }
            if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
            {
                txtAmountWithoutTax.Text = Math.Round(totalAmount, 2).ToString("N");
                txtAmountIncludedTax.Text = Math.Round(totalAmount, 2).ToString("N");
                txtTaxAmount.Text = "0.00";
            }
            else if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
            {
                txtAmountWithoutTax.Text = Math.Round(totalAmount, 2).ToString("N");
                decimal taxAmount = Math.Round(totalAmount * CConstant.DEFAULT_TAX, 2);
                txtTaxAmount.Text = taxAmount.ToString("N");
                txtAmountIncludedTax.Text = Math.Round(totalAmount + taxAmount, 2).ToString("N");
            }
            else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
            {
                txtAmountIncludedTax.Text = Math.Round(totalAmount, 2).ToString("N");
                decimal withOutAmount = Math.Round(WithoutAmount(totalAmount, CConstant.DEFAULT_TAX), 2);
                txtAmountWithoutTax.Text = Math.Round(withOutAmount, 2).ToString("N");
                txtTaxAmount.Text = (totalAmount - withOutAmount).ToString("N");
            }


        }
        #endregion

        #region 入库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtPackingMethod.Focus();
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
                    MessageBox.Show("入库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    BaseSupplierTable CurrenceCodeTable = GetSupplierCurrence(txtSupplierCode.Text.Trim());
                    if (CurrenceCodeTable != null)
                    {
                        cboCurrency.SelectedValue = CurrenceCodeTable.CURRENCE_CODE;
                        if (CurrenceCodeTable.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                        {
                            cboTax.SelectedValue = "01";
                        }
                        else
                        {
                            cboTax.SelectedValue = "99";
                        }
                    }
                    txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                BaseSupplierTable CurrenceCodeTable = GetSupplierCurrence(SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    if (CurrenceCodeTable != null)
                    {
                        cboCurrency.SelectedValue = CurrenceCodeTable.CURRENCE_CODE;
                        if (CurrenceCodeTable.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                        {
                            cboTax.SelectedValue = "01";
                        }
                        else
                        {
                            cboTax.SelectedValue = "99";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else
            {
                txtSupplierName.Text = "";
            }
        }
        #endregion

        #region 销售编号
        private void txtOrderNumber_Leave(object sender, EventArgs e)
        {
            string order = txtOrderNumber.Text.Trim();
            if (!string.IsNullOrEmpty(order))
            {
                BOrderHeader bOrderHeader = new BOrderHeader();
                if (!bOrderHeader.Exists(order))
                {
                    MessageBox.Show("销售订单编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrderNumber.Text = "";
                    txtOrderNumber.Focus();
                }
                else
                {
                    BllOrderHeaderTable orderTable = bOrderHeader.GetModel(order);
                    txtSupplierOrderCode.Text = orderTable.QUOTES_NUMBER;
                    foreach (BllOrderLineTable line in orderTable.Items)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        BaseProductTable productTable = null;
                        if (line.PRODUCT_CODE.Length >= 4 && line.PRODUCT_CODE.Substring(0, 4) == "9999")
                        {
                            dgvr.Cells["NAME"].ReadOnly = false;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                            productTable = bProduct.GetModel(line.PRODUCT_CODE.Substring(0, 4));
                        }
                        else
                        {
                            dgvr.Cells["NAME"].ReadOnly = true;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                            productTable = bProduct.GetModel(line.PRODUCT_CODE);
                        }
                        if (productTable != null)
                        {
                            if (!line.PRODUCT_CODE.Equals(dgvr.Cells["OLD_CODE"].Value))
                            {
                                dgvr.Cells["PRODUCT_CODE"].Value = line.PRODUCT_CODE;
                                dgvr.Cells["OLD_CODE"].Value = line.PRODUCT_CODE;
                                if (line.PRODUCT_CODE.Length >= 4 && line.PRODUCT_CODE.Substring(0, 4) == "9999")
                                {
                                    dgvr.Cells["NAME"].Value = line.PRODUCT_NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = line.PRODUCT_SPEC;
                                }
                                else
                                {
                                    dgvr.Cells["NAME"].Value = productTable.NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                }
                                dgvr.Cells["QUANTITY"].Value = 1;
                                dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                dgvr.Cells["MEMO"].Value = line.MEMO;

                                if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                }
                                else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                }

                                dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                                if (productTable.FROMSET_FLAG == 1)
                                {
                                    dgvr.Cells["FROMSET"].Value = "否";
                                }
                                else
                                {
                                    dgvr.Cells["FROMSET"].Value = "是";
                                }
                                CalculateAmount();
                            }
                        }
                    }
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            FrmOrdersSearch frm = new FrmOrdersSearch();
            frm.CTag = CConstant.ORDER_MASTER_SEARCH;
            frm.COMPANY = UserTable.COMPANY_CODE;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.orderTable != null)
                {
                    string slipNumber = frm.orderTable.SLIP_NUMBER;
                    txtOrderNumber.Text = slipNumber;
                    BllOrderHeaderTable order = bOrderHeader.GetModel(slipNumber);
                    txtSupplierOrderCode.Text = order.QUOTES_NUMBER;
                    foreach (BllOrderLineTable line in order.Items)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        BaseProductTable productTable = null;
                        if (line.PRODUCT_CODE.Length >= 4 && line.PRODUCT_CODE.Substring(0, 4) == "9999")
                        {
                            dgvr.Cells["NAME"].ReadOnly = false;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = false;
                            productTable = bProduct.GetModel(line.PRODUCT_CODE.Substring(0, 4));
                        }
                        else
                        {
                            dgvr.Cells["NAME"].ReadOnly = true;
                            dgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
                            productTable = bProduct.GetModel(line.PRODUCT_CODE);
                        }
                        if (productTable != null)
                        {
                            if (!line.PRODUCT_CODE.Equals(dgvr.Cells["OLD_CODE"].Value))
                            {
                                dgvr.Cells["PRODUCT_CODE"].Value = line.PRODUCT_CODE;
                                dgvr.Cells["OLD_CODE"].Value = line.PRODUCT_CODE;
                                if (line.PRODUCT_CODE.Length >= 4 && line.PRODUCT_CODE.Substring(0, 4) == "9999")
                                {
                                    dgvr.Cells["NAME"].Value = line.PRODUCT_NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = line.PRODUCT_SPEC;
                                }
                                else
                                {
                                    dgvr.Cells["NAME"].Value = productTable.NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                }
                                dgvr.Cells["QUANTITY"].Value = 1;
                                dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                dgvr.Cells["MEMO"].Value = line.MEMO;
                                if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                }
                                else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                }

                                dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                                if (productTable.FROMSET_FLAG == 1)
                                {
                                    dgvr.Cells["FROMSET"].Value = "否";
                                }
                                else
                                {
                                    dgvr.Cells["FROMSET"].Value = "是";
                                }
                                CalculateAmount();
                            }
                        }
                    }
                }
            }
            frm.Dispose();
        }
        #endregion

        #region 增加一行
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (dgvr.Cells["PRODUCT_CODE"].Value == null || "".Equals(dgvr.Cells["PRODUCT_CODE"].Value.ToString().Trim()))
                {
                    dgvr.Cells["PRODUCT_CODE"].Selected = true;
                    return;
                }
            }
            int currentRowIndex = dgvData.Rows.Add(1);
            DataGridViewRow cdgvr = dgvData.Rows[currentRowIndex];
            cdgvr.Cells[1].Selected = true;
            cdgvr.Cells["NAME"].ReadOnly = true;
            cdgvr.Cells["MODEL_NUMBER"].ReadOnly = true;
            cdgvr.Cells["QUANTITY"].Value = "0";
            cdgvr.Cells["PRICE"].Value = "0";
            cdgvr.Cells["AMOUNT"].Value = "0";
            cdgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = "0";
            cdgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = "0";
        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
        }
        #endregion

        #region DataGridView 单击事件
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
                            string taxation = cboTax.Text.Replace("%", "");
                            if (productTable != null)
                            {
                                if (!productTable.CODE.Equals(dgvr.Cells["OLD_CODE"].Value)) //商品编号未变换
                                {
                                    dgvr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                    dgvr.Cells["OLD_CODE"].Value = productTable.CODE;
                                    dgvr.Cells["NAME"].Value = productTable.NAME;
                                    dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                    dgvr.Cells["QUANTITY"].Value = 1;
                                    if (bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE) != null)
                                    {
                                        dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                    }
                                    dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                    dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                    dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                    dgvr.Cells["PRICE_JP"].Value = productTable.PRICE_JP;

                                    if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
                                    {
                                        dgvr.Cells["PRICE"].Value = productTable.PRICE_JP;
                                    }
                                    else if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                                    {
                                        dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                    }
                                    else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                                    {
                                        dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                    }

                                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                                    if (productTable.FROMSET_FLAG == 1)
                                    {
                                        dgvr.Cells["FROMSET"].Value = "否";
                                    }
                                    else
                                    {
                                        dgvr.Cells["FROMSET"].Value = "是";
                                    }
                                    CalculateAmount();
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvr.Cells["PRODUCT_CODE"].Value = "";
                                dgvr.Cells["NAME"].Value = "";
                                dgvr.Cells["MODEL_NUMBER"].Value = "";
                                dgvr.Cells["QUANTITY"].Value = "0";
                                dgvr.Cells["UNIT_NAME"].Value = "";
                                dgvr.Cells["UNIT_CODE"].Value = "";
                                dgvr.Cells["PRICE"].Value = "0";
                                dgvr.Cells["AMOUNT"].Value = "0";
                                dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = "0";
                                dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = "0";
                                dgvr.Cells["CODE"].Selected = true;
                                CalculateAmount();
                            }

                        }
                    }
                    frm.Dispose();
                }
                else if (e.ColumnIndex == dgvData.Columns["FROMSET"].Index)
                {
                    DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                    if (CConvert.ToString(dgvr.Cells["FROMSET"].Value) == "是")
                    {
                        string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PURCHASE);
                        string slipNumber = txtPurchaseSlipNumber.Text;
                        string product = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                        FrmPOAttached frm = null;
                        if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
                        {
                            frm = new FrmPOAttached(slipNumber, product, attachedDirectory, CConstant.PURCHASE_SEARCH);
                        }
                        else
                        {
                            frm = new FrmPOAttached(slipNumber, product, attachedDirectory, CConstant.PURCHASE_NEW);
                        }
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 税率的选择变更
        /// <summary>
        /// 税率的选择变更
        /// </summary>
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string taxation = cboTax.Text.Replace("%", "");
            //foreach (DataGridViewRow dr in dgvData.Rows)
            //{
            //    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
            //}
            //CalculateAmount();
        }
        #endregion

        #region
        private void cboPriceTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string taxation = cboTax.Text.Replace("%", "");
            object obj = cboPriceTax.SelectedValue;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
                {
                    dgvr.Cells["PRICE"].Value = dgvr.Cells["PRICE_JP"].Value;
                }
                else if (CConstant.PRICE_WITHOUT_TAX.Equals(obj))
                {

                    dgvr.Cells["PRICE"].Value = dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value;
                }
                else if (CConstant.PRICE_INCLUDED_TAX.Equals(obj))
                {
                    dgvr.Cells["PRICE"].Value = dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value;
                }

                dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) * CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
            }

            CalculateAmount();
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
                string taxation = cboTax.Text.Replace("%", "");
                if (e.ColumnIndex == dgvData.Columns["PRODUCT_CODE"].Index)
                {
                    string code = dgvr.Cells["PRODUCT_CODE"].Value.ToString().Trim();
                    if (code != "")
                    {
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
                                dgvr.Cells["PRODUCT_CODE"].Value = code;
                                dgvr.Cells["OLD_CODE"].Value = code;
                                dgvr.Cells["NAME"].Value = productTable.NAME;
                                dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                dgvr.Cells["QUANTITY"].Value = 1;
                                dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                dgvr.Cells["PRICE_JP"].Value = productTable.PRICE_JP;

                                if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PRICE_JP;
                                }
                                else if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                                }
                                else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                                {
                                    dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                                }

                                dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                                if (productTable.FROMSET_FLAG == 1)
                                {
                                    dgvr.Cells["FROMSET"].Value = "否";
                                }
                                else
                                {
                                    dgvr.Cells["FROMSET"].Value = "是";
                                }
                                CalculateAmount();
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvr.Cells["PRODUCT_CODE"].Value = "";
                            dgvr.Cells["NAME"].Value = "";
                            dgvr.Cells["MODEL_NUMBER"].Value = "";
                            dgvr.Cells["QUANTITY"].Value = "0";
                            dgvr.Cells["UNIT_CODE"].Value = "";
                            dgvr.Cells["UNIT_NAME"].Value = "";
                            dgvr.Cells["PRICE"].Value = "0";
                            dgvr.Cells["AMOUNT"].Value = "0";
                            dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = "0";
                            dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = "0";
                            dgvr.Cells["CODE"].Selected = true; ;
                            CalculateAmount();
                        }
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["QUANTITY"].Index)
                {
                    string quantity = CConvert.ToString(dgvr.Cells["QUANTITY"].Value);
                    //Convert.ToDecimal(dr.Cells["QUANTITY"].Value.ToString().Trim());
                    if (quantity == "")
                    {
                        dgvr.Cells["QUANTITY"].Value = 0;
                    }
                    else
                    {
                        dgvr.Cells["QUANTITY"].Value = CConvert.ToDecimal(quantity);
                    }

                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    CalculateAmount();
                }
                else if (e.ColumnIndex == dgvData.Columns["PRICE"].Index)
                {
                    string price = CConvert.ToString(dgvr.Cells["PRICE"].Value);
                    //Convert.ToDecimal(dr.Cells["PRICE"].Value.ToString().Trim());
                    if (price == "")
                    {
                        dgvr.Cells["PRICE"].Value = 0;
                    }
                    else
                    {
                        dgvr.Cells["PRICE"].Value = CConvert.ToDecimal(price);
                    }

                    //if ("0".Equals(cboPriceTax.SelectedValue))
                    //{
                    //    dr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = CConvert.ToDecimal(price);
                    //}
                    //else if ("1".Equals(cboPriceTax.SelectedValue))
                    //{
                    //    dr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = CConvert.ToDecimal(price);
                    //}

                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    CalculateAmount();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }

        private void FrmPurchaseOrderEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }
        #endregion

        #region 保存
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

            BllPurchaseOrderTable POTable = new BllPurchaseOrderTable();
            BllPurchaseOrderLineTable OLTable = null;

            //订单类型
            POTable.SLIP_TYPE = cboPurchaseSlipType.SelectedValue.ToString();
            //订单编号
            POTable.SLIP_NUMBER = txtPurchaseSlipNumber.Text.Trim();
            //销售订单编号
            POTable.ORDER_SLIP_NUMBER = txtOrderNumber.Text.Trim();
            //供应商编号
            POTable.SUPPLIER_CODE = txtSupplierCode.Text.Trim();
            //报价单号
            POTable.SUPPLIER_ORDER_NUMBER = txtSupplierOrderCode.Text.Trim();
            //本社订单编号
            POTable.PURCHASE_QUOTATION_NUMBER = txtPurchaseQuotation.Text.Trim();
            //入库仓库
            POTable.RECEIPT_WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
            //采购订单日期
            POTable.SLIP_DATE = CConvert.ToDateTime(entryDate.Value.ToString("yyyy-MM-dd"));
            //交货期限
            POTable.DUE_DATE = CConvert.ToDateTime(dueDate.Value.ToString("yyyy-MM-dd"));
            //税率
            if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
            {
                POTable.TAX_RATE = 0;
            }
            else
            {
                POTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
            }
            //通货
            POTable.CURRENCY_CODE = cboCurrency.SelectedValue.ToString();
            //包装方式
            POTable.PACKING_METHOD = txtPackingMethod.Text.Trim();
            //付款方式
            POTable.PAYMENT_CONDITION = txtPayment.Text.Trim();
            //备注
            POTable.MEMO = txtMemo.Text.Trim();
            //状态
            POTable.STATUS_FLAG = CConstant.PURCHASE_NEW;
            //创建人           
            POTable.CREATE_USER = UserTable.CODE;
            //最后更新人
            POTable.LAST_UPDATE_USER = UserTable.CODE;
            //公司
            POTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            //总金额
            POTable.TOTAL_AMOUNT = CConvert.ToDecimal(txtAmountIncludedTax.Text.Trim());
            //明细的整理
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                OLTable = new BllPurchaseOrderLineTable();
                OLTable.SLIP_NUMBER = POTable.SLIP_NUMBER;
                OLTable.LINE_NUMBER = dgvr.Index + 1;
                OLTable.PRODUCT_CODE = dgvr.Cells["PRODUCT_CODE"].Value.ToString();
                OLTable.QUANTITY = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value.ToString());
                OLTable.UNIT_CODE = dgvr.Cells["UNIT_CODE"].Value.ToString();
                OLTable.PRICE = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value.ToString());

                decimal amount = CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value.ToString());
                OLTable.INCLUDED_TAX_STATUS = CConvert.ToInt32(cboPriceTax.SelectedValue);
                if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
                {
                    OLTable.AMOUNT_WITHOUT_TAX = amount;
                    OLTable.TAX_AMOUNT = 0;
                    OLTable.AMOUNT_INCLUDED_TAX = amount;
                }
                else if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                {
                    OLTable.AMOUNT_WITHOUT_TAX = amount;
                    OLTable.TAX_AMOUNT = Math.Round(amount * CConstant.DEFAULT_TAX, 2);
                    OLTable.AMOUNT_INCLUDED_TAX = amount + OLTable.TAX_AMOUNT;
                }
                else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                {
                    OLTable.AMOUNT_INCLUDED_TAX = amount;
                    OLTable.AMOUNT_WITHOUT_TAX = Math.Round(WithoutAmount(amount, CConstant.DEFAULT_TAX), 2);
                    OLTable.TAX_AMOUNT = amount - OLTable.AMOUNT_WITHOUT_TAX;
                }

                if (OLTable.PRODUCT_CODE.Length >= 4 && OLTable.PRODUCT_CODE.Substring(0, 4) == "9999")
                {
                    OLTable.PRODUCT_NAME = CConvert.ToString(dgvr.Cells["NAME"].Value);

                    OLTable.PRODUCT_SPEC = CConvert.ToString(dgvr.Cells["MODEL_NUMBER"].Value);
                }

                //OLTable.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(row.Cells["AMOUNT"].Value.ToString());
                //OLTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(row.Cells["AMOUNT_INCLUDED_TAX"].Value.ToString());
                //OLTable.TAX_AMOUNT = OLTable.AMOUNT_INCLUDED_TAX - OLTable.AMOUNT_WITHOUT_TAX;

                OLTable.MEMO = CConvert.ToString(dgvr.Cells["MEMO"].Value);
                OLTable.STATUS_FLAG = CConstant.PURCHASE_NEW;
                POTable.AddItem(OLTable);
            }

            int result = 0;
            try
            {
                if (_currentPurchaseOrderTable != null)
                {
                    result = bPurchaseOrder.Update(POTable);

                }
                else
                {
                    result = bPurchaseOrder.Add(POTable);
                }

                if (result <= 0)
                {
                    MessageBox.Show("订单保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
                    {
                        initPage();
                        initSlipNumber();
                    }
                    else
                    {
                        _dialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("订单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("订单保存失败！", ex);
            }
        }

        #endregion

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前的验证
        /// </summary>
        /// <returns></returns>
        private bool CheckHeaderInput()
        {
            string strErrorlog = null;
            //判断订单编号不能为空
            if (string.IsNullOrEmpty(this.txtPurchaseSlipNumber.Text.Trim()))
            {
                strErrorlog += "订单编号不能为空!\r\n";
            }
            //判断供应商编号不能为空
            if (string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()))
            {
                strErrorlog += "供应商编号不能为空!\r\n";
            }
            //仓库编号不能为空
            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                strErrorlog += "仓库编号不能为空!\r\n";
            }


            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value) == "")
                {
                    MessageBox.Show("商品编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(dgvr.Cells["QUANTITY"].Value) == "")
                {
                    MessageBox.Show("采购数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) == 0)
                {
                    MessageBox.Show("采购数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(dgvr.Cells["PRICE"].Value) == "")
                {
                    MessageBox.Show("采购单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.cboPurchaseSlipType.SelectedIndex = 0;
            this.txtPurchaseSlipNumber.Text = "";
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.txtWarehouseCode.Text = "";
            this.txtWarehouseName.Text = "";
            this.txtPackingMethod.Text = "";
            this.txtMemo.Text = "";
            this.entryDate.Value = DateTime.Now;
            this.dueDate.Value = DateTime.Now;
            this.txtOrderNumber.Text = "";
            this.txtSupplierOrderCode.Text = "";
            this.cboTax.SelectedIndex = 0;
            this.cboCurrency.SelectedIndex = 0;
            this.txtPayment.Text = "";

            this.txtAmountIncludedTax.Text = CConvert.ToString(0.0);

            this.dgvData.Rows.Clear();
        }

        #endregion

        #region 订单删除
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (txtPurchaseSlipNumber.Text.Trim() != "")
            {
                if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        if (!bPurchaseOrder.Delete(txtPurchaseSlipNumber.Text.Trim()))
                        {
                            MessageBox.Show("订单删除失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("订单删除成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("订单删除失败！请与管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("订单删除失败！", ex);
                    }
                }
            }
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion

        #region 控制只能输入数字
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(InputDouble);
            //}
            //else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
            //}

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
        #endregion

        #region 订单类型发生变化时
        private void cboPurchaseSlipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
            {
                initSlipNumber();
            }
        }
        #endregion

        #region 附属品的选择
        /// <summary>
        /// 附属品的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductInfo_Click(object sender, EventArgs e)
        {
            FrmAppendant frm = new FrmAppendant();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                foreach (ListItem li in frm.resultData)
                {
                    string code = li.Value;
                    decimal quantity = li.Quantity;
                    BaseProductTable productTable = bProduct.GetModel(code);
                    string taxation = cboTax.Text.Replace("%", "");
                    if (productTable != null)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        dgvr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                        dgvr.Cells["OLD_CODE"].Value = productTable.CODE;
                        dgvr.Cells["NAME"].Value = productTable.NAME;
                        dgvr.Cells["MODEL_NUMBER"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                        dgvr.Cells["QUANTITY"].Value = quantity;
                        dgvr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                        dgvr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                        dgvr.Cells["PURCHASE_PRICE_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                        dgvr.Cells["PURCHASE_PRICE_WITHOUT_TAX"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                        dgvr.Cells["PRICE_JP"].Value = productTable.PRICE_JP;

                        if (!CConstant.EXCHANGE_RMB.Equals(cboCurrency.SelectedValue))
                        {
                            dgvr.Cells["PRICE"].Value = productTable.PRICE_JP;
                        }
                        else if (CConstant.PRICE_WITHOUT_TAX.Equals(cboPriceTax.SelectedValue))
                        {
                            dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_WITHOUT_TAX;
                        }
                        else if (CConstant.PRICE_INCLUDED_TAX.Equals(cboPriceTax.SelectedValue))
                        {
                            dgvr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE_INCLUDED_TAX;
                        }


                        dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value) * CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                        if (productTable.FROMSET_FLAG == 1)
                        {
                            dgvr.Cells["FROMSET"].Value = "否";
                        }
                        else
                        {
                            dgvr.Cells["FROMSET"].Value = "是";
                        }
                        CalculateAmount();
                    }
                    else
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["PRODUCT_CODE"].Value = "";
                        dgvr.Cells["NAME"].Value = "";
                        dgvr.Cells["MODEL_NUMBER"].Value = "";
                        dgvr.Cells["QUANTITY"].Value = "0";
                        dgvr.Cells["UNIT_NAME"].Value = "";
                        dgvr.Cells["UNIT_CODE"].Value = "";
                        dgvr.Cells["PRICE"].Value = "0";
                        dgvr.Cells["AMOUNT"].Value = "0";
                        dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                        dgvr.Cells["CODE"].Selected = true;
                        CalculateAmount();
                    }
                }
            }

            frm.Dispose();
        }
        #endregion

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CConstant.EXCHANGE_JP.Equals(cboCurrency.SelectedValue))
            {
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    dgvr.Cells["PRICE"].Value = dgvr.Cells["PRICE_JP"].Value;

                    dgvr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) * CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                }
                cboTax.Enabled = false;
                cboPriceTax.Enabled = false;
                cboPriceTax.SelectedValue = 0;
                cboTax.SelectedValue = "99";
            }
            else
            {
                cboTax.Enabled = true;
                cboPriceTax.Enabled = true;
            }
            
            CalculateAmount();
        }


    }
}
