namespace CZZD.ERP.WinUI
{
    partial class FrmMasterMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterMachine));
            this.pBody = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.MACHINE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACHINE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATIONS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FANUC_SERIAL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FANUC_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pSearch);
            this.pBody.Controls.Add(this.MasterToolBar);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.pLeft);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1012, 614);
            this.pSearch.TabIndex = 7;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(440, 125);
            this.pLeft.TabIndex = 6;
            // 
            // pLeft_2
            // 
            this.pLeft_2.BackColor = System.Drawing.Color.White;
            this.pLeft_2.Controls.Add(this.txtMachineCode);
            this.pLeft_2.Controls.Add(this.txtMachineName);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(118, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(320, 123);
            this.pLeft_2.TabIndex = 1;
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtMachineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMachineCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMachineCode.Location = new System.Drawing.Point(5, 5);
            this.txtMachineCode.MaxLength = 20;
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(250, 23);
            this.txtMachineCode.TabIndex = 1;
            this.txtMachineCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMachineName
            // 
            this.txtMachineName.BackColor = System.Drawing.SystemColors.Info;
            this.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMachineName.Location = new System.Drawing.Point(5, 35);
            this.txtMachineName.MaxLength = 100;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(250, 23);
            this.txtMachineName.TabIndex = 2;
            this.txtMachineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(118, 123);
            this.pLeft_1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = " 机械编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = " 机械名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 26;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MACHINE_CODE,
            this.MACHINE_NAME,
            this.CUSTOMER_NAME,
            this.PRODUCT_NAME,
            this.STATIONS,
            this.PURCHASE_ORDER_SLIP_NUMBER,
            this.PURCHASE_SLIP_NUMBER,
            this.FANUC_SERIAL_NUMBER,
            this.FANUC_SLIP_NUMBER,
            this.RECEIPT_DATE,
            this.SALE_DATE_TIME,
            this.CREATE_NAME,
            this.CREATE_DATE_TIME,
            this.LAST_UPDATE_NAME,
            this.LAST_UPDATE_TIME});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 127);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 457);
            this.dgvData.TabIndex = 3;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControl.Location = new System.Drawing.Point(0, 584);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 4;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(1018, 30);
            this.MasterToolBar.TabIndex = 6;
            this.MasterToolBar.DoCancel_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCancel_Click);
            this.MasterToolBar.DoModify_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoModify_Click);
            this.MasterToolBar.DoExport_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoExport_Click);
            this.MasterToolBar.DoNew_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoNew_Click);
            this.MasterToolBar.DoDelete_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoDelete_Click);
            this.MasterToolBar.DoSearch_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoSearch_Click);
            this.MasterToolBar.DoCopy_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCopy_Click);
            // 
            // MACHINE_CODE
            // 
            this.MACHINE_CODE.DataPropertyName = "MACHINE_CODE";
            this.MACHINE_CODE.FillWeight = 102.5575F;
            this.MACHINE_CODE.HeaderText = "机械编号";
            this.MACHINE_CODE.Name = "MACHINE_CODE";
            this.MACHINE_CODE.ReadOnly = true;
            this.MACHINE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MACHINE_NAME
            // 
            this.MACHINE_NAME.DataPropertyName = "MACHINE_NAME";
            this.MACHINE_NAME.HeaderText = "机械名称";
            this.MACHINE_NAME.Name = "MACHINE_NAME";
            this.MACHINE_NAME.ReadOnly = true;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.FillWeight = 96.32172F;
            this.CUSTOMER_NAME.HeaderText = "需要家";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.FillWeight = 95.73277F;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STATIONS
            // 
            this.STATIONS.DataPropertyName = "STATIONS";
            this.STATIONS.FillWeight = 95.08823F;
            this.STATIONS.HeaderText = "维修地点";
            this.STATIONS.Name = "STATIONS";
            this.STATIONS.ReadOnly = true;
            this.STATIONS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PURCHASE_ORDER_SLIP_NUMBER
            // 
            this.PURCHASE_ORDER_SLIP_NUMBER.DataPropertyName = "PURCHASE_ORDER_SLIP_NUMBER";
            this.PURCHASE_ORDER_SLIP_NUMBER.HeaderText = "采购编号";
            this.PURCHASE_ORDER_SLIP_NUMBER.Name = "PURCHASE_ORDER_SLIP_NUMBER";
            this.PURCHASE_ORDER_SLIP_NUMBER.ReadOnly = true;
            this.PURCHASE_ORDER_SLIP_NUMBER.Visible = false;
            // 
            // PURCHASE_SLIP_NUMBER
            // 
            this.PURCHASE_SLIP_NUMBER.DataPropertyName = "PURCHASE_SLIP_NUMBER";
            this.PURCHASE_SLIP_NUMBER.HeaderText = "采购发票编号";
            this.PURCHASE_SLIP_NUMBER.Name = "PURCHASE_SLIP_NUMBER";
            // 
            // FANUC_SERIAL_NUMBER
            // 
            this.FANUC_SERIAL_NUMBER.DataPropertyName = "FANUC_SERIAL_NUMBER";
            this.FANUC_SERIAL_NUMBER.HeaderText = "FANUC序列号";
            this.FANUC_SERIAL_NUMBER.Name = "FANUC_SERIAL_NUMBER";
            this.FANUC_SERIAL_NUMBER.ReadOnly = true;
            this.FANUC_SERIAL_NUMBER.Width = 110;
            // 
            // FANUC_SLIP_NUMBER
            // 
            this.FANUC_SLIP_NUMBER.DataPropertyName = "FANUC_SLIP_NUMBER";
            this.FANUC_SLIP_NUMBER.HeaderText = "FANUC编号";
            this.FANUC_SLIP_NUMBER.Name = "FANUC_SLIP_NUMBER";
            this.FANUC_SLIP_NUMBER.ReadOnly = true;
            // 
            // RECEIPT_DATE
            // 
            this.RECEIPT_DATE.DataPropertyName = "RECEIPT_DATE";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.RECEIPT_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.RECEIPT_DATE.HeaderText = "入库日";
            this.RECEIPT_DATE.Name = "RECEIPT_DATE";
            this.RECEIPT_DATE.ReadOnly = true;
            // 
            // SALE_DATE_TIME
            // 
            this.SALE_DATE_TIME.DataPropertyName = "SALE_DATE_TIME";
            this.SALE_DATE_TIME.HeaderText = "销售日期";
            this.SALE_DATE_TIME.Name = "SALE_DATE_TIME";
            // 
            // CREATE_NAME
            // 
            this.CREATE_NAME.DataPropertyName = "CREATE_NAME";
            this.CREATE_NAME.FillWeight = 93.93812F;
            this.CREATE_NAME.HeaderText = "创建人";
            this.CREATE_NAME.Name = "CREATE_NAME";
            this.CREATE_NAME.ReadOnly = true;
            this.CREATE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_DATE_TIME
            // 
            this.CREATE_DATE_TIME.DataPropertyName = "CREATE_DATE_TIME";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.CREATE_DATE_TIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.CREATE_DATE_TIME.FillWeight = 117.6501F;
            this.CREATE_DATE_TIME.HeaderText = "创建时间";
            this.CREATE_DATE_TIME.Name = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.ReadOnly = true;
            this.CREATE_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_NAME
            // 
            this.LAST_UPDATE_NAME.DataPropertyName = "LAST_UPDATE_NAME";
            this.LAST_UPDATE_NAME.FillWeight = 94.54949F;
            this.LAST_UPDATE_NAME.HeaderText = "最后更新人";
            this.LAST_UPDATE_NAME.Name = "LAST_UPDATE_NAME";
            this.LAST_UPDATE_NAME.ReadOnly = true;
            this.LAST_UPDATE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.LAST_UPDATE_TIME.DefaultCellStyle = dataGridViewCellStyle4;
            this.LAST_UPDATE_TIME.FillWeight = 117.2589F;
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LAST_UPDATE_TIME.Width = 110;
            // 
            // FrmMasterMachine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1025, 655);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMasterMachine";
            this.Text = "机械设定";
            this.Load += new System.EventHandler(this.FrmMasterMachine_Load);
            this.pBody.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHINE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHINE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATIONS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FANUC_SERIAL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FANUC_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
    }
}