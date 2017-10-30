using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using System.Collections;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOrdersSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        public BllOrderHeaderTable orderTable = new BllOrderHeaderTable();
        private bool isSearch = false;
        private string _currentConduction = "";
        private string _company_code;

        public string COMPANY
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        public FrmOrdersSearch()
        {
            InitializeComponent();
        }

        #region init
        private void FrmOrdersSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            btnPrint.Visible = false;

            #region 订单类型的初始化
            //订单类型的初始化  
            DataTable ostDT = CCacheData.OrderSlipType.Copy();
            DataRow dr = ostDT.NewRow();
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            ostDT.Rows.InsertAt(dr, 0);
            cboSlipType.ValueMember = "CODE";
            cboSlipType.DisplayMember = "NAME";
            cboSlipType.DataSource = ostDT;
            #endregion

            //订单查询 
            if (CConstant.ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "详细确认";
                btnPrint.Enabled = true;
                btnPrint.Visible = true;
                btnExport.Visible = true;
                rdoAllowance.Checked = true;
            }
            //在库引当
            if (CConstant.ORDER_ALLOATION.Equals(CTag))
            {
                this.Text = "在库引当";
                btnOperate.Text = "在库引当";
                rdoAllowanceNo.Checked = true;
            }
            //订单修正    
            else if (CConstant.ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "订单修正";
                btnOperate.Text = "修  正";
                rdoAllowance.Checked = true;
            }
            //订单承认        
            else if (CConstant.ORDER_VERIFY.Equals(CTag))
            {
                this.Text = "订单承认";
                btnOperate.Text = "承  认";
                rdoAllowance.Checked = true;
            }
            //复制订单     
            else if (CConstant.ORDER_COPY.Equals(CTag))
            {
                this.Text = "复制订单";
                btnOperate.Text = "复制订单";
                rdoAllowance.Checked = true;
            }
            //订单查询
            else if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "确　认";
                btnPrint.Visible = false;
                rdoAllowance.Checked = true;

                dgvData.Columns["UPDATED_COUNT"].Visible = false;
                dgvData.Columns["ATTACHED_NAME"].Visible = false;
            }
            //订单修理输入
            else if (CConstant.ORDER_SERVICE.Equals(CTag))
            {
                this.Text = "订单修理";
                btnOperate.Text = "修　理";
                dgvData.Columns["SERVICE_TITLE"].Visible = true;
                btnPrint.Visible = false;
                rdoAllowance.Checked = true;
            }

            init();
            PageSize = 10;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            #endregion
        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            int recordCount = bOrderHeader.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnExport.Enabled = false;
                btnPrint.Enabled = false;
                btnOperate.Enabled = false;
                isSearch = false;
            }
            else
            {
                btnExport.Enabled = true;
                btnPrint.Enabled = true;
                btnOperate.Enabled = true;
                isSearch = true;
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);

        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bOrderHeader.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            _currentDt.Columns.Add("VERIFY_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("ATTACHED_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("ALLOATION_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SHIPMENT_NAME", Type.GetType("System.String"));
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
        }


        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                sb.AppendFormat(" AND COMPANY_CODE ='{0}'", COMPANY);
            }
            else
            {
                sb.AppendFormat(" AND COMPANY_CODE ='{0}'", UserTable.COMPANY_CODE);
            }
            //订单类型
            if (cboSlipType.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND SLIP_TYPE = '{0}'", cboSlipType.SelectedValue);
            }
            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //代理店
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_CODE = '{0}'", txtCustomerCode.Text.Trim());
            }
            //需要家
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND ENDER_CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //纳入先
            if (!string.IsNullOrEmpty(txtDeliveryPointCode.Text.Trim()))
            {
                sb.AppendFormat(" AND DELIVERY_POINT_CODE = '{0}'", txtDeliveryPointCode.Text.Trim());
            }
            //出库仓库
            if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                sb.AppendFormat(" AND DEPARTUAL_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }
            //机品编号
            if (!string.IsNullOrEmpty(txtSerialNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SERIAL_NUMBER = '{0}'", txtSerialNumber.Text.Trim());
            }
            //本社订单编号
            if (!string.IsNullOrEmpty(txtOwnerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND OWNER_PO_NUMBER = '{0}'", txtOwnerPoNumber.Text.Trim());
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER = '{0}'", txtCustomerPoNumber.Text.Trim());
            }
            //订单日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //订单日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库预定日期From
            if (this.txtDepartualDateFrom.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE >= '{0}'", txtDepartualDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.txtDepartualDateTo.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE < '{0}'", txtDepartualDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库状况
            if (rdolibraryOk.Checked)
            {
                sb.Append(" AND QUANTITY = SHIPMENT_QUANTITY ");
            }
            else if (rdolibraryNo.Checked)
            {
                sb.Append(" AND QUANTITY <> SHIPMENT_QUANTITY ");
            }

            //引当状况
            if (rdoAllowanceOk.Checked)
            {
                sb.AppendFormat(" AND ALLOATION_FLAG = '{0}'", CConstant.ALLOATION_COMPLETE);
            }
            else if (rdoAllowanceNo.Checked)
            {
                sb.AppendFormat(" AND (ALLOATION_FLAG = '{0}' OR ALLOATION_FLAG='{1}')", CConstant.ALLOATION_UN, CConstant.ALLOATION_PART);
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
            _currentDt.Columns.Add("SHIPMENT_FLAG", Type.GetType("System.Int32"));

            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                _currentDt.Rows[i]["No"] = _currentDt.Rows[i]["ROW"];

                #region　承认
                if (CConstant.VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "承认";
                }
                else if (CConstant.NO_VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "不承认";
                }
                else
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "未承认";
                }
                #endregion

                #region　附件
                if (CConstant.EXIST_ATTACHED.Equals(_currentDt.Rows[i]["ATTACHED_FLAG"]))
                {
                    _currentDt.Rows[i]["ATTACHED_NAME"] = "有";
                }
                else
                {
                    _currentDt.Rows[i]["ATTACHED_NAME"] = "无";
                }
                #endregion

                #region　引当
                if (CConstant.ALLOATION_COMPLETE.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "完了";
                }
                else if (CConstant.ALLOATION_PART.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "欠品";
                }
                else
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "未引当";
                }
                #endregion

                #region　出库
                if (CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]) == 0)
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "未出库";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.UN_SHIPMENT;
                }
                else if (CConvert.ToDecimal(_currentDt.Rows[i]["QUANTITY"]) != CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]))
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "欠品";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.PART_SHIPMENT;
                }
                else
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "完了";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.COMPLETE_SHIPMENT;
                }
                #endregion
            }


            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }
        #endregion

        #region 详细
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                string companyCode = CConvert.ToString(row.Cells["COMPANY_CODE"].Value);
                decimal amountIncludedTax = CConvert.ToDecimal(row.Cells["AMOUNT_INCLUDED_TAX"].Value);
                DateTime slipDate = CConvert.ToDateTime(row.Cells["SLIP_DATE"].Value);

                //在库引当
                if (CConstant.ORDER_ALLOATION.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                {
                    FrmBase frm = new FrmAlloation(slipNumber);
                    frm.UserTable = _userInfo;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                }
                //修理输入
                else if (CConstant.ORDER_SERVICE.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                {
                    FrmBase frm = new FrmOrderService(slipNumber);
                    frm.UserTable = _userInfo;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                }
                else
                {
                    FrmBase frm = new FrmOrdersEntry(slipNumber);
                    frm.CTag = CTag;
                    frm.UserTable = _userInfo;
                    //详细信息
                    if (CConstant.ORDER_SEARCH.Equals(CTag))
                    {
                        if (DialogResult.OK == frm.ShowDialog())
                        {

                        }
                        frm.Dispose();
                    }

                    //订单修正    
                    else if (CConstant.ORDER_MODIFY.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                    {
                        //承认后不能修改
                        //if (CConstant.VERIFY.Equals(CConvert.ToInt32(row.Cells["VERIFY_FLAG"].Value)))
                        //{
                        //    MessageBox.Show("订单己经承认，不能修改。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        if (CConstant.COMPLETE_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经出库完了，不能修正。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.PART_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经有出库，不能修正。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (DialogResult.OK == frm.ShowDialog())
                            {
                                BindData(this.pgControl.GetCurrentPage());
                            }
                            frm.Dispose();
                        }
                    }
                    //订单承认        
                    else if (CConstant.ORDER_VERIFY.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                    {
                        if (CConstant.COMPLETE_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经出库完了，不能修改承认状态。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.PART_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经有出库，不能修改承认状态。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (DialogResult.OK == frm.ShowDialog())
                        {
                            BindData(this.pgControl.GetCurrentPage());
                        }
                        frm.Dispose();
                    }
                    //复制订单     
                    else if (CConstant.ORDER_COPY.Equals(CTag))
                    {
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            BindData(this.pgControl.GetCurrentPage());
                        }
                        frm.Dispose();
                    }
                    //详细信息
                    else if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
                    {
                        orderTable.SLIP_NUMBER = slipNumber;
                        orderTable.AMOUNT_INCLUDED_TAX = amountIncludedTax;
                        orderTable.SLIP_DATE = slipDate;
                        this.DialogResult = DialogResult.OK;
                        frm.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }

        #region datagridview 行点击事件
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["ATTACHED_NAME"].Index)
                {
                    if (CConvert.ToInt32(row.Cells["ATTACHED_FLAG"].Value) > 0)
                    {
                        string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
                        string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                        FrmAttached frm = new FrmAttached(slipNumber, attachedDirectory, true);
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["UPDATED_COUNT"].Index)
                {
                    if (CConvert.ToInt32(row.Cells["UPDATED_COUNT"].Value) > 0)
                    {
                        FrmHistoryOrderList frm = new FrmHistoryOrderList(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                        if (DialogResult.OK == frm.ShowDialog(this))
                        {
                            FrmBase frmOrder = new FrmOrdersEntry(frm.historySlipNumber);
                            frmOrder.CTag = CConstant.ORDER_HISTORY;
                            frmOrder.UserTable = _userInfo;
                            frmOrder.ShowDialog();
                        }
                    }
                }
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
            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode, "TYPE = 1");
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("代理店不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";
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
                    txtDeliveryPointCode.Focus();
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

        #region 导出
        /// <summary>
        /// 
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bOrderHeader.GetPrintList(_currentConduction).Tables[0];
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                #region　引当
                if (CConstant.ALLOATION_COMPLETE.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "完了";
                }
                else if (CConstant.ALLOATION_PART.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "欠品";
                }
                else
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "未引当";
                }
                #endregion

                #region　出库
                if (CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]) == 0)
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "未出库";
                }
                else if (CConvert.ToDecimal(_currentDt.Rows[i]["QUANTITY"]) != CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]))
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "欠品";
                }
                else
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "完了";
                }
                #endregion
            }
            if (_currentDt != null)
            {
                int result = CommonExport.DataTableToExcel(_currentDt, CConstant.ORDER_HEADER, CConstant.ORDER_COLUMNS, "ORDER", "ORDER");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 导出审查表
        /// <summary>
        /// 导出审查表
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                Hashtable ht = new Hashtable();
                BaseCustomerTable customerTable = new BCustomer().GetModel(CConvert.ToString(row.Cells["CUSTOMER_CODE"].Value));
                BaseCustomerTable endcustomerTable = new BCustomer().GetModel(CConvert.ToString(row.Cells["ENDER_CUSTOMER_CODE"].Value));
                if (customerTable == null)
                {
                    customerTable = new BaseCustomerTable();
                }
                if (endcustomerTable == null)
                {
                    endcustomerTable = new BaseCustomerTable();
                }
                ht.Add("&CUSTOMER_NAME", customerTable.NAME);
                ht.Add("&NAME_ENGLSIH", customerTable.NAME_ENGLISH);
                ht.Add("&CONTACT_NAME", customerTable.CONTACT_NAME);
                ht.Add("&A", customerTable.MEMO2);
                ht.Add("&MEMO", customerTable.MEMO);
                ht.Add("&ORDER_MEMO", row.Cells["MEMO"].Value);
                ht.Add("&END_CUSTOMER_NAME", endcustomerTable.NAME);
                ht.Add("&END_NAME_ENGLISH", endcustomerTable.NAME_ENGLISH);
                ht.Add("&END_CONTACT_NAME", endcustomerTable.CONTACT_NAME);
                ht.Add("&END_MEMO2", endcustomerTable.MEMO2);
                ht.Add("&END_MEMO", endcustomerTable.MEMO);
                ht.Add("&SLIP_NUMBER", row.Cells["SLIP_NUMBER"].Value);

                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "LZ_ORDER_REVIEW_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    int ret = CommonExport.ExportReView(@"rpt\review.xls", sf.FileName, ht);
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
            }
            else
            {
                MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion


    }//end class
}
