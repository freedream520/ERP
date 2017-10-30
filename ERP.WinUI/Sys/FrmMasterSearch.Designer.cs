namespace CZZD.ERP.WinUI
{
    partial class FrmMasterSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJapan = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNAME = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pgControlMin = new CZZD.ERP.ComControls.PageControlMin();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.DISP_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_JP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSpec);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtJapan);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblNAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 125);
            this.panel1.TabIndex = 0;
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpec.Location = new System.Drawing.Point(105, 94);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(257, 25);
            this.txtSpec.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "规          格：";
            // 
            // txtJapan
            // 
            this.txtJapan.BackColor = System.Drawing.SystemColors.Info;
            this.txtJapan.Location = new System.Drawing.Point(105, 63);
            this.txtJapan.Name = "txtJapan";
            this.txtJapan.Size = new System.Drawing.Size(257, 25);
            this.txtJapan.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Location = new System.Drawing.Point(105, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(257, 25);
            this.txtName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCode.Location = new System.Drawing.Point(105, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(257, 25);
            this.txtCode.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(534, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNAME
            // 
            this.lblNAME.AutoSize = true;
            this.lblNAME.Location = new System.Drawing.Point(8, 68);
            this.lblNAME.Name = "lblNAME";
            this.lblNAME.Size = new System.Drawing.Size(91, 20);
            this.lblNAME.TabIndex = 1;
            this.lblNAME.Text = "日 文 名 称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "名　　　称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "编　　　号：";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DISP_CODE,
            this.NAME,
            this.NAME_JP,
            this.SPEC,
            this.CODE,
            this.CUSTOMER_CODE});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 125);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(627, 299);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pgControlMin
            // 
            this.pgControlMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControlMin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControlMin.Location = new System.Drawing.Point(0, 424);
            this.pgControlMin.Name = "pgControlMin";
            this.pgControlMin.Size = new System.Drawing.Size(627, 30);
            this.pgControlMin.TabIndex = 3;
            this.pgControlMin.TotalPage = 1;
            this.pgControlMin.Visible = false;
            this.pgControlMin.PageChanged += new CZZD.ERP.ComControls.PageControlMin.BtnClickHandle(this.pgControlMin_PageChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 35);
            this.panel2.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(534, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取　消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(438, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确　定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DISP_CODE
            // 
            this.DISP_CODE.DataPropertyName = "DISP_CODE";
            this.DISP_CODE.HeaderText = "编号";
            this.DISP_CODE.Name = "DISP_CODE";
            this.DISP_CODE.ReadOnly = true;
            this.DISP_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.FillWeight = 120F;
            this.NAME.HeaderText = "名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME_JP
            // 
            this.NAME_JP.DataPropertyName = "NAME_JP";
            this.NAME_JP.HeaderText = "日文名称";
            this.NAME_JP.Name = "NAME_JP";
            this.NAME_JP.ReadOnly = true;
            // 
            // SPEC
            // 
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.HeaderText = "规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.Visible = false;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CODE.Visible = false;
            // 
            // CUSTOMER_CODE
            // 
            this.CUSTOMER_CODE.DataPropertyName = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.HeaderText = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.Name = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.ReadOnly = true;
            this.CUSTOMER_CODE.Visible = false;
            // 
            // FrmMasterSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 489);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pgControlMin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMasterSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检索";
            this.Load += new System.EventHandler(this.FrmMasterSearch_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMasterSearch_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private CZZD.ERP.ComControls.PageControlMin pgControlMin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtJapan;
        private System.Windows.Forms.Label lblNAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISP_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_JP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CODE;
    }
}