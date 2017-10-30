using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmMasterMachineDialog : Form
    {
        private BMasterMachine bMasterMachine = new BMasterMachine();
        private BCommon bCommon = new BCommon();
        private BaseUserTable _userInfo;
        private BaseMasterMachineTable _currentMasterMachineTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseMasterMachineTable CurrentMasterMachineTable
        {
            get { return _currentMasterMachineTable; }
            set { _currentMasterMachineTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmMasterMachineDialog()
        {
            InitializeComponent();
        }

        #region 初始化
        private void FrmMasterMachineDialog_Load(object sender, EventArgs e)
        {
            #region 维修地点初始化
            try
            {
                cboMaintenanceStations.ValueMember = "CODE";
                cboMaintenanceStations.DisplayMember = "NAME";
                cboMaintenanceStations.DataSource = CCacheData.Stations;
            }
            catch { }
            #endregion

            if (_currentMasterMachineTable != null)
            {
                txtMachineCode.Text = _currentMasterMachineTable.MACHINE_CODE;
                txtMachineName.Text = _currentMasterMachineTable.MACHINE_NAME;
                txtCustomerCode.Text = _currentMasterMachineTable.CUSTOMER_CODE;
                if (!string.IsNullOrEmpty(_currentMasterMachineTable.CUSTOMER_CODE))
                {
                    txtCustomerName.Text = bCommon.GetBaseMaster("CUSTOMER", _currentMasterMachineTable.CUSTOMER_CODE).Name;
                }
                txtProductCode.Text = _currentMasterMachineTable.PRODUCT_CODE;
                if (!string.IsNullOrEmpty(_currentMasterMachineTable.PRODUCT_CODE))
                {
                    txtProductName.Text = bCommon.GetBaseMaster("PRODUCT", _currentMasterMachineTable.PRODUCT_CODE).Name;
                }
                txtPurchaseOrderSlipNumber.Text = _currentMasterMachineTable.PURCHASE_ORDER_SLIP_NUMBER;
                txtFSerialNumber.Text = _currentMasterMachineTable.FANUC_SERIAL_NUMBER;
                txtFSlipNUmber.Text = _currentMasterMachineTable.FANUC_SLIP_NUMBER;
                txtReceiptDate.Value = _currentMasterMachineTable.RECEIPT_DATE;
                cboMaintenanceStations.SelectedValue = _currentMasterMachineTable.MAINTENANCE_STATIONS;
                txtPurchaseSlipNumber.Text = _currentMasterMachineTable.PURCHASE_SLIP_NUMBER;
                if (_currentMasterMachineTable.SALE_DATE_TIME != null)
                {
                    txtSaleTime.Checked = true;
                    txtSaleTime.Value = CConvert.ToDateTime(_currentMasterMachineTable.SALE_DATE_TIME);
                }
                else 
                {
                    txtSaleTime.Checked = false;
                }
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtMachineCode.BackColor = Color.WhiteSmoke;
                txtMachineCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtMachineCode.Text = "";
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentMasterMachineTable == null)
                {
                    _currentMasterMachineTable = new BaseMasterMachineTable();
                }
                _currentMasterMachineTable.MACHINE_CODE = txtMachineCode.Text;
                _currentMasterMachineTable.MACHINE_NAME = txtMachineName.Text;
                _currentMasterMachineTable.CUSTOMER_CODE = txtCustomerCode.Text;
                _currentMasterMachineTable.PRODUCT_CODE = txtProductCode.Text;
                _currentMasterMachineTable.PURCHASE_ORDER_SLIP_NUMBER = txtPurchaseOrderSlipNumber.Text;
                _currentMasterMachineTable.FANUC_SERIAL_NUMBER = txtFSerialNumber.Text;
                _currentMasterMachineTable.FANUC_SLIP_NUMBER = txtFSlipNUmber.Text;
                _currentMasterMachineTable.RECEIPT_DATE = txtReceiptDate.Value;
                _currentMasterMachineTable.MAINTENANCE_STATIONS = CConvert.ToString(cboMaintenanceStations.SelectedValue);
                _currentMasterMachineTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentMasterMachineTable.PURCHASE_SLIP_NUMBER = txtPurchaseSlipNumber.Text;
                if (txtSaleTime.Checked)
                {
                    _currentMasterMachineTable.SALE_DATE_TIME = txtSaleTime.Value;
                }
                try
                {
                    if (bMasterMachine.Exists(txtMachineCode.Text.Trim()))
                    {
                        bMasterMachine.Update(_currentMasterMachineTable);
                    }
                    else
                    {
                        _currentMasterMachineTable.CREATE_USER = _userInfo.CODE;
                        bMasterMachine.Add(_currentMasterMachineTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                result = DialogResult.OK;
                this.Close();
            }
        }

        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断编号不能为空
            if (string.IsNullOrEmpty(this.txtMachineCode.Text.Trim()))
            {
                strErrorlog += "机械编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtMachineName.Text.Trim()))
            {
                strErrorlog += "机械名称不能为空!\r\n";
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }
        /// <summary>
        /// 关闭后返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMasterMachineDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion

        #region 按键
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (btnSave.Focused)
                {
                    cboMaintenanceStations.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (btnCancel.Focused)
                {
                    txtMachineCode.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }
        #endregion

        #region 需要家
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    txtProductCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            string CustomerCode = txtCustomerCode.Text.Trim();
            if (CustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", CustomerCode);
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("代理店不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 商品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    cboMaintenanceStations.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            string ProductCode = txtProductCode.Text.Trim();
            if (ProductCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", ProductCode);
                if (baseMaster != null)
                {
                    txtProductCode.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("代理店不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtProductCode.Focus();
                }
            }
            else
            {
                txtProductName.Text = "";
            }
        }
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }
        #endregion

        private void txtMachineCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMachineCode.Text.Trim()))
            {
                BaseMasterMachineTable MCode = new BaseMasterMachineTable();
                MCode = bMasterMachine.GetModel(this.txtMachineCode.Text.Trim());
                if (MCode != null)
                {
                    txtMachineCode.Focus();
                    txtMachineCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}
