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

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductGroupDialog : Form
    {

        private BProductGroup bProductGroup = new BProductGroup();
        private BaseUserTable _userInfo;
        private BaseProductGroupTable _currentProductGroupTable = null;
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
        public BaseProductGroupTable CurrentProductGroupTable
        {
            get { return _currentProductGroupTable; }
            set { _currentProductGroupTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductGroupDialog()
        {
            InitializeComponent();
        }

        private void FrmProductGroupDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductGroupTable != null)
            {
                txtCode.Text = _currentProductGroupTable.CODE;
                txtName.Text = _currentProductGroupTable.NAME;
                txtParentCode.Text = _currentProductGroupTable.PARENT_CODE;
                txtParentName.Text = _currentProductGroupTable.PARENT_NAME;
                txtIndicatesOrder.Text = CConvert.ToString(_currentProductGroupTable.INDICATES_ORDER);
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

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductGroupTable == null)
                {
                    _currentProductGroupTable = new BaseProductGroupTable();
                }
                _currentProductGroupTable.CODE = txtCode.Text;
                _currentProductGroupTable.NAME = txtName.Text;
                _currentProductGroupTable.PARENT_CODE = txtParentCode.Text;
                _currentProductGroupTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductGroupTable.INDICATES_ORDER = CConvert.ToInt32(txtIndicatesOrder.Text);

                try
                {
                    if (bProductGroup.Exists(txtCode.Text.Trim()))
                    {
                        bProductGroup.Update(_currentProductGroupTable);
                    }
                    else
                    {
                        _currentProductGroupTable.CREATE_USER = _userInfo.CODE;
                        bProductGroup.Add(_currentProductGroupTable);
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
                strErrorlog += "编号不能为空!\r\n";

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                strErrorlog += "名称不能为空!\r\n";

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);

            return true;
        }
        #endregion
        
        private void FrmProductGroupDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 上级商品类别
        private void btnParentCode_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtParentCode.Text = frm.BaseMasterTable.Code;
                    txtParentName.Text = frm.BaseMasterTable.Name;
                    txtIndicatesOrder.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtParentCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtParentCode.Text.Trim()))
            {
                BaseProductGroupTable ProductGroup = new BaseProductGroupTable();
                BProductGroup bProductGroup = new BProductGroup();
                ProductGroup = bProductGroup.GetModel(this.txtParentCode.Text);
                if (ProductGroup == null || "".Equals(ProductGroup))
                {
                    txtParentCode.Focus();
                    txtParentCode.Text = "";
                    txtParentName.Text = "";
                    MessageBox.Show("上级商品类别不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtParentCode.Text = ProductGroup.CODE;
                    txtParentName.Text = ProductGroup.NAME;
                    txtIndicatesOrder.Focus();
                }
            }
            else
            {
                txtParentName.Text = "";
            }
        }
        #endregion

        private void FrmProductGroupDialog_Shown(object sender, EventArgs e)
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

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseProductGroupTable ProductGroupCode = new BaseProductGroupTable();
                ProductGroupCode = bProductGroup.GetModel(txtCode.Text);
                if (ProductGroupCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }        

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtIndicatesOrder.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion
    }
}
