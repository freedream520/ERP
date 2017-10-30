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
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSupplierDialog : Form
    {


        private BSupplier bSupplier = new BSupplier();
        private BaseUserTable _userInfo;
        private BaseSupplierTable _currentSupplierTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
       

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        /// <summary>
        /// 当前数据
        /// </summary>
        public BaseSupplierTable CurrentSupplierTable
        {
            get { return _currentSupplierTable; }
            set { _currentSupplierTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmSupplierDialog()
        {
            InitializeComponent();
        }

        private void FrmSupplierDialog_Load(object sender, EventArgs e)
        {
            if (_currentSupplierTable != null)
            {

                txtCode.Text = _currentSupplierTable.CODE;
                txtName.Text = _currentSupplierTable.NAME;
                txtNameShort.Text = _currentSupplierTable.NAME_SHORT;
                txtEnglishName.Text = _currentSupplierTable.NAME_ENGLISH;
                txtZipCode.Text = _currentSupplierTable.ZIP_CODE;
                txtAddressFirst.Text = _currentSupplierTable.ADDRESS_FIRST;
                txtAddressMiddle.Text = _currentSupplierTable.ADDRESS_MIDDLE;
                txtAddressLast.Text = _currentSupplierTable.ADDRESS_LAST;
                txtPhone.Text = _currentSupplierTable.PHONE_NUMBER;
                txtFax.Text = _currentSupplierTable.FAX_NUMBER;
                txtMobilNumber.Text = _currentSupplierTable.MOBIL_NUMBER;
                txtContactName.Text = _currentSupplierTable.CONTACT_NAME;
                txtEmail.Text = _currentSupplierTable.EMAIL;
                txtURL.Text = _currentSupplierTable.URL;
                txtMemo.Text = _currentSupplierTable.MEMO;
                txtClaimCode.Text = _currentSupplierTable.CLAIM_CODE;
                txtCurrencyCode.Text = _currentSupplierTable.CURRENCE_CODE;
                txtCurrencyName.Text = _currentSupplierTable.CURRENCE_NAME;

                if (_currentSupplierTable.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                {
                    rType1.Checked = true;
                }
                else {
                    rType2.Checked = true;
                }

                if(_currentSupplierTable.CLAIM_FLAG ==1 )
                {
                    rClaim1.Checked = true;
                }
                else
                {
                    rClaim2.Checked = true;
                    txtClaimCode.Enabled = true;
                }
                
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCode.BackColor = Color.WhiteSmoke;
                txtCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCode.Text = "";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentSupplierTable == null)
                {
                    _currentSupplierTable = new BaseSupplierTable();
                }

                _currentSupplierTable.CODE = txtCode.Text;
                _currentSupplierTable.NAME = txtName.Text;
                _currentSupplierTable.NAME_SHORT = txtNameShort.Text;
                _currentSupplierTable.NAME_ENGLISH = txtEnglishName.Text;
                _currentSupplierTable.ZIP_CODE = txtZipCode.Text;
                _currentSupplierTable.ADDRESS_FIRST = txtAddressFirst.Text;
                _currentSupplierTable.ADDRESS_MIDDLE = txtAddressMiddle.Text;
                _currentSupplierTable.ADDRESS_LAST = txtAddressLast.Text;
                _currentSupplierTable.PHONE_NUMBER = txtPhone.Text;
                _currentSupplierTable.FAX_NUMBER = txtFax.Text;
                _currentSupplierTable.MOBIL_NUMBER = txtMobilNumber.Text;
                _currentSupplierTable.CONTACT_NAME = txtContactName.Text;
                _currentSupplierTable.EMAIL = txtEmail.Text;
                _currentSupplierTable.URL = txtURL.Text;
                _currentSupplierTable.MEMO = txtMemo.Text;
                _currentSupplierTable.CLAIM_CODE = txtClaimCode.Text;
                _currentSupplierTable.CURRENCE_CODE = txtCurrencyCode.Text;
                _currentSupplierTable.LAST_UPDATE_USER = _userInfo.CODE;

                if (rType1.Checked)
                {
                    _currentSupplierTable.TYPE = 2;
                }
                else 
                {
                    _currentSupplierTable.TYPE = 1;
                }

                if (rClaim1.Checked)
                {
                    _currentSupplierTable.CLAIM_FLAG = 1;
                }
                else 
                {
                    _currentSupplierTable.CLAIM_FLAG = 2;
                }

                try
                {
                    if (bSupplier.Exists(txtCode.Text))
                    {
                        bSupplier.Update(_currentSupplierTable);
                    }
                    else
                    {
                        _currentSupplierTable.CREATE_USER = _userInfo.CODE;
                        bSupplier.Add(_currentSupplierTable);
                    }
                }
                catch (Exception ex)
                {
                    //log.error
                    MessageBox.Show("");
                    return;
                }
                result = DialogResult.OK;
                this.Close();
            }
           
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "名称不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtClaimCode.Text.Trim()))
            {
                strErrorlog += "付款编号不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
            {
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtNameShort.Text) > txtNameShort.MaxLength)
            {
                txtNameShort.Text = CTools.textSpilt(txtNameShort.Text, txtNameShort.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressFirst.Text) > txtAddressFirst.MaxLength)
            {
                txtAddressFirst.Text = CTools.textSpilt(txtAddressFirst.Text, txtAddressFirst.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressMiddle.Text) > txtAddressMiddle.MaxLength)
            {
                txtAddressMiddle.Text = CTools.textSpilt(txtAddressMiddle.Text, txtAddressMiddle.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressLast.Text) > txtAddressLast.MaxLength)
            {
                txtAddressLast.Text = CTools.textSpilt(txtAddressLast.Text, txtAddressLast.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtMemo.Text) > txtMemo.MaxLength)
            {
                txtMemo.Text = CTools.textSpilt(txtMemo.Text, txtMemo.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtContactName.Text) > txtContactName.MaxLength)
            {
                txtContactName.Text = CTools.textSpilt(txtContactName.Text, txtContactName.MaxLength);
            }

            return true;
        }

        /// <summary>
        /// 取消/关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmSupplierDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void btnCurrencyCode_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CURRENCY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCurrencyCode.Text = frm.BaseMasterTable.Code;
                    txtCurrencyName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void FrmSupplierDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtCode.Focus();
            }
            else
            {
                txtName.Focus();
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }

            if (txtPhone.Focused || txtFax.Focused || txtMobilNumber.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)45)
                {
                    e.Handled = true;
                }
            }

            if (txtZipCode.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseSupplierTable SupplierCode = new BaseSupplierTable();
                SupplierCode = bSupplier.GetModel(txtCode.Text);
                if (SupplierCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("供应商编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (rClaim1.Checked)
            {
                txtClaimCode.Text = txtCode.Text;
            }
        }

        private void txtCurrencyCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCurrencyCode.Text.Trim()))
            {
                BaseCurrencyTable Currency = new BaseCurrencyTable();
                BCurrency bCurrency = new BCurrency();
                Currency = bCurrency.GetModel(txtCurrencyCode.Text);
                if (Currency == null)
                {
                    txtCurrencyCode.Focus();
                    txtCurrencyCode.Text = "";
                    txtCurrencyName.Text = "";
                    MessageBox.Show("货币编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtCurrencyName.Text = Currency.NAME;
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                { }
                else if (txtClaimCode.Focused)
                {
                    txtMemo.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtCurrencyCode.Focused)
                { }
                else if (txtMemo.Focused)
                {
                    txtClaimCode.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(txtEmail.Text))
                {
                    txtEmail.Focus();
                    txtEmail.Text = "";
                    MessageBox.Show("邮箱格式不正确!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void rClaim1_Click(object sender, EventArgs e)
        {
            txtClaimCode.Enabled = false;
            txtClaimCode.Text = txtCode.Text;
        }

        private void rClaim2_Click(object sender, EventArgs e)
        {
            txtClaimCode.Text = "";
            txtClaimCode.Enabled = true;
        }

        private void txtClaimCode_Leave(object sender, EventArgs e)
        {
            BaseSupplierTable claim = new BaseSupplierTable();
            claim = bSupplier.GetModel(txtClaimCode.Text);
            if (claim == null)
            {
                txtClaimCode.Text = "";
                txtClaimCode.Focus();
                MessageBox.Show("付款公司编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
