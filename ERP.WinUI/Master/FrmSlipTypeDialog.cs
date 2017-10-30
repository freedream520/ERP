using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;


namespace CZZD.ERP.WinUI
{
    public partial class FrmSlipTypeDialog : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BaseUserTable _userInfo;
        private BaseSlipTypeTable _currentSlipTypeTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BSlipType bSlipType = new BSlipType();

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
        public BaseSlipTypeTable CurrentSlipTypeTable
        {
            get { return _currentSlipTypeTable; }
            set { _currentSlipTypeTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmSlipTypeDialog()
        {
            InitializeComponent();
        }

        private void FrmSlipTypeDialog_Load(object sender, EventArgs e)
        {
            #region 类型
            cboType.ValueMember = "CODE";
            cboType.DisplayMember = "NAME";
            cboType.DataSource = CCacheData.SlipType;
            CCacheData.SlipType = null;
            #endregion

            if (_currentSlipTypeTable != null)
            {
                cboType.SelectedValue = _currentSlipTypeTable.TYPE_CODE;
                txtCode.Text = _currentSlipTypeTable.CODE;
                txtName.Text = _currentSlipTypeTable.NAME;
                txtCompanyCode.Text = _currentSlipTypeTable.COMPANY_CODE;
                txtCompanyName.Text = _currentSlipTypeTable.COMPANY_NAME;
                txtIndicatesOrder.Text = CConvert.ToString(_currentSlipTypeTable.INDICATES_ORDER);
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                cboType.BackColor = Color.WhiteSmoke;
                txtCode.BackColor = Color.WhiteSmoke;
                cboType.Enabled = false;
                txtCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                cboType.Text = "";
                txtCode.Text = "";
            }
        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentSlipTypeTable == null)
                {
                    _currentSlipTypeTable = new BaseSlipTypeTable();
                }
                _currentSlipTypeTable.TYPE_CODE = cboType.SelectedValue.ToString();
                _currentSlipTypeTable.CODE = txtCode.Text;
                _currentSlipTypeTable.NAME = txtName.Text;
                _currentSlipTypeTable.COMPANY_CODE = txtCompanyCode.Text;
                _currentSlipTypeTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentSlipTypeTable.INDICATES_ORDER = CConvert.ToInt32(txtIndicatesOrder.Text);

                try
                {
                    if (bSlipType.Exists(cboType.SelectedValue.ToString(), txtCode.Text.Trim()))
                    {
                        bSlipType.Update(_currentSlipTypeTable);
                    }
                    else
                    {
                        _currentSlipTypeTable.CREATE_USER = _userInfo.CODE;
                        bSlipType.Add(_currentSlipTypeTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请重新输入!");
                    Logger.Error("订单类型保存失败!", ex);
                    return;
                }
                result = DialogResult.OK;
                this.Close();
                CCacheData.SlipType = null;
                CCacheData.PurchaseSlipType = null;
                CCacheData.OrderSlipType = null;
            }
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region 公司
        private void btnCompany_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("COMPANY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCompanyCode.Text = frm.BaseMasterTable.Code;
                    txtCompanyName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCompanyCode.Text.Trim()))
            {
                BaseCompanyTable company = new BaseCompanyTable();
                BCompany bCompany = new BCompany();
                company = bCompany.GetModel(txtCompanyCode.Text.Trim());
                if (company == null)
                {
                    txtCompanyCode.Text = "";
                    txtCompanyName.Text = "";
                    txtCompanyCode.Focus();
                    MessageBox.Show("公司编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtCompanyName.Text = company.NAME;
            }
        }
        #endregion

        private void FrmProductPartsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIndicatesOrder.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtIndicatesOrder.Focused)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
                else　 //以下为输入正确内容过虑
                {
                    //如果第一位输入0，则不接收
                    if (e.KeyChar == 48 && (((TextBox)sender).SelectionStart == 0))
                        e.Handled = true;
                    //如果是回车键，则按tab序进行跳转
                    if (e.KeyChar == 13)
                    {
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                    }
                    if (e.KeyChar == 8)
                    {
                        e.Handled = false;
                    }
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

        private void txtTypeCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!(cboType.Focused) && !(txtCode.Focused))
            {
                BaseSlipTypeTable SlipType = new BaseSlipTypeTable();
                SlipType = bSlipType.GetModel(cboType.SelectedValue.ToString(), txtCode.Text);
                if (SlipType != null)
                {
                    txtCode.Text = "";
                    cboType.Focus();
                    MessageBox.Show("类型和编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!(cboType.Focused) && !(txtCode.Focused))
            {
                BaseSlipTypeTable SlipType = new BaseSlipTypeTable();
                SlipType = bSlipType.GetModel(cboType.SelectedValue.ToString(), txtCode.Text);
                if (SlipType != null)
                {
                    txtCode.Text = "";
                    cboType.Focus();
                    MessageBox.Show("类型编号和订单编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (cboType.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtIndicatesOrder.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void FrmSlipTypeDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                cboType.Focus();
            }
            else
            {
                txtName.Focus();
            }
        }              
    }
}
