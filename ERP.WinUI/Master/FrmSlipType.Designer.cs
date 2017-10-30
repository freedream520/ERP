namespace CZZD.ERP.WinUI
{
    partial class FrmSlipType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlipType));
            this.pBody = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INDICATES_ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
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
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Controls.Add(this.pLeft);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1011, 609);
            this.pSearch.TabIndex = 11;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControl.Location = new System.Drawing.Point(0, 579);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1011, 30);
            this.pgControl.TabIndex = 28;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TYPE_CODE,
            this.TYPE_NAME,
            this.CODE,
            this.NAME,
            this.COMPANY_NAME,
            this.INDICATES_ORDER,
            this.CREATE_USER,
            this.CREATE_DATE_TIME,
            this.LAST_UPDATE_USER,
            this.LAST_UPDATE_TIME});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 128);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1011, 450);
            this.dgvData.TabIndex = 27;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(440, 125);
            this.pLeft.TabIndex = 26;
            // 
            // pLeft_2
            // 
            this.pLeft_2.Controls.Add(this.cboType);
            this.pLeft_2.Controls.Add(this.txtOrderCode);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(118, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(320, 123);
            this.pLeft_2.TabIndex = 1;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(5, 5);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(250, 25);
            this.cboType.TabIndex = 23;
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOrderCode.Location = new System.Drawing.Point(5, 35);
            this.txtOrderCode.MaxLength = 20;
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.Size = new System.Drawing.Size(250, 23);
            this.txtOrderCode.TabIndex = 22;
            this.txtOrderCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.label1.TabIndex = 23;
            this.label1.Text = " 类          型 ：";
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
            this.label2.TabIndex = 21;
            this.label2.Text = " 编          号 ：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(1018, 30);
            this.MasterToolBar.TabIndex = 10;
            this.MasterToolBar.DoCancel_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCancel_Click);
            this.MasterToolBar.DoModify_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoModify_Click);
            this.MasterToolBar.DoExport_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoExport_Click);
            this.MasterToolBar.DoNew_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoNew_Click);
            this.MasterToolBar.DoDelete_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoDelete_Click);
            this.MasterToolBar.DoSearch_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoSearch_Click);
            this.MasterToolBar.DoCopy_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCopy_Click);
            // 
            // TYPE_CODE
            // 
            this.TYPE_CODE.DataPropertyName = "TYPE_CODE";
            this.TYPE_CODE.HeaderText = "TYPE_CODE";
            this.TYPE_CODE.Name = "TYPE_CODE";
            this.TYPE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TYPE_CODE.Visible = false;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "TYPE_NAME";
            this.TYPE_NAME.HeaderText = "类型";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            this.TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "编号";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COMPANY_NAME
            // 
            this.COMPANY_NAME.DataPropertyName = "COMPANY_NAME";
            this.COMPANY_NAME.HeaderText = "公司名称";
            this.COMPANY_NAME.Name = "COMPANY_NAME";
            this.COMPANY_NAME.ReadOnly = true;
            this.COMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INDICATES_ORDER
            // 
            this.INDICATES_ORDER.DataPropertyName = "INDICATES_ORDER";
            this.INDICATES_ORDER.HeaderText = "表示顺序";
            this.INDICATES_ORDER.Name = "INDICATES_ORDER";
            this.INDICATES_ORDER.ReadOnly = true;
            // 
            // CREATE_USER
            // 
            this.CREATE_USER.DataPropertyName = "CREATE_USER";
            this.CREATE_USER.HeaderText = "创建人";
            this.CREATE_USER.Name = "CREATE_USER";
            this.CREATE_USER.ReadOnly = true;
            this.CREATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_DATE_TIME
            // 
            this.CREATE_DATE_TIME.DataPropertyName = "CREATE_DATE_TIME";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.CREATE_DATE_TIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.CREATE_DATE_TIME.HeaderText = "创建时间";
            this.CREATE_DATE_TIME.Name = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.ReadOnly = true;
            this.CREATE_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_USER
            // 
            this.LAST_UPDATE_USER.DataPropertyName = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.HeaderText = "最后更新人";
            this.LAST_UPDATE_USER.Name = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.ReadOnly = true;
            this.LAST_UPDATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.LAST_UPDATE_TIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmSlipType
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1025, 671);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSlipType";
            this.Text = "单据类型设定";
            this.Load += new System.EventHandler(this.FrmSlipType_Load);
            this.pBody.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INDICATES_ORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
    }
}