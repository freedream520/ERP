namespace CZZD.ERP.WinUI
{
    partial class FrmShipmentSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShipmentSearch));
            this.pBody = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnShipper = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnDeliveryPoint = new System.Windows.Forms.Button();
            this.txtDeliveryPointName = new System.Windows.Forms.TextBox();
            this.txtDeliveryPointCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomerPoNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtOrderSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtOrderSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnEndCustomer = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtOrderSlipNumber = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtEndCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtEndCustomerCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDER_CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTUAL_WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pHeader.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pgControl);
            this.pBody.Controls.Add(this.btnCancel);
            this.pBody.Controls.Add(this.btnShipper);
            this.pBody.Controls.Add(this.btnPrint);
            this.pBody.Controls.Add(this.btnDelete);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 650);
            this.pBody.TabIndex = 0;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 584);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1015, 30);
            this.pgControl.TabIndex = 4;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(928, 616);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnShipper
            // 
            this.btnShipper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShipper.Location = new System.Drawing.Point(646, 616);
            this.btnShipper.Name = "btnShipper";
            this.btnShipper.Size = new System.Drawing.Size(90, 30);
            this.btnShipper.TabIndex = 21;
            this.btnShipper.Text = "纳品书";
            this.btnShipper.UseVisualStyleBackColor = true;
            this.btnShipper.Click += new System.EventHandler(this.btnShipper_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(740, 616);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(834, 616);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "出库取消";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.SLIP_NUMBER,
            this.ORDER_SLIP_NUMBER,
            this.ENDER_CUSTOMER_NAME,
            this.SLIP_DATE,
            this.LINE_NUMBER,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.ORDER_QUANTITY,
            this.QUANTITY,
            this.UNIT_NAME,
            this.DEPARTUAL_WAREHOUSE_NAME,
            this.STATUS_FLAG});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 198);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1015, 385);
            this.dgvData.TabIndex = 19;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pRight);
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Controls.Add(this.dateTimePicker2);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1021, 195);
            this.pHeader.TabIndex = 1;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 191);
            this.pRight.TabIndex = 3;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnDeliveryPoint);
            this.pRight_2.Controls.Add(this.txtDeliveryPointName);
            this.pRight_2.Controls.Add(this.txtDeliveryPointCode);
            this.pRight_2.Controls.Add(this.label7);
            this.pRight_2.Controls.Add(this.txtCustomerPoNumber);
            this.pRight_2.Controls.Add(this.label6);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.txtSerialNumber);
            this.pRight_2.Controls.Add(this.txtSlipDateFrom);
            this.pRight_2.Controls.Add(this.txtSlipDateTo);
            this.pRight_2.Controls.Add(this.txtOrderSlipDateTo);
            this.pRight_2.Controls.Add(this.txtOrderSlipDateFrom);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 189);
            this.pRight_2.TabIndex = 4;
            // 
            // btnDeliveryPoint
            // 
            this.btnDeliveryPoint.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnDeliveryPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeliveryPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeliveryPoint.FlatAppearance.BorderSize = 0;
            this.btnDeliveryPoint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeliveryPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeliveryPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliveryPoint.Location = new System.Drawing.Point(261, 4);
            this.btnDeliveryPoint.Name = "btnDeliveryPoint";
            this.btnDeliveryPoint.Size = new System.Drawing.Size(25, 25);
            this.btnDeliveryPoint.TabIndex = 11;
            this.btnDeliveryPoint.UseVisualStyleBackColor = true;
            this.btnDeliveryPoint.Click += new System.EventHandler(this.btnDeliveryPoint_Click);
            // 
            // txtDeliveryPointName
            // 
            this.txtDeliveryPointName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDeliveryPointName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryPointName.Enabled = false;
            this.txtDeliveryPointName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDeliveryPointName.Location = new System.Drawing.Point(5, 35);
            this.txtDeliveryPointName.Name = "txtDeliveryPointName";
            this.txtDeliveryPointName.Size = new System.Drawing.Size(250, 25);
            this.txtDeliveryPointName.TabIndex = 12;
            // 
            // txtDeliveryPointCode
            // 
            this.txtDeliveryPointCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeliveryPointCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryPointCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryPointCode.Location = new System.Drawing.Point(5, 5);
            this.txtDeliveryPointCode.Name = "txtDeliveryPointCode";
            this.txtDeliveryPointCode.Size = new System.Drawing.Size(250, 23);
            this.txtDeliveryPointCode.TabIndex = 10;
            this.txtDeliveryPointCode.Leave += new System.EventHandler(this.txtDeliveryPointCode_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(120, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "~";
            // 
            // txtCustomerPoNumber
            // 
            this.txtCustomerPoNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerPoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPoNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerPoNumber.Location = new System.Drawing.Point(5, 95);
            this.txtCustomerPoNumber.Name = "txtCustomerPoNumber";
            this.txtCustomerPoNumber.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerPoNumber.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(119, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "~";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(286, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSerialNumber.Location = new System.Drawing.Point(5, 65);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSerialNumber.TabIndex = 12;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 153);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.ShowCheckBox = true;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateFrom.TabIndex = 16;
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(142, 153);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateTo.TabIndex = 17;
            // 
            // txtOrderSlipDateTo
            // 
            this.txtOrderSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtOrderSlipDateTo.Checked = false;
            this.txtOrderSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtOrderSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOrderSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtOrderSlipDateTo.Location = new System.Drawing.Point(142, 125);
            this.txtOrderSlipDateTo.Name = "txtOrderSlipDateTo";
            this.txtOrderSlipDateTo.ShowCheckBox = true;
            this.txtOrderSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtOrderSlipDateTo.TabIndex = 15;
            // 
            // txtOrderSlipDateFrom
            // 
            this.txtOrderSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderSlipDateFrom.Checked = false;
            this.txtOrderSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtOrderSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOrderSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtOrderSlipDateFrom.Location = new System.Drawing.Point(5, 125);
            this.txtOrderSlipDateFrom.Name = "txtOrderSlipDateFrom";
            this.txtOrderSlipDateFrom.ShowCheckBox = true;
            this.txtOrderSlipDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtOrderSlipDateFrom.TabIndex = 14;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label9);
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Controls.Add(this.label11);
            this.pRight_1.Controls.Add(this.label1);
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 189);
            this.pRight_1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "  纳入先名称";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "  纳入先";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "  合同编号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "  机械番号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "  出库日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "  销售日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 191);
            this.pLeft.TabIndex = 2;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnEndCustomer);
            this.pleft_2.Controls.Add(this.btnCustomer);
            this.pleft_2.Controls.Add(this.txtOrderSlipNumber);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Controls.Add(this.txtEndCustomerName);
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Controls.Add(this.txtEndCustomerCode);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 189);
            this.pleft_2.TabIndex = 5;
            // 
            // btnEndCustomer
            // 
            this.btnEndCustomer.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnEndCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEndCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEndCustomer.FlatAppearance.BorderSize = 0;
            this.btnEndCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEndCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEndCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndCustomer.Location = new System.Drawing.Point(261, 123);
            this.btnEndCustomer.Name = "btnEndCustomer";
            this.btnEndCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnEndCustomer.TabIndex = 5;
            this.btnEndCustomer.UseVisualStyleBackColor = true;
            this.btnEndCustomer.Click += new System.EventHandler(this.btnEndCustomer_Click);
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
            this.btnCustomer.Location = new System.Drawing.Point(261, 65);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // txtOrderSlipNumber
            // 
            this.txtOrderSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderSlipNumber.Location = new System.Drawing.Point(5, 35);
            this.txtOrderSlipNumber.Name = "txtOrderSlipNumber";
            this.txtOrderSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderSlipNumber.TabIndex = 1;
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 95);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtEndCustomerName
            // 
            this.txtEndCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEndCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerName.Enabled = false;
            this.txtEndCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerName.Location = new System.Drawing.Point(5, 155);
            this.txtEndCustomerName.Name = "txtEndCustomerName";
            this.txtEndCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerName.TabIndex = 0;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 65);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // txtEndCustomerCode
            // 
            this.txtEndCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtEndCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerCode.Location = new System.Drawing.Point(5, 125);
            this.txtEndCustomerCode.Name = "txtEndCustomerCode";
            this.txtEndCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerCode.TabIndex = 4;
            this.txtEndCustomerCode.Leave += new System.EventHandler(this.txtEndCustomerCode_Leave);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 189);
            this.pLeft_1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "  出库编号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "  销售单号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  代理店";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  需要家";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  代理店名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  需要家名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(1289, 522);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 29);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.DataPropertyName = "ROW";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.NO.FillWeight = 50F;
            this.NO.Frozen = true;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 35;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.Frozen = true;
            this.SLIP_NUMBER.HeaderText = "出库编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 70;
            // 
            // ORDER_SLIP_NUMBER
            // 
            this.ORDER_SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ORDER_SLIP_NUMBER.DataPropertyName = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.Frozen = true;
            this.ORDER_SLIP_NUMBER.HeaderText = "销售单号";
            this.ORDER_SLIP_NUMBER.Name = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.ReadOnly = true;
            this.ORDER_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ENDER_CUSTOMER_NAME
            // 
            this.ENDER_CUSTOMER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ENDER_CUSTOMER_NAME.DataPropertyName = "ENDER_CUSTOMER_NAME";
            this.ENDER_CUSTOMER_NAME.FillWeight = 150F;
            this.ENDER_CUSTOMER_NAME.Frozen = true;
            this.ENDER_CUSTOMER_NAME.HeaderText = "需要家名称";
            this.ENDER_CUSTOMER_NAME.Name = "ENDER_CUSTOMER_NAME";
            this.ENDER_CUSTOMER_NAME.ReadOnly = true;
            this.ENDER_CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENDER_CUSTOMER_NAME.Width = 200;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLIP_DATE.FillWeight = 90F;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "出库日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 90;
            // 
            // LINE_NUMBER
            // 
            this.LINE_NUMBER.DataPropertyName = "LINE_NUMBER";
            this.LINE_NUMBER.HeaderText = "明细编号";
            this.LINE_NUMBER.Name = "LINE_NUMBER";
            this.LINE_NUMBER.ReadOnly = true;
            this.LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LINE_NUMBER.Width = 70;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "商品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_CODE.Width = 70;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.FillWeight = 150F;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 200;
            // 
            // ORDER_QUANTITY
            // 
            this.ORDER_QUANTITY.DataPropertyName = "ORDER_QUANTITY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ORDER_QUANTITY.DefaultCellStyle = dataGridViewCellStyle4;
            this.ORDER_QUANTITY.HeaderText = "受注数量";
            this.ORDER_QUANTITY.Name = "ORDER_QUANTITY";
            this.ORDER_QUANTITY.ReadOnly = true;
            this.ORDER_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_QUANTITY.Width = 70;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle5;
            this.QUANTITY.HeaderText = "出库数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 70;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.DataPropertyName = "UNIT_NAME";
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 42;
            // 
            // DEPARTUAL_WAREHOUSE_NAME
            // 
            this.DEPARTUAL_WAREHOUSE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DEPARTUAL_WAREHOUSE_NAME.DataPropertyName = "DEPARTUAL_WAREHOUSE_NAME";
            this.DEPARTUAL_WAREHOUSE_NAME.FillWeight = 150F;
            this.DEPARTUAL_WAREHOUSE_NAME.HeaderText = "出库仓库";
            this.DEPARTUAL_WAREHOUSE_NAME.Name = "DEPARTUAL_WAREHOUSE_NAME";
            this.DEPARTUAL_WAREHOUSE_NAME.ReadOnly = true;
            this.DEPARTUAL_WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEPARTUAL_WAREHOUSE_NAME.Width = 200;
            // 
            // STATUS_FLAG
            // 
            this.STATUS_FLAG.DataPropertyName = "STATUS_FLAG";
            this.STATUS_FLAG.HeaderText = "STATUS_FLAG";
            this.STATUS_FLAG.Name = "STATUS_FLAG";
            this.STATUS_FLAG.ReadOnly = true;
            this.STATUS_FLAG.Visible = false;
            this.STATUS_FLAG.Width = 125;
            // 
            // FrmShipmentSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1035, 663);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShipmentSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出库查询";
            this.Load += new System.EventHandler(this.FrmShipmentSearch_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnShipper;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustomerPoNumber;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtOrderSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtOrderSlipDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnEndCustomer;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtEndCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtEndCustomerCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeliveryPoint;
        private System.Windows.Forms.TextBox txtDeliveryPointName;
        private System.Windows.Forms.TextBox txtDeliveryPointCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOrderSlipNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDER_CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTUAL_WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_FLAG;
    }
}