using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmShipment : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        public FrmShipment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmShipment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initDgvData();
        }

        private void initDgvData()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dgvData.Rows.Clear();
            PageSize = 16;
            dgvData.Rows.Add(PageSize);
            this.dgvData.Columns["SHIPMENT_CHK"].Visible = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Columns["SERIAL_NUMBER"].ReadOnly = true;
            dgvData.Columns["DEPARTUAL_DATE"].ReadOnly = true;
            dgvData.Columns["ARRIVAL_DATE"].ReadOnly = true;
            dgvData.Columns["SHIPMENT_QUANTITY"].ReadOnly = true;
        }

        /// <summary>
        ///  DataGridView的初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex >= 0 && (e.ColumnIndex == 4) && dgvData.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                row.Cells["SHIPMENT_QUANTITY"].Style.BackColor = System.Drawing.SystemColors.Info;

                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value))
                {
                    //Color color = Color.White;
                    //row.Cells["SLIP_NUMBER"].Style.SelectionBackColor = color;
                    //row.Cells["END_CUSTOMER_NAME"].Style.SelectionBackColor = color;
                    //row.Cells["SERIAL_NUMBER"].Style.SelectionBackColor = color;
                    //row.Cells["DEPARTUAL_DATE"].Style.SelectionBackColor = color;
                    //row.Cells["ARRIVAL_DATE"].Style.SelectionBackColor = color;
                    //row.Cells["CHECK_NUMBER"].Style.SelectionBackColor = color;
                    //row.Cells["CUSTOMER_PO_NUMBER"].Style.SelectionBackColor = color;

                    row.Cells["SERIAL_NUMBER"].ReadOnly = true;
                    row.Cells["DEPARTUAL_DATE"].ReadOnly = true;
                    row.Cells["ARRIVAL_DATE"].ReadOnly = true;
                    row.Cells["CUSTOMER_PO_NUMBER"].ReadOnly = true;
                    row.Cells["CHECK_NUMBER"].ReadOnly = true;
                }
                else
                {
                    //row.DefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                    Color color = COLOR_INFO;
                    row.Cells["SERIAL_NUMBER"].Style.BackColor = color;
                    row.Cells["DEPARTUAL_DATE"].Style.BackColor = color;
                    row.Cells["ARRIVAL_DATE"].Style.BackColor = color;
                    row.Cells["CUSTOMER_PO_NUMBER"].Style.BackColor = color;
                    row.Cells["CHECK_NUMBER"].Style.BackColor = color;

                    row.Cells["SERIAL_NUMBER"].ReadOnly = false;
                    row.Cells["DEPARTUAL_DATE"].ReadOnly = false;
                    row.Cells["ARRIVAL_DATE"].ReadOnly = false;
                    row.Cells["CUSTOMER_PO_NUMBER"].ReadOnly = false;
                    row.Cells["CHECK_NUMBER"].ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// DataGridView输入数据验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 入库数据的查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            BindData(true);
        }

        /// <summary>
        /// BindData
        /// </summary>
        /// <param name="isShowMessage"></param>
        public void BindData(bool isShowMessage)
        {
            DataTable dt = bShipment.GetShipmentPlanList(GetConduction()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgvData.Rows.Clear();
                this.dgvData.Columns["SHIPMENT_CHK"].Visible = true;
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                int i = 1;
                string currentSlipNumber = "";

                foreach (DataRow dr in dt.Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                    dgvr.Cells["NO"].Value = i++;
                    string slipNumber = CConvert.ToString(dr["SLIP_NUMBER"]);
                    if (currentSlipNumber == "" || currentSlipNumber != slipNumber)
                    {
                        currentSlipNumber = slipNumber;
                        dgvr.Cells["SLIP_NUMBER"].Value = slipNumber;
                        dgvr.Cells["END_CUSTOMER_NAME"].Value = dr["ENDER_CUSTOMER_NAME"];
                        dgvr.Cells["SERIAL_NUMBER"].Value = dr["SERIAL_NUMBER"];
                        dgvr.Cells["DEPARTUAL_DATE"].Value = CConvert.DateTimeToString(dr["DEPARTUAL_DATE"], "yyyy-MM-dd");
                        dgvr.Cells["ARRIVAL_DATE"].Value = CConvert.DateTimeToString(dr["DUE_DATE"], "yyyy-MM-dd");
                        dgvr.Cells["CHECK_NUMBER"].Value = dr["CHECK_NUMBER"];
                        dgvr.Cells["CUSTOMER_PO_NUMBER"].Value = dr["CUSTOMER_PO_NUMBER"];
                    }
                    dgvr.Cells["PRODUCT_CODE"].Value = dr["PRODUCT_CODE"];
                    dgvr.Cells["PRODUCT_NAME"].Value = dr["PRODUCT_NAME"];
                    dgvr.Cells["ORDER_QUANTITY"].Value = dr["QUANTITY"];
                    dgvr.Cells["ALLOATION_QUANTITY"].Value = dr["ALLOATION_QUANTITY"];
                    dgvr.Cells["SHIPMENT_QUANTITY"].Value = dr["ALLOATION_QUANTITY"];


                    dgvr.Cells["UNIT_CODE"].Value = dr["UNIT_CODE"];
                    dgvr.Cells["UNIT_NAME"].Value = dr["UNIT_NAME"];
                    dgvr.Cells["WAREHOUSE_CODE"].Value = dr["ALLOATION_WAREHOUSE_CODE"];
                    dgvr.Cells["WAREHOUSE_NAME"].Value = dr["ALLOATION_WAREHOUSE_NAME"];

                    dgvr.Cells["TRUE_SLIP_NUMBER"].Value = slipNumber;
                    dgvr.Cells["LINE_NUMBER"].Value = dr["LINE_NUMBER"];
                    dgvr.Cells["CURRENCY_CODE"].Value = dr["CURRENCY_CODE"];
                    dgvr.Cells["LINE_MEMO"].Value = dr["LINE_MEMO"];
                    dgvr.Cells["TAX_RATE"].Value = dr["TAX_RATE"];
                    dgvr.Cells["PRICE"].Value = dr["PRICE"];
                    dgvr.Cells["SHIPMENT_DEPOSIT"].Value = dr["SHIPMENT_DEPOSIT"];
                    dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value = dr["AMOUNT_INCLUDED_TAX"];
                }
            }
            else
            {
                if (isShowMessage)
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                initDgvData();
            }

            ReSetDataGridView("");
        }

        /// <summary>
        /// 查询条件的准备
        /// </summary>
        /// <returns></returns>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" ALLOATION_QUANTITY <> 0 and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            sb.AppendFormat(" AND COMPANY_CODE ='{0}'", UserTable.COMPANY_CODE);
            //sb.AppendFormat(" and VERIFY_FLAG = {0}", CConstant.VERIFY);

            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER LIKE  '{0}%'", txtCustomerPoNumber.Text.Trim());
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
            return sb.ToString();
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }

        /// <summary>
        /// 出库确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["SHIPMENT_CHK"].Value))
                {
                    if (!Convert.ToBoolean(dgvr.Cells["SHIPMENT_FLAG"].Value))
                    {
                        MessageBox.Show("出库条件未满足，请检查订单信息（审查编号，机械编号，合同编号，预付款）。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (CConvert.ToDecimal(dgvr.Cells["SHIPMENT_QUANTITY"].Value) > 0)
                    {
                        string slipNumber = CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value);

                        //预付金额
                        decimal DepositAmount = (new BDepositArr()).GetArrAmount(slipNumber);
                        try
                        {
                            if (CConvert.ToDecimal(dgvr.Cells["SHIPMENT_DEPOSIT"].Value) / 100 > DepositAmount / CConvert.ToDecimal(dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value))
                            {
                                MessageBox.Show("出库时预付款金额未支付或支付不足。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
            }

            if (MessageBox.Show("确定要出库吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<BllShipmentTable> datas = new List<BllShipmentTable>();
                BllShipmentTable shipmentTable = null;
                DateTime currentDate = DateTime.Now;
                string currentSlipNumber = "";
                int i = 1;
                decimal totalAmount = 0;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["SHIPMENT_CHK"].Value) && CConvert.ToDecimal(row.Cells["SHIPMENT_QUANTITY"].Value) > 0)
                    {
                        string slipNumber = CConvert.ToString(row.Cells["TRUE_SLIP_NUMBER"].Value);

                        if (currentSlipNumber != slipNumber)
                        {
                            if (currentSlipNumber != "")
                            {
                                shipmentTable.AMOUNT = totalAmount;
                                shipmentTable.AMOUNT_INCLUDED_TAX = totalAmount;

                                shipmentTable.AMOUNT_WITHOUT_TAX = WithoutAmount(totalAmount, shipmentTable.TAX_RATE);
                                shipmentTable.TAX_AMOUNT = totalAmount - shipmentTable.AMOUNT_WITHOUT_TAX;
                                datas.Add(shipmentTable);
                                totalAmount = 0;
                            }
                            currentSlipNumber = slipNumber;
                            shipmentTable = new BllShipmentTable();
                            i = 1;
                            shipmentTable.ORDER_SLIP_NUMBER = slipNumber;

                            shipmentTable.SERIAL_NUMBER = CConvert.ToString(row.Cells["SERIAL_NUMBER"].Value);
                            shipmentTable.SLIP_DATE = currentDate;
                            shipmentTable.ARRIVAL_DATE = CConvert.ToDateTime(row.Cells["DEPARTUAL_DATE"].Value);
                            shipmentTable.TAX_RATE = CConvert.ToDecimal(row.Cells["TAX_RATE"].Value);

                            shipmentTable.CURRENCY_CODE = CConvert.ToString(row.Cells["CURRENCY_CODE"].Value);
                            shipmentTable.STATUS_FLAG = CConstant.INIT_STATUS;
                            shipmentTable.CREATE_USER = UserTable.CODE;
                            shipmentTable.LAST_UPDATE_USER = UserTable.CODE;
                            shipmentTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                            shipmentTable.CHECK_NUMBER = CConvert.ToString(row.Cells["CHECK_NUMBER"].Value);
                            shipmentTable.CUSTOMER_PO_NUMBER = CConvert.ToString(row.Cells["CUSTOMER_PO_NUMBER"].Value);
                        }
                        BllShipmentLineTable shipmentLineTable = new BllShipmentLineTable();
                        shipmentLineTable.LINE_NUMBER = i++;
                        shipmentLineTable.ORDER_LINE_NUMBER = CConvert.ToInt32(row.Cells["LINE_NUMBER"].Value);
                        shipmentLineTable.DEPARTUAL_WAREHOUSE_CODE = CConvert.ToString(row.Cells["WAREHOUSE_CODE"].Value);
                        shipmentLineTable.PRODUCT_CODE = CConvert.ToString(row.Cells["PRODUCT_CODE"].Value);
                        shipmentLineTable.QUANTITY = CConvert.ToDecimal(row.Cells["SHIPMENT_QUANTITY"].Value);
                        shipmentLineTable.UNIT_CODE = CConvert.ToString(row.Cells["UNIT_CODE"].Value);
                        shipmentLineTable.PRICE = CConvert.ToDecimal(row.Cells["PRICE"].Value);
                        shipmentLineTable.AMOUNT = shipmentLineTable.QUANTITY * shipmentLineTable.PRICE;
                        shipmentLineTable.MEMO = CConvert.ToString(row.Cells["LINE_MEMO"].Value);
                        shipmentLineTable.STATUS_FLAG = CConstant.INIT_STATUS;
                        totalAmount += CConvert.ToDecimal(shipmentLineTable.PRICE * shipmentLineTable.QUANTITY);
                        shipmentTable.AddItems(shipmentLineTable);
                    }
                }

                if (shipmentTable != null)
                {
                    shipmentTable.AMOUNT = totalAmount;
                    shipmentTable.AMOUNT_INCLUDED_TAX = totalAmount;
                    shipmentTable.AMOUNT_WITHOUT_TAX = WithoutAmount(totalAmount, shipmentTable.TAX_RATE);
                    shipmentTable.TAX_AMOUNT = totalAmount - shipmentTable.AMOUNT_WITHOUT_TAX;
                    datas.Add(shipmentTable);
                }

                //数据表的更新
                if (datas.Count > 0)
                {
                    try
                    {
                        int ret = bShipment.Add(datas);
                        if (ret > 0)
                        {
                            MessageBox.Show("出库确认成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData(false);
                        }
                        else
                        {
                            MessageBox.Show("出库确认失败，请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("出库确认失败，请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("出库确认失败。", ex);
                    }

                }
                else
                {
                    MessageBox.Show("请先择需要出库的数据,或出库数量小于等于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

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

        /// <summary>
        /// 控制空行不能被选中
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["TRUE_SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }

        /// <summary>
        /// DataGridView 数据输入验证
        /// </summary>
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["SERIAL_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["SERIAL_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("机械番号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["SERIAL_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["CHECK_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["CHECK_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("审查编号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["CHECK_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["CUSTOMER_PO_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["CUSTOMER_PO_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("合同编号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["CUSTOMER_PO_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["DEPARTUAL_DATE"].Index)
                {
                    string departualDate = CConvert.ToString(dgvr.Cells["DEPARTUAL_DATE"].Value);
                    if (departualDate != "")
                    {
                        DateTime dTime = DateTime.Now;
                        try
                        {
                            dTime = DateTime.Parse(departualDate);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的出库日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dgvr.Cells["DEPARTUAL_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }

                }
                else if (e.ColumnIndex == dgvData.Columns["ARRIVAL_DATE"].Index)
                {
                    string arrivalDate = CConvert.ToString(dgvr.Cells["ARRIVAL_DATE"].Value);
                    if (arrivalDate != "")
                    {
                        DateTime dTime = DateTime.Now;
                        try
                        {
                            dTime = DateTime.Parse(arrivalDate);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的纳入预定日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dgvr.Cells["ARRIVAL_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }

                }
                else if (e.ColumnIndex == dgvData.Columns["SHIPMENT_QUANTITY"].Index)
                {
                    string shipmentQuantity = CConvert.ToString(dgvr.Cells["SHIPMENT_QUANTITY"].Value);
                    decimal alloationQuantity = CConvert.ToDecimal(dgvr.Cells["ALLOATION_QUANTITY"].Value);

                    if (CConvert.ToDecimal(shipmentQuantity) < 0)
                    {
                        MessageBox.Show("出库数量不能为负数。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["SHIPMENT_QUANTITY"].Value = 1;
                    }
                    else if (CConvert.ToDecimal(shipmentQuantity) == 0)
                    {
                        try
                        {
                            decimal.Parse(shipmentQuantity);
                            MessageBox.Show("出库数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的出库数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        finally
                        {
                            dgvr.Cells["SHIPMENT_QUANTITY"].Value = 1;
                        }
                    }
                    else if (alloationQuantity < CConvert.ToDecimal(shipmentQuantity))
                    {
                        MessageBox.Show("出库数量不能大于引当数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["SHIPMENT_QUANTITY"].Value = alloationQuantity;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Error("CellValidated error!", ex);
            }
        }

        /// <summary>
        /// DataGridView输入控制
        /// </summary>
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!this.HasAttachEvent) // 注册事件
            {
                e.Control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "SHIPMENT_QUANTITY")
                    {
                        InputDouble(o, c);
                    }
                    else
                    {
                        return;
                    }
                });
                this.HasAttachEvent = true;
            }
        }

        /// <summary>
        /// 显示数据的重新整理
        /// </summary>
        private void ReSetDataGridView(string slipNumber)
        {
            string currentSlipNumber = "";
            bool shipmentFlag = true;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (dgvr.Cells[0].Value == null || "".Equals(dgvr.Cells[0].Value))
                {
                    break;
                }

                if (!"".Equals(slipNumber) && !slipNumber.Equals(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value)))
                {
                    continue;
                }

                if (!currentSlipNumber.Equals(dgvr.Cells["TRUE_SLIP_NUMBER"].Value))
                {
                    currentSlipNumber = CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value);
                    //check
                    shipmentFlag = true;

                    //机械本体订单的判断
                    bool isMechanicalBase = bOrderHeader.IsMechanicalBaseOrder(currentSlipNumber);

                    if ("".Equals(CConvert.ToString(dgvr.Cells["SERIAL_NUMBER"].Value)) && isMechanicalBase)
                    {
                        shipmentFlag = false;
                    }
                    else if ("".Equals(CConvert.ToString(dgvr.Cells["CHECK_NUMBER"].Value)) && isMechanicalBase)
                    {
                        shipmentFlag = false;
                    }
                    else if ("".Equals(CConvert.ToString(dgvr.Cells["CUSTOMER_PO_NUMBER"].Value)))
                    {
                        shipmentFlag = false;
                    }
                    else
                    {
                        //预付金额
                        decimal DepositAmount = (new BDepositArr()).GetArrAmount(currentSlipNumber);
                        try
                        {
                            if (CConvert.ToDecimal(dgvr.Cells["SHIPMENT_DEPOSIT"].Value) / 100 > DepositAmount / CConvert.ToDecimal(dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value))
                            {
                                shipmentFlag = false;
                            }
                        }
                        catch (Exception ex) { }
                    }
                }

                if (shipmentFlag)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgvr.DefaultCellStyle.BackColor = COLOR_NG;
                }
                dgvr.Cells["SHIPMENT_FLAG"].Value = shipmentFlag;

            }
        }

    }//end class
}
