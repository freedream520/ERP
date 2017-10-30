using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductPartsDialog : Form
    {
        private BaseUserTable _userInfo;
        private BaseProductPartsTable _currentProductPartsTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BProductParts bProductParts = new BProductParts();
        private BCommon bCommon = new BCommon();

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
        public BaseProductPartsTable CurrentProductPartsTable
        {
            get { return _currentProductPartsTable; }
            set { _currentProductPartsTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductPartsDialog()
        {
            InitializeComponent();
        }

        private void FrmProductPartsDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductPartsTable != null)
            {
                txtProductCode.Text = _currentProductPartsTable.PRODUCT_CODE;
                txtProductName.Text = _currentProductPartsTable.PRODUCT_NAME;
                txtPartsCode.Text = _currentProductPartsTable.PRODUCT_PART_CODE;
                txtPartsName.Text = _currentProductPartsTable.PRODUCT_PART_NAME;
                txtQuantity.Text = CConvert.ToString(_currentProductPartsTable.QUANTITY);
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtPartsCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                txtPartsCode.Enabled = false;
                btnProduct.Enabled = false;
                btnParts.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                btnProduct.Enabled = false;
                txtPartsCode.Text = "";
                txtPartsName.Text = "";
            }
        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductPartsTable == null)
                {
                    _currentProductPartsTable = new BaseProductPartsTable();
                }

                _currentProductPartsTable.PRODUCT_CODE = txtProductCode.Text;
                _currentProductPartsTable.PRODUCT_PART_CODE = txtPartsCode.Text;
                _currentProductPartsTable.QUANTITY = Convert.ToDecimal(txtQuantity.Text);
                _currentProductPartsTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bProductParts.Exists(txtProductCode.Text.Trim(), txtPartsCode.Text.Trim()))
                    {
                        bProductParts.Update(_currentProductPartsTable);
                    }
                    else
                    {
                        _currentProductPartsTable.CREATE_USER = _userInfo.CODE;
                        bProductParts.Add(_currentProductPartsTable);
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
            //判断商品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
                strErrorlog += "商品编号不能为空!\r\n";

            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtPartsCode.Text.Trim()))
                strErrorlog += "材料编号不能为空!\r\n";

            if (strErrorlog != null )
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtQuantity.Text.Trim()))
                txtQuantity.Text = "0";

            return true;
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }
        #endregion
       
        private void FrmProductPartsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmProductPartsDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
                txtProductCode.Focus();
            else
                txtQuantity.Focus();
        }

        #region 组成品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtPartsCode.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtPartsCode.Text.Trim()))
            {
                BaseProductPartsTable ProductPartsCode = new BaseProductPartsTable();
                ProductPartsCode = bProductParts.GetModel(txtProductCode.Text, txtPartsCode.Text);
                if (ProductPartsCode != null)
                {
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtPartsCode.Text = "";
                    txtProductCode.Focus();
                    MessageBox.Show("商品编号和材料编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            string product = txtProductCode.Text.Trim();
            if (!string.IsNullOrEmpty(product))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", product);
                if (baseMaster != null)
                {
                    txtProductCode.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                    txtPartsCode.Focus();
                }
                else
                {
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion

        #region 材料
        private void btnParts_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtPartsCode.Text = frm.BaseMasterTable.Code;
                    txtPartsName.Text = frm.BaseMasterTable.Name;
                    txtQuantity.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtPartsCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtPartsCode.Text.Trim()))
            {
                BaseProductPartsTable ProductPartsCode = new BaseProductPartsTable();
                ProductPartsCode = bProductParts.GetModel(txtProductCode.Text, txtPartsCode.Text);
                if (ProductPartsCode != null)
                {
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtPartsCode.Text = "";
                    txtProductCode.Focus();
                    MessageBox.Show("商品编号和材料编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            string part = txtPartsCode.Text.Trim();
            if (!string.IsNullOrEmpty(part))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", part);
                if (baseMaster != null)
                {
                    txtPartsCode.Text = baseMaster.Code;
                    txtPartsName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPartsCode.Text = "";
                    txtPartsName.Text = "";
                    txtQuantity.Focus();
                }
            }
            else
            {
                txtPartsName.Text = "";
            }
        }
        #endregion

        #region 按键
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtProductCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtQuantity.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQuantity.Focused)
                    btnSave.Focus();
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtQuantity.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                    e.Handled = true;
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
    }
}
