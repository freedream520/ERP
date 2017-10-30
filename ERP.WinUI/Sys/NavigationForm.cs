using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using System.IO;
using System.Drawing.Imaging;
using CZZD.ERP.CacheData;
using System.Reflection;

namespace CZZD.ERP.WinUI
{
    public partial class NavigationForm : FrmBase, CZZD.ERP.Main.IMyChildForm
    {
        private float X = 1028;
        private float Y = 663;
        float newx = 1;
        float newy = 1;
        int maxSize = 20;
        public NavigationForm()
        {
            InitializeComponent();
        }
        //存放当前选中的控件
        private PictureBox _pic = null;

        private void NavigationForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        #region IMyChildForm 成员

        public void ChildShowForm(string caption, string name)
        {
            newx = (this.pMain.Width) / X; //窗体宽度缩放比例
            newy = this.pMain.Height / Y;//窗体高度缩放比例
            this.Text = caption;
            this.pMain.Controls.Clear();
            this.pMain.Tag = name;
            switch (name)
            {
                case "menuMasterManage":      //マスタ管理
                    newFrmPictureBox(this.pMain, 50, 25, "Warehouse", "仓库设定", Resources.warehouse, Resources.warehouse_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 25, "Location", "货位设定", Resources.location, Resources.location_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 25, "ProductGroup", "商品种类设定", Resources.product_group, Resources.product_group_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 25, "Product", "商品设定", Resources.product, Resources.product_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 25, "Unit", "单位设定", Resources.unit, Resources.unit_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 155, "ProductUnit", "商品单位设定", Resources.product_unit, Resources.product_unit_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 155, "ProductParts", "商品材料构成设定", Resources.product_parts, Resources.product_parts_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 155, "SafetyStock", "安全库存设定", Resources.safety_stock, Resources.safety_stock_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 155, "Currency", "货币设定", Resources.currency, Resources.currency_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 155, "TaxAtion", "税率设定", Resources.taxation, Resources.taxation_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 285, "Customer", "客户设定", Resources.customer, Resources.customer_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 285, "CustomerReported", "客户备案设定", Resources.customer_reported, Resources.customer_reported_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 285, "CustomerPrice", "客户单价设定", Resources.customer_price, Resources.customer_price_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 285, "Supplier", "供应商设定", Resources.supplier, Resources.supplier_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 285, "SupplierPrice", "供应商单价设定", Resources.supplier_price, Resources.supplier_price_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 415, "HsCode", "海关编号设定", Resources.hs_code, Resources.hs_code_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 415, "SlipType", "单据类型设定", Resources.sliptype, Resources.sliptype_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 415, "Reason", "理由设定", Resources.reason, Resources.reason_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 415, "Delivery", "客户地址设定", Resources.delivery, Resources.delivery_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 415, "MasterMachine", "机械序号设定", Resources.machine, Resources.machine_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 535, "Exchange", "汇率设定", Resources.exchange, Resources.exchange_enabled, "");
                    break;
                case "menuUserRoles":         //用户权限
                    newFrmPictureBox(this.pMain, 100, 100, "Company", "公司管理", Resources.company, Resources.company_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 100, "Department", "部门管理", Resources.department, Resources.department_enabled, "");
                    newFrmPictureBox(this.pMain, 700, 100, "User", "用户管理", Resources.user, Resources.user_enabled, "");

                    newFrmPictureBox(this.pMain, 100, 400, "Roles", "角色管理", Resources.roles, Resources.roles_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 400, "RolesFunction", "权限设定", Resources.userRoles, Resources.userRoles_enabled, "");
                    break;

                case "menuSalesManage":
                    newFrmPictureBox(this.pMain, 100, 100, "OrdersEntry", "订单输入", Resources.orderEntry, Resources.orderEntry_enabled, CConstant.ORDER_NEW);
                    newMenuLine(250, 150, 100, 30, Resources.menuLine);
                    newFrmPictureBox(this.pMain, 400, 100, "OrdersSearch", "订单查询", Resources.orderSearch, Resources.orderSearch_enabled, CConstant.ORDER_SEARCH);
                    newMenuLine(550, 150, 100, 30, Resources.menuLine);
                    newFrmPictureBox(this.pMain, 700, 100, "OrdersSearch", "在库引当", Resources.orderAlloation, Resources.orderAlloation_enabled, CConstant.ORDER_ALLOATION);

                    newFrmPictureBox(this.pMain, 100, 400, "OrdersSearch", "修理输入", Resources.orderVerify, Resources.orderVerify_enabled, CConstant.ORDER_SERVICE);
                    newFrmPictureBox(this.pMain, 400, 400, "OrdersSearch", "复制订单", Resources.orderCopy, Resources.orderCopy_enabled, CConstant.ORDER_COPY);
                    //newFrmPictureBox(this.pMain, 100, 400, "OrdersSearch", "订单承认", Resources.orderVerify, Resources.orderVerify_enabled, CConstant.ORDER_VERIFY);
                    newFrmPictureBox(this.pMain, 700, 400, "OrdersSearch", "订单修正", Resources.orderModify, Resources.orderModify_enabled, CConstant.ORDER_MODIFY);
                    

                    break;

                case "menuPurchaseManage":
                    newFrmPictureBox(this.pMain, 100, 100, "PurchaseOrderEntry", "采购输入", Resources.PurchaseOrderEntry, Resources.PurchaseOrderEntry_enabled, CConstant.PURCHASE_ORDER_NEW);
                    newFrmPictureBox(this.pMain, 700, 100, "PurchaseOrderSupplementSearch", "补充查询", Resources.PurchaseOrderSupplementSearch, Resources.PurchaseOrderSupplementSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 100, "PurchaseOrderSearch", "采购查询", Resources.PurchaseOrderSearch, Resources.PurchaseOrderSearch_enabled, CConstant.PURCHASE_ORDER_SEARCH);

                    newFrmPictureBox(this.pMain, 100, 400, "PurchaseOrderSupplementEntry", "组成品采购计算", Resources.PurchaseOrderSupplementEntry, Resources.PurchaseOrderSupplementEntry_enabled, "");

                    break;
                case "menuFinanceManage":
                    newFrmPictureBox(this.pMain, 50, 25, "Purchase", "采购发票输入", Resources.purchase, Resources.purchase_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 25, "PurchaseSearch", "采购发票查询", Resources.purchaseSearch, Resources.PurchaseOrderSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 25, "UnPaymentSearch", "应付款查询", Resources.unPaymentSearch, Resources.unPaymentSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 25, "Payment", "付款输入", Resources.payment, Resources.payment_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 25, "PaymentSearch", "付款查询", Resources.paymentSearch, Resources.paymentSearch_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 185, "Sales", "销售发票输入", Resources.sales, Resources.sales_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 185, "SalesSearch", "销售发票查询", Resources.salesSearch, Resources.salesSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 185, "UnReceiptMatchSearch", "应收款查询", Resources.unReceiptMatchSearch, Resources.unReceiptMatchSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 185, "ReceiptMatch", "收款输入", Resources.receiptMatch, Resources.receiptMatch_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 185, "ReceiptMatchSearch", "收款查询", Resources.receiptMatchSearch, Resources.receiptMatchSearch_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 345, "Deposit", "预收款输入", Resources.deposit, Resources.deposit_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 345, "DepositSearch", "预收款查询", Resources.depositSearch, Resources.deposit_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 345, "DepositArr", "预收款分配输入", Resources.depositArr, Resources.depositArr_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 345, "DepositArrSearch", "预收款分配查询", Resources.depositArrSearch, Resources.depositArrSearch_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 505, "SupplierDeposit", "预付款输入", Resources.SupplierDeposit, Resources.SupplierDeposit_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 505, "SupplierDepositSearch", "预付款查询", Resources.supplierDepositSearch, Resources.supplierDepositSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 505, "SupplierDepositArr", "预付款分配输入", Resources.supplierDepositArr, Resources.supplierDepositArr_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 505, "SupplierDepositArrSearch", "预付款分配查询", Resources.supplierDepositArrSearch, Resources.supplierDepositArrSearch_enabled, "");

                    break;
                case "menuStockManage":
                    newFrmPictureBox(this.pMain, 50, 25, "StockSearch", "库存查询", Resources.StockSearch, Resources.StockSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 25, "Shipment", "出库输入", Resources.Shipment, Resources.Shipment_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 25, "ShipmentSearch", "出库查询", Resources.ShipmentSearch, Resources.ShipmentSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 25, "Receipt", "入库输入", Resources.Receipt, Resources.Receipt_enabled, "");
                    newFrmPictureBox(this.pMain, 850, 25, "ReceiptSearch", "入库查询", Resources.ReceiptSearch, Resources.ReceiptSearch_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 185, "TransferReceipt", "仓库间调拨", Resources.TransferReceipt, Resources.TransferReceipt_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 185, "TransferReceiptSearch", "仓库间调拨查询", Resources.TransferReceiptSearch, Resources.TransferReceiptSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 185, "InventoryStart", "盘点开始", Resources.InventoryStart, Resources.InventoryStart_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 185, "InventorySearch", "盘点结果输入", Resources.Inventory, Resources.Inventory_enabled, CConstant.INVENTORY_END);
                    newFrmPictureBox(this.pMain, 850, 185, "InventorySearch", "盘点查询", Resources.InventorySearch, Resources.InventorySearch_enabled, CConstant.INVENTORY_SEARCH);

                    newFrmPictureBox(this.pMain, 50, 345, "StockAdjustment", "库存修改", Resources.StockAdjustment, Resources.StockAdjustment_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 345, "StockAdjustmentSearch", "库存修改查询", Resources.StockAdjustmentSearch, Resources.StockAdjustmentSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 345, "DelaySearch", "滞留品查询", Resources.delay, Resources.delay_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 505, "ProductBuild", "组成品组成输入", Resources.ProductBuild, Resources.ProductBuild_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 505, "ProductBuildSearch", "组成品组成查询", Resources.ProductBuildSearch, Resources.ProductBuildSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 505, "ProductRelieve", "组成品解除输入", Resources.ProductRelieve, Resources.ProductRelieve_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 505, "ProductRelieveSearch", "组成品解除查询", Resources.ProductRelieveSearch, Resources.ProductRelieveSearch_enabled, "");
                    break;

                case "menuImportManage":
                    newFrmPictureBox(this.pMain, 50, 25, "BaseReceive", "数据导入", Resources.purchase, Resources.purchase_enabled, "");
                    //newFrmPictureBox(this.pMain, 250, 25, "BaseReceiveLog", "导入日志", Resources.ShipmentSearch, Resources.ShipmentSearch_enabled, "");
                    break;
                case "menuNotify":
                    newFrmPictureBox(this.pMain, 100, 100, "StockNotify", "安全在库提醒", Resources.StockNotify, Resources.StockNotify_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 100, "DepositNotify", "收款预定提醒", Resources.DepositNotify, Resources.DepositNotify_enabled, "");
                    newFrmPictureBox(this.pMain, 700, 100, "ReceivingNotify", "入库预定提醒", Resources.ReceivingNotify, Resources.ReceivingNotify_enabled, "");

                    break;

                case "menuInvoiceManage":
                    newFrmPictureBox(this.pMain, 50, 25, "Invoice", "OEM销售成绩表", Resources.OEM_sales_performance, Resources.OEM_sales_performance_enabled, CConstant.INVOICE_OEM_SALES);
                    newFrmPictureBox(this.pMain, 250, 25, "Invoice", "OEM制品管理表", Resources.OEM_product_management, Resources.OEM_product_management_enabled, CConstant.INVOICE_OEM_PRODUCT);
                    newFrmPictureBox(this.pMain, 450, 25, "Invoice", "应收账款管理表", Resources.account_management, Resources.account_management_enabled, CConstant.INVOICE_ACCOUNT_RECEIVABLE);
                    newFrmPictureBox(this.pMain, 650, 25, "Invoice", "进销存汇总表", Resources.invoicing_summary_, Resources.invoicing_summary_enabled, CConstant.INVOICE_SUMMARY);

                    newFrmPictureBox(this.pMain, 50, 185, "MonthCalculate", "月末计算", Resources.OEM_sales_performance, Resources.OEM_sales_performance_enabled, "");

                    break;
                case "menuDesk":
                    DataTable dt = bCommon.GetDeskDatas(UserTable.COMPANY_CODE, UserTable.CODE).Tables[0];
                    int i = 0, j = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        int x = 50 + 200 * i;
                        int y = 25 + 160 * j;
                        string frmName = dr["FORM_NAME"].ToString();
                        string title = dr["FORM_TITLE"].ToString();
                        Image img = ByteToImage((byte[])dr["PIC"]);
                        string tag = dr["FORM_ARGS"].ToString();
                        newDeskFrmPictureBox(this.pMain, x, y, frmName, title, img, tag);

                        i++;
                        if (i == 5)
                        {
                            i = 0;
                            j++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region newFrmPictureBox
        private void newMenuLine(int x, int y, int width, int height, Image image)
        {
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new System.Drawing.Point(Int32.Parse(Math.Ceiling(x * newx).ToString()), Int32.Parse(Math.Ceiling(y * newy).ToString()));
            pic.Size = new System.Drawing.Size(width, height);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.Image = image;
            this.pMain.Controls.Add(pic);
        }


        private void newDeskFrmPictureBox(Panel panel, int x, int y, string name, string text, Image image, string tag)
        {
            bool roles = CheckRoles(CCacheData.GetRolesFunction(UserTable.ROLES_CODE), "", name, text, tag);
            x = Int32.Parse(Math.Ceiling(x * newx).ToString());
            y = Int32.Parse(Math.Ceiling(y * newy).ToString());
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Image = image;
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "Frm" + name;
            pic.Size = new System.Drawing.Size(100, 100);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic.TabIndex = 1;
            pic.Tag = tag;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            if (roles)
            {
                pic.ContextMenuStrip = menuDelete;
                pic.Click += new System.EventHandler(this.Pic_Click);
                pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            }
            panel.Controls.Add(pic);

            Label lbl = new System.Windows.Forms.Label();
            lbl.ForeColor = Color.Black;
            lbl.Location = new System.Drawing.Point(x - 15, y + 104);
            lbl.Name = "LBL" + name + CConvert.ToString(tag, 2);
            lbl.Size = new System.Drawing.Size(130, 20);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(lbl);
        }

        private void newFrmPictureBox(Panel panel, int x, int y, string name, string text, Image image, Image image_enabled, string tag)
        {
            bool roles = CheckRoles(CCacheData.GetRolesFunction(UserTable.ROLES_CODE), "", name, text, tag);
            x = Int32.Parse(Math.Ceiling(x * newx).ToString());
            y = Int32.Parse(Math.Ceiling(y * newy).ToString());
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "Frm" + name;
            pic.Size = new System.Drawing.Size(100, 100);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic.TabIndex = 1;
            pic.Tag = tag;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            if (roles)
            {
                pic.Image = image;
                if ("Invoice".Equals(name))
                {
                    pic.Click += new System.EventHandler(this.Invoice_click);
                }
                else if ("MonthCalculate".Equals(name))
                {

                    pic.Click += new System.EventHandler(this.MonthCalculate_click);
                }
                else
                {
                    pic.Click += new System.EventHandler(this.Pic_Click);
                }
            }
            else
            {
                pic.Image = image_enabled;
            }
            pic.ContextMenuStrip = menuAdd;
            pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
            pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);

            panel.Controls.Add(pic);

            Label lbl = new System.Windows.Forms.Label();
            lbl.ForeColor = Color.Black;
            lbl.Location = new System.Drawing.Point(x - 15, y + 104);
            lbl.Name = "LBL" + name + CConvert.ToString(tag, 2);
            lbl.Size = new System.Drawing.Size(130, 20);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(lbl);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            Control[] control = this.Controls.Find(pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);

            //调用父窗体的ParentShowForm()方法 
            if ((this.MdiParent != null) && (this.MdiParent is CZZD.ERP.Main.IMdiParent))
                (this.MdiParent as CZZD.ERP.Main.IMdiParent).ParentShowForm("WinUI", pic.Name, control[0].Text, pic.Tag.ToString());
        }

        private void Invoice_click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            FrmInvoice frm = new FrmInvoice(pic.Tag.ToString());
            frm.UserTable = UserTable;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void MonthCalculate_click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            FrmMonthCalculate frm = new FrmMonthCalculate();
            frm.Tag = pic.Tag.ToString();
            frm.UserTable = UserTable;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = null;
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = Resources.menu_border;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            _pic = (PictureBox)sender;
        }
        #endregion

        /// <summary>
        /// 添加到我的桌面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeskAdd_Click(object sender, EventArgs e)
        {
            Control[] control = this.Controls.Find(_pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);
            BaseDeskTable deskTable = new BaseDeskTable();
            deskTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            deskTable.USER_CODE = UserTable.CODE;
            deskTable.FORM_NAME = _pic.Name.Replace("Frm", "");
            deskTable.FORM_TITLE = control[0].Text;
            deskTable.FORM_ARGS = _pic.Tag.ToString();
            deskTable.PIC = ImageToByte(_pic.Image);

            try
            {
                DataTable dt = CCacheData.GetDesk(UserTable.COMPANY_CODE, UserTable.CODE);

                if (dt != null && dt.Rows.Count > maxSize)
                {
                    MessageBox.Show("我的桌面己经超出最大上限　" + maxSize, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {

            }

            if (bCommon.Exists(deskTable))
            {
                MessageBox.Show(deskTable.FORM_TITLE + "己经存在！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //添加
            if (bCommon.InsertDesk(deskTable))
            {
                CCacheData.ResetDesk(UserTable.COMPANY_CODE, UserTable.CODE);
            }
        }

        /// <summary>
        /// 从我的桌面删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeskDelete_Click(object sender, EventArgs e)
        {
            Control[] control = this.Controls.Find(_pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);
            BaseDeskTable deskTable = new BaseDeskTable();
            deskTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            deskTable.USER_CODE = UserTable.CODE;
            deskTable.FORM_NAME = _pic.Name.Replace("Frm", "");
            deskTable.FORM_TITLE = control[0].Text;
            deskTable.FORM_ARGS = _pic.Tag.ToString();

            //删除
            if (bCommon.DeleteDesk(deskTable))
            {
                CCacheData.ResetDesk(UserTable.COMPANY_CODE, UserTable.CODE);
                //页面刷新
                ChildShowForm(this.Text, "menuDesk");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private byte[] ImageToByte(Image image)
        {
            byte[] img = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                img = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(img, 0, Convert.ToInt32(ms.Length));
                ms.Close();
            }
            catch (Exception ex) { }

            return img;
        }

        private Image ByteToImage(byte[] bt)
        {
            MemoryStream stream = new MemoryStream(bt);
            Image img = Image.FromStream(stream);
            return img;
        }

    }//end class
}
