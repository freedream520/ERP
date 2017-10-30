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
using System.Collections;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private BllPurchaseOrderTable _currentPurchaseOrderTable = new BllPurchaseOrderTable();
        private string _currentConduction = "";
        public BllPurchaseOrderTable CurrentPurchaseOrderTable
        {
            get { return _currentPurchaseOrderTable; }
            set { _currentPurchaseOrderTable = value; }
        }
        private int Receipt;
        private bool isSearch = false;

        public FrmPurchaseOrderSearch()
        {
            InitializeComponent();
        }

        #region 页面初始化
        private void FrmPurchaseSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            #region 订单类型的初始化
            DataTable pstDT = CCacheData.PurchaseSlipType.Copy();
            DataRow dr = pstDT.NewRow();
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            pstDT.Rows.InsertAt(dr, 0);
            cboPurchaseSlipType.ValueMember = "CODE";
            cboPurchaseSlipType.DisplayMember = "NAME";
            cboPurchaseSlipType.DataSource = pstDT;
            #endregion

            init();
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        private void init()
        {
            if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
            {

            }
            //订单查询
            else if (CConstant.PURCHASE_ORDER_MASTER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "确　认";
                btnPrint.Visible = false;
                btnPurcahse.Visible = false;
                btnModify.Visible = false;
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
                    txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (SupplierCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("供应商不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
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

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bPurchaseOrder.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);
            isSearch = true;
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bPurchaseOrder.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                //出库状况

                getReceipt(dr.Cells["SLIP_NUMBER"].Value.ToString());

                if (Receipt == CConstant.UN_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "未入库";
                }
                else if (Receipt == CConstant.COMPLETE_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "入库完了";
                }
                else if (Receipt == CConstant.PART_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "入库欠品";
                }
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} ", CConstant.DELETE_STATUS);
            sb.AppendFormat(" AND COMPANY_CODE ='{0}'", UserTable.COMPANY_CODE);
            //订单类型
            if (cboPurchaseSlipType.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND SLIP_TYPE = '{0}'", cboPurchaseSlipType.SelectedValue);
            }
            if (txtPurchaseOrderCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SLIP_NUMBER like '{0}%' ", txtPurchaseOrderCode.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}' ", txtSupplierCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and RECEIPT_WAREHOUSE_CODE = '{0}' ", txtWarehouseCode.Text.Trim());
            }

            if (slipDateFrom.Checked)
            {
                sb.AppendFormat("and SLIP_DATE >= '{0}' ", slipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (slipDateTo.Checked)
            {
                sb.AppendFormat("and SLIP_DATE < '{0}' ", slipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (dueDateFrom.Checked)
            {
                sb.AppendFormat("and DUE_DATE >= '{0}' ", dueDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (dueDateTo.Checked)
            {
                sb.AppendFormat("and DUE_DATE < '{0}' ", dueDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = _currentDt.Rows.Count - 1; i >= 0; i--)
            {
                getReceipt(_currentDt.Rows[i]["SLIP_NUMBER"].ToString());
                if (rdolibraryOk.Checked)
                {
                    if (Receipt != CConstant.COMPLETE_RECEIPT)
                    {
                        _currentDt.Rows.Remove(_currentDt.Rows[i]);
                    }
                }
                else if (rdolibraryNo.Checked)
                {
                    if (Receipt == CConstant.COMPLETE_RECEIPT)
                    {
                        _currentDt.Rows.Remove(_currentDt.Rows[i]);
                    }
                }
            }
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }

        }

        #endregion

        #region 获得入荷状况

        public void getReceipt(string SLIP_NUMBER)
        {
            int a = 0;
            int b = 0;
            BllPurchaseOrderLineTable OLTable = new BllPurchaseOrderLineTable();
            DataSet ds = bPurchaseOrder.GetReceivingPlanByPurchaseOrderSlipNumber(SLIP_NUMBER);
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                if (CConvert.ToInt32(rows["STATUS_FLAG"]) == 0)
                {
                    a++;
                }
                else if (CConvert.ToInt32(rows["STATUS_FLAG"]) == 1)
                {
                    b++;
                }
            }           

            if (a == ds.Tables[0].Rows.Count)
            {
                Receipt = CConstant.UN_RECEIPT;
            }
            else if (b == ds.Tables[0].Rows.Count)
            {
                Receipt = CConstant.COMPLETE_RECEIPT;
            }
            else
            {
                Receipt = CConstant.PART_RECEIPT;
            }
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (GetCurrentSelectedTable())
            {
                getReceipt(_currentPurchaseOrderTable.SLIP_NUMBER);
                if (Receipt == CConstant.UN_RECEIPT)
                {
                    FrmPurchaseOrderEntry frm = new FrmPurchaseOrderEntry();
                    frm.UserTable = _userInfo;
                    frm.CTag = CConstant.PURCHASE_ORDER_MODIFY;
                    frm.CurrentPurchaseOrderTable = _currentPurchaseOrderTable;
                    if (DialogResult.OK == frm.ShowDialog(this))
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                    _currentPurchaseOrderTable = null;
                }
                else
                {
                    MessageBox.Show("明细已入库,不能修改!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 详细确认
        /// <summary>
        /// 详细确认
        /// </summary>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (GetCurrentSelectedTable())
            {
                if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
                {
                    FrmPurchaseOrderEntry frm = new FrmPurchaseOrderEntry();
                    frm.UserTable = _userInfo;
                    frm.CTag = CConstant.PURCHASE_ORDER_SEARCH;
                    frm.CurrentPurchaseOrderTable = _currentPurchaseOrderTable;
                    frm.ShowDialog(this);
                    frm.Dispose();
                    _currentPurchaseOrderTable = null;
                }
                else if (CConstant.PURCHASE_ORDER_MASTER_SEARCH.Equals(CTag))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private bool GetCurrentSelectedTable()
        {
            bool b = false;
            if (dgvData.SelectedRows.Count > 0)
            {
                try
                {
                    string slipNumber = dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value.ToString();

                    _currentPurchaseOrderTable = bPurchaseOrder.GetModel(slipNumber);

                    if (_currentPurchaseOrderTable != null)
                    {
                        b = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("采购订单查询选择数据错误：", ex);
                }
            }
            else
            {
                MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return b;
        }

        #region 控制空行不能被点击
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    row.Selected = false;
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

        #region 导出
        /// <summary>
        /// 导出
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bPurchaseOrder.GetPrintList(_currentConduction).Tables[0];
            if (isSearch && _currentDt.Rows.Count > 0)
            {
                int result = CommonExport.DataTableToExcel(_currentDt, CConstant.PURCHASE_ORDER_HEADER, CConstant.PURCHASE_ORDER_COLUMNS, "PURCHASE_ORDER", "PURCHASE_ORDER");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 注文书
        private void btnPurcahse_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                Hashtable ht = null;
                DataTable dt = null;
                DataGridViewRow row = dgvData.SelectedRows[0];

                BaseCompanyTable company = new BCompany().GetModel(_userInfo.COMPANY_CODE);
                BllPurchaseOrderTable purchase = bPurchaseOrder.GetModel(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                BllOrderHeaderTable order = new BOrderHeader().GetModel(purchase.ORDER_SLIP_NUMBER);
                BaseWarehouseTable warehouse = new BWarehouse().GetModel(purchase.RECEIPT_WAREHOUSE_CODE);

                if (company == null)
                {
                    company = new BaseCompanyTable();
                }

                if (warehouse == null)
                {
                    warehouse = new BaseWarehouseTable();
                }

                if (purchase == null)
                {
                    purchase = new BllPurchaseOrderTable();
                }
                BaseSupplierTable supplier = new BSupplier().GetModel(purchase.SUPPLIER_CODE);
                if (supplier.TYPE == 2)
                {
                    #region 国内
                    ht = new Hashtable();
                    ht.Add("&COMPANY_NAME", company.NAME);
                    ht.Add("&ADDRESS", company.ADDRESS_FIRST + company.ADDRESS_MIDDLE + company.ADDRESS_LAST);
                    if (string.IsNullOrEmpty(company.PHONE_NUMBER.ToString()))
                    {
                        ht.Add("&PHONE", "TEL                 " + "FAX" + company.FAX_NUMBER);
                    }
                    else
                    {
                        ht.Add("&PHONE", "TEL" + company.PHONE_NUMBER.ToString() + "FAX" + company.FAX_NUMBER);
                    }
                    ht.Add("&SLIP_NUMBER", purchase.SLIP_NUMBER);
                    ht.Add("&SLIP_DATE", purchase.SLIP_DATE.ToString("yyyy年MM月dd日"));
                    ht.Add("&SUPPLIER", "厂商名称:" + supplier.NAME);
                    //
                    ht.Add("&NAME", company.NAME);
                    ht.Add("&DUE_DATE", "1.交货日期：" + CConvert.ToDateTime(purchase.DUE_DATE).ToShortDateString());
                    ht.Add("&PACKING_METHOD", "2.包装方式：" + purchase.PACKING_METHOD);
                    ht.Add("&WAREHOUSE_NAME", "3.交货地址：" + warehouse.ADDRESS_FIRST + warehouse.ADDRESS_MIDDLE + warehouse.ADDRESS_LAST);
                    ht.Add("&PAYMENT_CONDITION", "4.支付方式：" + purchase.PAYMENT_CONDITION);

                    dt = new DataTable();
                    dt.Columns.Add("NO");
                    dt.Columns.Add("MODEL_NUMBER");                    
                    dt.Columns.Add("PRODUCT_NAME");
                    dt.Columns.Add("SPEC");
                    dt.Columns.Add("QUANTITY");
                    dt.Columns.Add("PRICE");
                    dt.Columns.Add("AMOUNT_WITHOUT_TAX");
                    //dt.Columns.Add("AMOUNT_INCLUDED_TAX");
                    dt.Columns.Add("DUE_DATE");

                    decimal amount = 0;
                    decimal taxAmount = 0;
                    DataRow rows = null;
                    foreach (BllPurchaseOrderLineTable OLModel in purchase.Items)
                    {
                        rows = dt.NewRow();
                        rows["NO"] = OLModel.LINE_NUMBER;
                        
                        if (OLModel.PRODUCT_CODE.Length >= 4 && OLModel.PRODUCT_CODE.Substring(0, 4) == "9999")
                        {
                            rows["PRODUCT_NAME"] = OLModel.PRODUCT_NAME;
                            rows["SPEC"] = OLModel.PRODUCT_SPEC;
                            rows["MODEL_NUMBER"] = "";
                        }
                        else
                        {
                            BaseProductTable product = new BProduct().GetModel(OLModel.PRODUCT_CODE);
                            if (product != null)
                            {
                                rows["PRODUCT_NAME"] = product.NAME;
                                rows["SPEC"] = product.SPEC;
                                rows["MODEL_NUMBER"] = product.MODEL_NUMBER;
                            }
                        }
                        rows["QUANTITY"] = OLModel.QUANTITY;
                        rows["PRICE"] = OLModel.PRICE;
                        rows["AMOUNT_WITHOUT_TAX"] = Convert.ToDouble(CConvert.ToDecimal(rows["QUANTITY"]) * CConvert.ToDecimal(rows["PRICE"])).ToString("0.00");
                        //rows["AMOUNT_INCLUDED_TAX"] = OLModel.AMOUNT_INCLUDED_TAX;
                        rows["DUE_DATE"] = CConvert.ToDateTime(purchase.DUE_DATE).ToString("yyyy/MM/dd");
                        amount += OLModel.AMOUNT_WITHOUT_TAX;
                        taxAmount += OLModel.TAX_AMOUNT;
                        dt.Rows.Add(rows);
                    }

                    ht.Add("&AMOUNT", amount);
                    ht.Add("&TAX_AMOUNT", taxAmount);
                    ht.Add("&TOTAL_AMOUNT", amount + taxAmount);

                    SaveFileDialog sf = new SaveFileDialog();
                    sf.FileName = "LZ_PURCHASE_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    sf.Filter = "(文件)|*.xls;*.xlsx";

                    if (sf.ShowDialog(this) == DialogResult.OK)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            int ret = CommonExport.ExportPurchase(@"rpt\purchase.xls", sf.FileName, dt, ht);
                            if (CConstant.EXPORT_FAILURE.Equals(ret))
                            {
                                MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_SUCCESS.Equals(ret))
                            {
                                MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (CConstant.EXPORT_RUNNING.Equals(ret))
                            {
                                MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
                            {
                                MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    #endregion
                }
                else
                {
                    decimal AMOUNT_WITHOUT_TAX = 0;
                    decimal ORDER_AMOUNT = 0;
                    #region 国外
                    ht = new Hashtable();
                    ht.Add("&SUPPLIER_NAME", supplier.NAME);
                    ht.Add("&CONTACT_NAME", supplier.CONTACT_NAME);
                    ht.Add("&PHONE", supplier.PHONE_NUMBER);
                    ht.Add("&FAX", supplier.FAX_NUMBER);
                   // ht.Add("&ORDER_NUMBER", purchase.ORDER_SLIP_NUMBER);
                    ht.Add("&SLIP_NUMBER", purchase.SLIP_NUMBER);
                    ht.Add("&SUPPLIER_ORDER_CODE", purchase.SUPPLIER_ORDER_NUMBER);
                    ht.Add("&PURCHASE_QUOTATION_NUMBER", purchase.PURCHASE_QUOTATION_NUMBER);
                    if (order != null)
                    {
                        ht.Add("&CUSTOMER_PO_NUMBER", order.CUSTOMER_PO_NUMBER);
                        string customerCode = "";
                        //if (!string.IsNullOrEmpty(order.CUSTOMER_NAME))
                        //{
                        //    customerCode = order.CUSTOMER_CODE;
                        //    ht.Add("&CUSTOMER_NAME", order.CUSTOMER_NAME);
                        //}
                        //else
                        //{
                            customerCode = order.ENDER_CUSTOMER_CODE;
                            ht.Add("&CUSTOMER_NAME", order.ENDER_CUSTOMER_NAME);
                        //}
                        
                        ht.Add("&DELIVERY_DATE", order.DUE_DATE);
                        ht.Add("&SERIAL_NUMBER", order.SERIAL_NUMBER);
                        ht.Add("&AIRCRAFT", order.SERIAL_TYPE);
                        BaseCustomerTable customer = new BCustomer().GetModel(customerCode);                        
                        ht.Add("&CUSTOMER_CONTACT_NAME", customer.CONTACT_NAME);
                        ht.Add("&CUSTOMER_PHONE", customer.PHONE_NUMBER);
                       
                        //ht.Add("&ORDER_AMOUNT", order.AMOUNT_INCLUDED_TAX);
                    }
                    else
                    {
                        ht.Add("&CUSTOMER_PO_NUMBER", "");
                        ht.Add("&DELIVERY_DATE", "");
                        ht.Add("&SERIAL_NUMBER", "");
                        //ht.Add("&ORDER_AMOUNT", "");
                        ht.Add("&AIRCRAFT", "");
                        ht.Add("&CUSTOMER_NAME", company.NAME_SHORT);
                        ht.Add("&CUSTOMER_CONTACT_NAME", "");
                        ht.Add("&CUSTOMER_PHONE", company.PHONE_NUMBER);
                    }
                    
                    ht.Add("&MEMO", purchase.MEMO);
                    ht.Add("&TOTAL_AMOUNT", purchase.TOTAL_AMOUNT);
                    ht.Add("&PAYMENT", purchase.PAYMENT_CONDITION);
                    ht.Add("&SLIP_DATE", purchase.SLIP_DATE);
                    ht.Add("&DUE_DATE", purchase.DUE_DATE);

                    dt = new DataTable();
                    dt.Columns.Add("NO");
                    dt.Columns.Add("PRODUCT_CODE");
                    dt.Columns.Add("X_1", Type.GetType("System.String"));
                    dt.Columns.Add("PRODUCT_NAME");
                    dt.Columns.Add("X_2", Type.GetType("System.String"));
                    dt.Columns.Add("MODEL_NUMBER");
                    dt.Columns.Add("X_3", Type.GetType("System.String"));
                    dt.Columns.Add("QUANTITY");
                    dt.Columns.Add("PRICE");
                    dt.Columns.Add("AMOUNT_WITHOUT_TAX");

                    DataRow rows = null;
                    foreach (BllPurchaseOrderLineTable OLModel in purchase.Items)
                    {
                        AMOUNT_WITHOUT_TAX += OLModel.AMOUNT_INCLUDED_TAX;
                        if (order != null)
                        {
                            foreach (BllOrderLineTable line in order.Items)
                            {
                                if (line.PRODUCT_CODE == OLModel.PRODUCT_CODE)
                                {
                                    ORDER_AMOUNT += CConvert.ToDecimal(line.AMOUNT);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ORDER_AMOUNT += 0; 
                        }

                        rows = dt.NewRow();
                        rows["NO"] = OLModel.LINE_NUMBER;
                        rows["PRODUCT_CODE"] = OLModel.PRODUCT_CODE;
                        if (OLModel.PRODUCT_CODE.Length >=4 && OLModel.PRODUCT_CODE.Substring(0, 4) == "9999")
                        {
                            rows["PRODUCT_NAME"] = OLModel.PRODUCT_NAME;
                            rows["MODEL_NUMBER"] = OLModel.PRODUCT_SPEC;
                        }
                        else
                        {
                            BaseProductTable product = new BProduct().GetModel(OLModel.PRODUCT_CODE);
                            if (product != null)
                            {
                                if (!string.IsNullOrEmpty(product.NAME_JP))
                                {
                                    rows["PRODUCT_NAME"] = product.NAME_JP;
                                }
                                else
                                {
                                    rows["PRODUCT_NAME"] = product.NAME;
                                }                                
                                rows["MODEL_NUMBER"] = product.SPEC + " " + product.MODEL_NUMBER;
                            }
                        }
                        rows["QUANTITY"] = OLModel.QUANTITY;
                        rows["PRICE"] = OLModel.PRICE;
                        rows["AMOUNT_WITHOUT_TAX"] = OLModel.AMOUNT_INCLUDED_TAX;
                        dt.Rows.Add(rows);
                    }
                    ht.Add("&AMOUNT_WITHOUT_TAX", AMOUNT_WITHOUT_TAX);
                    ht.Add("&ORDER_AMOUNT", ORDER_AMOUNT);

                    SaveFileDialog sf = new SaveFileDialog();
                    sf.FileName = "LZ_PURCHASE_OVERSEAS_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    sf.Filter = "(文件)|*.xls;*.xlsx";

                    if (sf.ShowDialog(this) == DialogResult.OK)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            int ret = CommonExport.ExportPurchaseOverseas(@"rpt\purchase_overseas.xls", sf.FileName, dt, ht);
                            if (CConstant.EXPORT_FAILURE.Equals(ret))
                            {
                                MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_SUCCESS.Equals(ret))
                            {
                                MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (CConstant.EXPORT_RUNNING.Equals(ret))
                            {
                                MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
                            {
                                MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    #endregion
                }

            }
            else
            {
                MessageBox.Show("请选择一行!");
            }
        }
        #endregion
    }
}
