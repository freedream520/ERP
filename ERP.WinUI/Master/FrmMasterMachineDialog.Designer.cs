namespace CZZD.ERP.WinUI
{
    partial class FrmMasterMachineDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterMachineDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSaleTime = new System.Windows.Forms.DateTimePicker();
            this.txtReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.txtFSerialNumber = new System.Windows.Forms.TextBox();
            this.txtFSlipNUmber = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrderSlipNumber = new System.Windows.Forms.TextBox();
            this.txtPurchaseSlipNumber = new System.Windows.Forms.TextBox();
            this.cboMaintenanceStations = new System.Windows.Forms.ComboBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 368);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.txtSaleTime);
            this.panel3.Controls.Add(this.txtReceiptDate);
            this.panel3.Controls.Add(this.txtFSerialNumber);
            this.panel3.Controls.Add(this.txtFSlipNUmber);
            this.panel3.Controls.Add(this.txtPurchaseOrderSlipNumber);
            this.panel3.Controls.Add(this.txtPurchaseSlipNumber);
            this.panel3.Controls.Add(this.cboMaintenanceStations);
            this.panel3.Controls.Add(this.txtMachineName);
            this.panel3.Controls.Add(this.btnProduct);
            this.panel3.Controls.Add(this.btnCustomer);
            this.panel3.Controls.Add(this.txtMachineCode);
            this.panel3.Controls.Add(this.txtCustomerName);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.txtCustomerCode);
            this.panel3.Controls.Add(this.txtProductCode);
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 364);
            this.panel3.TabIndex = 0;
            // 
            // txtSaleTime
            // 
            this.txtSaleTime.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSaleTime.CustomFormat = "yyyy-MM-dd";
            this.txtSaleTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSaleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSaleTime.Location = new System.Drawing.Point(5, 305);
            this.txtSaleTime.Name = "txtSaleTime";
            this.txtSaleTime.ShowCheckBox = true;
            this.txtSaleTime.Size = new System.Drawing.Size(250, 25);
            this.txtSaleTime.TabIndex = 11;
            // 
            // txtReceiptDate
            // 
            this.txtReceiptDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtReceiptDate.CustomFormat = "yyyy-MM-dd";
            this.txtReceiptDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtReceiptDate.Location = new System.Drawing.Point(5, 275);
            this.txtReceiptDate.Name = "txtReceiptDate";
            this.txtReceiptDate.Size = new System.Drawing.Size(250, 25);
            this.txtReceiptDate.TabIndex = 11;
            // 
            // txtFSerialNumber
            // 
            this.txtFSerialNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtFSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFSerialNumber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFSerialNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFSerialNumber.Location = new System.Drawing.Point(5, 215);
            this.txtFSerialNumber.MaxLength = 20;
            this.txtFSerialNumber.Name = "txtFSerialNumber";
            this.txtFSerialNumber.Size = new System.Drawing.Size(250, 23);
            this.txtFSerialNumber.TabIndex = 9;
            // 
            // txtFSlipNUmber
            // 
            this.txtFSlipNUmber.BackColor = System.Drawing.SystemColors.Info;
            this.txtFSlipNUmber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFSlipNUmber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFSlipNUmber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFSlipNUmber.Location = new System.Drawing.Point(5, 245);
            this.txtFSlipNUmber.MaxLength = 20;
            this.txtFSlipNUmber.Name = "txtFSlipNUmber";
            this.txtFSlipNUmber.Size = new System.Drawing.Size(250, 23);
            this.txtFSlipNUmber.TabIndex = 10;
            // 
            // txtPurchaseOrderSlipNumber
            // 
            this.txtPurchaseOrderSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchaseOrderSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseOrderSlipNumber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPurchaseOrderSlipNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchaseOrderSlipNumber.Location = new System.Drawing.Point(5, 185);
            this.txtPurchaseOrderSlipNumber.MaxLength = 20;
            this.txtPurchaseOrderSlipNumber.Name = "txtPurchaseOrderSlipNumber";
            this.txtPurchaseOrderSlipNumber.Size = new System.Drawing.Size(250, 23);
            this.txtPurchaseOrderSlipNumber.TabIndex = 8;
            this.txtPurchaseOrderSlipNumber.Visible = false;
            // 
            // txtPurchaseSlipNumber
            // 
            this.txtPurchaseSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchaseSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseSlipNumber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPurchaseSlipNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchaseSlipNumber.Location = new System.Drawing.Point(5, 185);
            this.txtPurchaseSlipNumber.MaxLength = 20;
            this.txtPurchaseSlipNumber.Name = "txtPurchaseSlipNumber";
            this.txtPurchaseSlipNumber.Size = new System.Drawing.Size(250, 23);
            this.txtPurchaseSlipNumber.TabIndex = 8;
            // 
            // cboMaintenanceStations
            // 
            this.cboMaintenanceStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaintenanceStations.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboMaintenanceStations.FormattingEnabled = true;
            this.cboMaintenanceStations.Location = new System.Drawing.Point(5, 335);
            this.cboMaintenanceStations.Name = "cboMaintenanceStations";
            this.cboMaintenanceStations.Size = new System.Drawing.Size(250, 25);
            this.cboMaintenanceStations.TabIndex = 12;
            // 
            // txtMachineName
            // 
            this.txtMachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMachineName.Location = new System.Drawing.Point(5, 35);
            this.txtMachineName.MaxLength = 100;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(250, 23);
            this.txtMachineName.TabIndex = 1;
            this.txtMachineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMachineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnProduct
            // 
            this.btnProduct.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Location = new System.Drawing.Point(261, 123);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(25, 25);
            this.btnProduct.TabIndex = 6;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            this.btnProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Location = new System.Drawing.Point(261, 64);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMachineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMachineCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMachineCode.Location = new System.Drawing.Point(5, 5);
            this.txtMachineCode.MaxLength = 20;
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(250, 23);
            this.txtMachineCode.TabIndex = 0;
            this.txtMachineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMachineCode.Leave += new System.EventHandler(this.txtMachineCode_Leave);
            this.txtMachineCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 95);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtProductName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductName.Location = new System.Drawing.Point(5, 155);
            this.txtProductName.MaxLength = 8;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 23);
            this.txtProductName.TabIndex = 7;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 65);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            this.txtCustomerCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtProductCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductCode.Location = new System.Drawing.Point(5, 125);
            this.txtProductCode.MaxLength = 20;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(250, 23);
            this.txtProductCode.TabIndex = 5;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 364);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 97;
            this.label8.Text = " 入库日期：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 96;
            this.label7.Text = " FANUC编号：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 95;
            this.label6.Text = " FANUC序列号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 94;
            this.label2.Text = " 采购发票编号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = " 机械名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = " 客户编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 87;
            this.label9.Text = " 销售地点：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = " 销售日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 84;
            this.label14.Text = " 商品编号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 88;
            this.label11.Text = " 客户名称：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 86;
            this.label12.Text = " 商品名称：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = " 机械编号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(352, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(254, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // FrmMasterMachineDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 407);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMasterMachineDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "机械编辑";
            this.Load += new System.EventHandler(this.FrmMasterMachineDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMasterMachineDialog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.ComboBox cboMaintenanceStations;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPurchaseOrderSlipNumber;
        private System.Windows.Forms.TextBox txtFSerialNumber;
        private System.Windows.Forms.TextBox txtFSlipNUmber;
        private System.Windows.Forms.DateTimePicker txtReceiptDate;
        private System.Windows.Forms.TextBox txtPurchaseSlipNumber;
        private System.Windows.Forms.DateTimePicker txtSaleTime;
        private System.Windows.Forms.Label label9;
    }
}