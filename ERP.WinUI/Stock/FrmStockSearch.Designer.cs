namespace CZZD.ERP.WinUI
{
    partial class FrmStockSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockSearch));
            this.pBody = new System.Windows.Forms.Panel();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAlloation = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME_JP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOATION_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NO_ALLOATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPT_PLAN_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnProduct_Group = new System.Windows.Forms.Button();
            this.txtWarehouseCode = new System.Windows.Forms.TextBox();
            this.txtProduct_Group_Name = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtProduct_Group_Code = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pHeader.SuspendLayout();
            this.pRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.btnReceipt);
            this.pBody.Controls.Add(this.btnCancel);
            this.pBody.Controls.Add(this.btnAlloation);
            this.pBody.Controls.Add(this.btnPrint);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 653);
            this.pBody.TabIndex = 0;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceipt.Location = new System.Drawing.Point(723, 619);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(105, 30);
            this.btnReceipt.TabIndex = 9;
            this.btnReceipt.Text = "入库预定详细";
            this.btnReceipt.UseVisualStyleBackColor = true;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(930, 619);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "关　闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAlloation
            // 
            this.btnAlloation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlloation.Location = new System.Drawing.Point(834, 619);
            this.btnAlloation.Name = "btnAlloation";
            this.btnAlloation.Size = new System.Drawing.Size(90, 30);
            this.btnAlloation.TabIndex = 10;
            this.btnAlloation.Text = "引当详细";
            this.btnAlloation.UseVisualStyleBackColor = true;
            this.btnAlloation.Click += new System.EventHandler(this.btnAlloation_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(627, 619);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.PRODUCT_NAME_JP,
            this.SPEC,
            this.WAREHOUSE_NAME,
            this.QUANTITY,
            this.ALLOATION_QUANTITY,
            this.NO_ALLOATION,
            this.RECEIPT_PLAN_QUANTITY,
            this.WAREHOUSE_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1015, 413);
            this.dgvData.TabIndex = 7;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.DataPropertyName = "ROW";
            this.NO.Frozen = true;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 40;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.Frozen = true;
            this.PRODUCT_CODE.HeaderText = "商品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_CODE.Width = 120;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.Frozen = true;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 150;
            // 
            // PRODUCT_NAME_JP
            // 
            this.PRODUCT_NAME_JP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_NAME_JP.DataPropertyName = "PRODUCT_NAME_JP";
            this.PRODUCT_NAME_JP.Frozen = true;
            this.PRODUCT_NAME_JP.HeaderText = "日文名称";
            this.PRODUCT_NAME_JP.Name = "PRODUCT_NAME_JP";
            this.PRODUCT_NAME_JP.ReadOnly = true;
            this.PRODUCT_NAME_JP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME_JP.Width = 150;
            // 
            // SPEC
            // 
            this.SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.Frozen = true;
            this.SPEC.HeaderText = "商品规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEC.Width = 150;
            // 
            // WAREHOUSE_NAME
            // 
            this.WAREHOUSE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WAREHOUSE_NAME.DataPropertyName = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.HeaderText = "仓库";
            this.WAREHOUSE_NAME.Name = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.ReadOnly = true;
            this.WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WAREHOUSE_NAME.Width = 150;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle3;
            this.QUANTITY.FillWeight = 108.5025F;
            this.QUANTITY.HeaderText = "库存数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 110;
            // 
            // ALLOATION_QUANTITY
            // 
            this.ALLOATION_QUANTITY.DataPropertyName = "ALLOATION_QUANTITY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.ALLOATION_QUANTITY.DefaultCellStyle = dataGridViewCellStyle4;
            this.ALLOATION_QUANTITY.FillWeight = 108.5025F;
            this.ALLOATION_QUANTITY.HeaderText = "引当数量";
            this.ALLOATION_QUANTITY.Name = "ALLOATION_QUANTITY";
            this.ALLOATION_QUANTITY.ReadOnly = true;
            this.ALLOATION_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALLOATION_QUANTITY.Width = 109;
            // 
            // NO_ALLOATION
            // 
            this.NO_ALLOATION.DataPropertyName = "NO_ALLOATION";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.NO_ALLOATION.DefaultCellStyle = dataGridViewCellStyle5;
            this.NO_ALLOATION.FillWeight = 108.5025F;
            this.NO_ALLOATION.HeaderText = "未引当库存数量";
            this.NO_ALLOATION.Name = "NO_ALLOATION";
            this.NO_ALLOATION.ReadOnly = true;
            this.NO_ALLOATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO_ALLOATION.Width = 110;
            // 
            // RECEIPT_PLAN_QUANTITY
            // 
            this.RECEIPT_PLAN_QUANTITY.DataPropertyName = "RECEIPT_PLAN_QUANTITY";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.RECEIPT_PLAN_QUANTITY.DefaultCellStyle = dataGridViewCellStyle6;
            this.RECEIPT_PLAN_QUANTITY.FillWeight = 108.5025F;
            this.RECEIPT_PLAN_QUANTITY.HeaderText = "入库预定数量";
            this.RECEIPT_PLAN_QUANTITY.Name = "RECEIPT_PLAN_QUANTITY";
            this.RECEIPT_PLAN_QUANTITY.ReadOnly = true;
            this.RECEIPT_PLAN_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RECEIPT_PLAN_QUANTITY.Width = 110;
            // 
            // WAREHOUSE_CODE
            // 
            this.WAREHOUSE_CODE.DataPropertyName = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.HeaderText = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.Name = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.ReadOnly = true;
            this.WAREHOUSE_CODE.Visible = false;
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
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.panel2);
            this.pRight.Controls.Add(this.panel3);
            this.pRight.Location = new System.Drawing.Point(512, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(504, 193);
            this.pRight.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txtSpec);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(120, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 191);
            this.panel2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(289, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 191);
            this.panel3.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 193);
            this.pLeft.TabIndex = 1;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnWarehouse);
            this.pleft_2.Controls.Add(this.txtProductCode);
            this.pleft_2.Controls.Add(this.txtProductName);
            this.pleft_2.Controls.Add(this.btnProduct_Group);
            this.pleft_2.Controls.Add(this.txtWarehouseCode);
            this.pleft_2.Controls.Add(this.txtProduct_Group_Name);
            this.pleft_2.Controls.Add(this.txtWarehouseName);
            this.pleft_2.Controls.Add(this.txtProduct_Group_Code);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 191);
            this.pleft_2.TabIndex = 0;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Location = new System.Drawing.Point(261, 4);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 1;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            this.btnWarehouse.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnWarehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductCode.Location = new System.Drawing.Point(5, 125);
            this.txtProductCode.MaxLength = 20;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(250, 25);
            this.txtProductCode.TabIndex = 4;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductName.Location = new System.Drawing.Point(5, 155);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 25);
            this.txtProductName.TabIndex = 5;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnProduct_Group
            // 
            this.btnProduct_Group.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProduct_Group.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduct_Group.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct_Group.FlatAppearance.BorderSize = 0;
            this.btnProduct_Group.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProduct_Group.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProduct_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct_Group.Location = new System.Drawing.Point(261, 65);
            this.btnProduct_Group.Name = "btnProduct_Group";
            this.btnProduct_Group.Size = new System.Drawing.Size(25, 25);
            this.btnProduct_Group.TabIndex = 3;
            this.btnProduct_Group.UseVisualStyleBackColor = true;
            this.btnProduct_Group.Click += new System.EventHandler(this.btnProduct_Group_Click);
            this.btnProduct_Group.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWarehouseCode.Location = new System.Drawing.Point(5, 5);
            this.txtWarehouseCode.MaxLength = 20;
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseCode.TabIndex = 0;
            this.txtWarehouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtWarehouseCode.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            this.txtWarehouseCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProduct_Group_Name
            // 
            this.txtProduct_Group_Name.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProduct_Group_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduct_Group_Name.Enabled = false;
            this.txtProduct_Group_Name.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProduct_Group_Name.Location = new System.Drawing.Point(5, 95);
            this.txtProduct_Group_Name.Name = "txtProduct_Group_Name";
            this.txtProduct_Group_Name.Size = new System.Drawing.Size(250, 25);
            this.txtProduct_Group_Name.TabIndex = 0;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Enabled = false;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseName.Location = new System.Drawing.Point(5, 35);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseName.TabIndex = 0;
            // 
            // txtProduct_Group_Code
            // 
            this.txtProduct_Group_Code.BackColor = System.Drawing.SystemColors.Info;
            this.txtProduct_Group_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduct_Group_Code.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProduct_Group_Code.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProduct_Group_Code.Location = new System.Drawing.Point(5, 65);
            this.txtProduct_Group_Code.MaxLength = 20;
            this.txtProduct_Group_Code.Name = "txtProduct_Group_Code";
            this.txtProduct_Group_Code.Size = new System.Drawing.Size(250, 25);
            this.txtProduct_Group_Code.TabIndex = 2;
            this.txtProduct_Group_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProduct_Group_Code.Leave += new System.EventHandler(this.txtProduct_Group_Code_Leave);
            this.txtProduct_Group_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 191);
            this.pLeft_1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "  种类编号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  商品编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "  种类名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  仓库编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  商品名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  仓库名称";
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
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "  商品规格";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSpec.Location = new System.Drawing.Point(5, 5);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(250, 25);
            this.txtSpec.TabIndex = 7;
            // 
            // FrmStockSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1035, 659);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStockSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "库存查询";
            this.Load += new System.EventHandler(this.FrmStockSearch_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox txtWarehouseCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnAlloation;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProduct_Group;
        private System.Windows.Forms.TextBox txtProduct_Group_Name;
        private System.Windows.Forms.TextBox txtProduct_Group_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME_JP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOATION_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO_ALLOATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_PLAN_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_CODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpec;
    }
}