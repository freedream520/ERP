namespace CZZD.ERP.WinUI
{
    partial class FrmSlipTypeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlipTypeDialog));
            this.pBody = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.txtIndicatesOrder = new System.Windows.Forms.TextBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnCompany = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.pLeft = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pBody.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pLeft);
            this.pBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(442, 187);
            this.pBody.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.txtIndicatesOrder);
            this.pRight.Controls.Add(this.cboType);
            this.pRight.Controls.Add(this.btnCompany);
            this.pRight.Controls.Add(this.txtCompanyName);
            this.pRight.Controls.Add(this.txtCode);
            this.pRight.Controls.Add(this.txtName);
            this.pRight.Controls.Add(this.txtCompanyCode);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(120, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(318, 183);
            this.pRight.TabIndex = 1;
            // 
            // txtIndicatesOrder
            // 
            this.txtIndicatesOrder.BackColor = System.Drawing.SystemColors.Info;
            this.txtIndicatesOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndicatesOrder.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtIndicatesOrder.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtIndicatesOrder.Location = new System.Drawing.Point(5, 155);
            this.txtIndicatesOrder.MaxLength = 8;
            this.txtIndicatesOrder.Name = "txtIndicatesOrder";
            this.txtIndicatesOrder.Size = new System.Drawing.Size(250, 25);
            this.txtIndicatesOrder.TabIndex = 25;
            this.txtIndicatesOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtIndicatesOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(5, 5);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(250, 25);
            this.cboType.TabIndex = 24;
            // 
            // btnCompany
            // 
            this.btnCompany.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Location = new System.Drawing.Point(261, 95);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(25, 25);
            this.btnCompany.TabIndex = 5;
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            this.btnCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.btnCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyName.Location = new System.Drawing.Point(5, 125);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyName.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.Location = new System.Drawing.Point(5, 35);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 25);
            this.txtCode.TabIndex = 2;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(5, 65);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyCode.Location = new System.Drawing.Point(5, 95);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyCode.TabIndex = 4;
            this.txtCompanyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCompanyCode.Leave += new System.EventHandler(this.txtCompanyCode_Leave);
            this.txtCompanyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft.Controls.Add(this.label6);
            this.pLeft.Controls.Add(this.label5);
            this.pLeft.Controls.Add(this.label4);
            this.pLeft.Controls.Add(this.label3);
            this.pLeft.Controls.Add(this.label2);
            this.pLeft.Controls.Add(this.label1);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(120, 183);
            this.pLeft.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 116;
            this.label6.Text = " 表 示 顺 序 :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = " 公 司 名 称 :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = " 公 司 编 号 :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " 类 型 名 称 :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " 编          号 :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = " 类          型 :";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(350, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(254, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSlipTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSlipTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单据类型编辑";
            this.Load += new System.EventHandler(this.FrmSlipTypeDialog_Load);
            this.Shown += new System.EventHandler(this.FrmSlipTypeDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductPartsDialog_FormClosed);
            this.pBody.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIndicatesOrder;
    }
}