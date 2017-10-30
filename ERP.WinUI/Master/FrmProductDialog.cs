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
    public partial class FrmProductDialog : Form
    {
        private BaseUserTable _userInfo;
        private BProduct bProduct = new BProduct();
        private int _mode;
        private BaseProductTable _currentProductTable = null;
        private DialogResult result = DialogResult.Cancel;

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseProductTable CurrentProductTable
        {
            get { return _currentProductTable; }
            set { _currentProductTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmproductDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductTable != null)
            {
                txtCode.Text = _currentProductTable.CODE;
                txtName.Text = _currentProductTable.NAME;
                txtSpec.Text = _currentProductTable.SPEC;
                txtModelNumber.Text = _currentProductTable.MODEL_NUMBER;
                txtGroupCode.Text = _currentProductTable.GROUP_CODE;
                txtGroupName.Text = _currentProductTable.GROUP_NAME;
                txtBasic.Text = _currentProductTable.BASIC_UNIT_CODE;
                txtBasicName.Text = _currentProductTable.BASIC_UNIT_NAME;
                txtHsCode.Text = _currentProductTable.HS_CODE;
                txtHsName.Text = _currentProductTable.HSCODE_NAME;
                txtPrice.Text = CConvert.ToString(_currentProductTable.SALES_PRICE);
                txtName_Jp.Text = _currentProductTable.NAME_JP;
                txtPurchasePrice.Text = CConvert.ToString(_currentProductTable.PURCHASE_PRICE_INCLUDED_TAX);
                txtPurchasePriceWithoutTax.Text = CConvert.ToString(_currentProductTable.PURCHASE_PRICE_WITHOUT_TAX);
                txtCustomerSalesPrice.Text = CConvert.ToString(_currentProductTable.CUSTOMER_SALES_PRICE);
                txtPrice_Jp.Text = CConvert.ToString(_currentProductTable.PRICE_JP);
                if (_currentProductTable.ACCOUTING_TARGET == 1)
                    rAccout1.Checked = true;
                else
                    rAccout2.Checked = true;

                if (_currentProductTable.STOCK_FLAG == 1)
                    rStock1.Checked = true;
                else
                {
                    rStock2.Checked = true;

                    if (_currentProductTable.PROPERTY_FLAG == 1)
                        rProperty1.Checked = true;
                    else
                        rProperty2.Checked = true;

                }
                if (_currentProductTable.FROMSET_FLAG == 2)
                {
                    rbFromSet.Checked = true;
                }
                else if (_currentProductTable.FROMSET_FLAG == 1)
                {
                    rbNoFromSet.Checked = true;
                }
                if (_currentProductTable.MECHANICAL_DISTINCTION_FLAG == 1)
                {
                    rbBody.Checked = true;
                }
                else if (_currentProductTable.MECHANICAL_DISTINCTION_FLAG == 2)
                {
                    rbComponents.Checked = true;
                }
                if (_currentProductTable.PACKAGE_MODE == CConstant.PRODUCT_PACKAGE_ALONT)
                {
                    rdoAlone.Checked = true;
                }
                else if (_currentProductTable.PACKAGE_MODE == CConstant.PRODUCT_PACKAGE_COMPOSE)
                {
                    rdoCombination.Checked = true;
                }
                if (_currentProductTable.SELL_LOCATION == CConstant.PRODUCT_SELL_CHINA)
                {
                    rdoChaina.Checked = true;
                }
                else if (_currentProductTable.SELL_LOCATION == CConstant.PRODUCT_SELL_JAPAN)
                {
                    rdoJapan.Checked = true;
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
        }

        #region 保存
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductTable == null)
                {
                    _currentProductTable = new BaseProductTable();
                }
                _currentProductTable.CODE = txtCode.Text;
                _currentProductTable.NAME = txtName.Text;
                _currentProductTable.SPEC = txtSpec.Text;
                _currentProductTable.MODEL_NUMBER = txtModelNumber.Text;
                _currentProductTable.GROUP_CODE = txtGroupCode.Text;
                _currentProductTable.BASIC_UNIT_CODE = txtBasic.Text;
                _currentProductTable.HS_CODE = txtHsCode.Text;
                _currentProductTable.SALES_PRICE = Convert.ToDecimal(txtPrice.Text);
                _currentProductTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductTable.NAME_JP = txtName_Jp.Text;
                _currentProductTable.PURCHASE_PRICE_INCLUDED_TAX = CConvert.ToDecimal(txtPurchasePrice.Text);
                _currentProductTable.CUSTOMER_SALES_PRICE = CConvert.ToDecimal(txtCustomerSalesPrice.Text);
                _currentProductTable.PURCHASE_PRICE_WITHOUT_TAX = CConvert.ToDecimal(txtPurchasePriceWithoutTax.Text);
                _currentProductTable.PRICE_JP = CConvert.ToDecimal(txtPrice_Jp.Text.Trim());

                if (rAccout1.Checked)
                    _currentProductTable.ACCOUTING_TARGET = 1;
                else
                    _currentProductTable.ACCOUTING_TARGET = 2;

                if (rStock1.Checked)
                    _currentProductTable.STOCK_FLAG = 1;
                else
                    _currentProductTable.STOCK_FLAG = 2;

                if (rProperty1.Checked)
                    _currentProductTable.PROPERTY_FLAG = 1;
                else
                    _currentProductTable.PROPERTY_FLAG = 2;

                if (rbNoFromSet.Checked)
                    _currentProductTable.FROMSET_FLAG = 1;
                else
                    _currentProductTable.FROMSET_FLAG = 2;

                if (rbBody.Checked)
                    _currentProductTable.MECHANICAL_DISTINCTION_FLAG = 1;
                else
                    _currentProductTable.MECHANICAL_DISTINCTION_FLAG = 2;

                if (rdoChaina.Checked)
                {
                    _currentProductTable.SELL_LOCATION = CConstant.PRODUCT_SELL_CHINA;
                }
                else
                {
                    _currentProductTable.SELL_LOCATION = CConstant.PRODUCT_SELL_JAPAN;
                }

                if (rdoAlone.Checked)
                {
                    _currentProductTable.PACKAGE_MODE = CConstant.PRODUCT_PACKAGE_ALONT;
                }
                else
                {
                    _currentProductTable.PACKAGE_MODE = CConstant.PRODUCT_PACKAGE_COMPOSE;
                }

                try
                {
                    if (bProduct.Exists(txtCode.Text.Trim()))
                        bProduct.Update(_currentProductTable);
                    else
                    {
                        _currentProductTable.CREATE_USER = _userInfo.CODE;
                        bProduct.Add(_currentProductTable);
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
                strErrorlog += "商品编号不能为空!\r\n";

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                strErrorlog += "商品名称不能为空!\r\n";

            //判断日文名称不能为空
            if (string.IsNullOrEmpty(this.txtName_Jp.Text.Trim()))
                strErrorlog += "日文名称不能为空!\r\n";
            ////判断规格不能为空
            //if (string.IsNullOrEmpty(this.txtSpec.Text.Trim()))
            //    strErrorlog += "规格不能为空!\r\n";

            //判断类别型号不能为空
            if (string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
                strErrorlog += "类别型号不能为空!\r\n";

            if (string.IsNullOrEmpty(this.txtBasic.Text.Trim()))
                strErrorlog += "基本单位不能为空!\r\n";

            ////判断海关编号不能为空
            //if (string.IsNullOrEmpty(this.txtHsCode.Text.Trim()))
            //    strErrorlog += "海关编号不能为空!\r\n";

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPrice.Text == null || "".Equals(txtPrice.Text))
                txtPrice.Text = "0";

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);

            //if (CTools.GetTextBoxLength(txtSpec.Text) > txtSpec.MaxLength)
            //    txtSpec.Text = CTools.textSpilt(txtSpec.Text, txtSpec.MaxLength);

            if (CTools.GetTextBoxLength(txtModelNumber.Text) > txtModelNumber.MaxLength)
                txtModelNumber.Text = CTools.textSpilt(txtModelNumber.Text, txtModelNumber.MaxLength);

            return true;
        }
        #endregion

        #region 取消/关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion

        #region 商品分类
        private void btnGroupCode_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtGroupCode.Text = frm.BaseMasterTable.Code;
                    txtGroupName.Text = frm.BaseMasterTable.Name;
                    txtBasic.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtGroupCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
            {
                BaseProductGroupTable productGroup = new BaseProductGroupTable();
                BProductGroup bProductGroup = new BProductGroup();
                productGroup = bProductGroup.GetModel(this.txtGroupCode.Text);
                if (productGroup == null || "".Equals(productGroup))
                {
                    txtGroupCode.Focus();
                    txtGroupCode.Text = "";
                    txtGroupName.Text = "";
                    MessageBox.Show("类别型号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtGroupName.Text = productGroup.NAME;
            }
        }
        #endregion

        #region 单位
        private void btnUnit_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Unit", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtBasic.Text = frm.BaseMasterTable.Code;
                    txtBasicName.Text = frm.BaseMasterTable.Name;
                    rAccout1.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtBasic_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBasic.Text.Trim()))
            {
                BaseUnitTable Unit = new BaseUnitTable();
                BUnit bUnit = new BUnit();
                Unit = bUnit.GetModel(this.txtBasic.Text);
                if (Unit == null || "".Equals(Unit))
                {
                    txtBasic.Focus();
                    txtBasic.Text = "";
                    txtBasicName.Text = "";
                    MessageBox.Show("基本单位不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtBasicName.Text = Unit.NAME;
            }
        }
        #endregion

        private void FrmProductDialog_Shown(object sender, EventArgs e)
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

            if (txtPrice.Focused)
            {
                //if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                //{
                //    e.Handled = true;
                //}
                InputAmount(sender, e);
            }
            else if (txtPurchasePrice.Focused)
            {
                //if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                //{
                //    e.Handled = true;
                //}
                InputAmount(sender, e);
            }
            else if (txtCustomerSalesPrice.Focused)
            {
                InputAmount(sender, e);
            }
            else if (txtPurchasePriceWithoutTax.Focused)
            {
                InputAmount(sender, e);
            }
            else if (txtPrice_Jp.Focused)
            {
                InputAmount(sender, e);
            }
        }

        /// <summary>
        /// //限制数量只能输入数字，带小数，金额类型，只能有两位小数
        /// </summary>
        protected void InputAmount(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (((TextBox)sender).SelectionStart == 0)
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else　 //以下为输入正确内容过虑
            {
                string[] str = ((TextBox)sender).Text.Split('.');
                if (str.Length > 1)
                {
                    if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyChar == 8)
                {
                    e.Handled = false;
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
                BaseProductTable ProductCode = new BaseProductTable();
                ProductCode = bProduct.GetModel(txtCode.Text);
                if (ProductCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtHsCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtHsCode.Text.Trim()))
            {
                BaseHsCodeTable HsCode = new BaseHsCodeTable();
                BHsCode bHsCode = new BHsCode();
                HsCode = bHsCode.GetModel(this.txtHsCode.Text);
                if (HsCode == null || "".Equals(HsCode))
                {
                    txtHsCode.Focus();
                    txtHsCode.Text = "";
                    txtHsName.Text = "";
                    MessageBox.Show("海关编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtHsName.Text = HsCode.HS_NAME;
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                { }
                else if (txtHsCode.Focused)
                    btnUnit.Focus();
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion


    }
}
