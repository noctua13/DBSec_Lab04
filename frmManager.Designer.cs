namespace DBSecurity_Lab04_Public
{
    partial class frmManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNVLogin = new System.Windows.Forms.TextBox();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnQLLop = new System.Windows.Forms.Button();
            this.btnQLSV = new System.Windows.Forms.Button();
            this.btnQLDiem = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên đang đăng nhập:";
            // 
            // txtMaNVLogin
            // 
            this.txtMaNVLogin.Enabled = false;
            this.txtMaNVLogin.Location = new System.Drawing.Point(210, 31);
            this.txtMaNVLogin.Name = "txtMaNVLogin";
            this.txtMaNVLogin.Size = new System.Drawing.Size(100, 20);
            this.txtMaNVLogin.TabIndex = 1;
            // 
            // btnQLNV
            // 
            this.btnQLNV.Location = new System.Drawing.Point(59, 75);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(75, 23);
            this.btnQLNV.TabIndex = 2;
            this.btnQLNV.Text = "QLNV";
            this.btnQLNV.UseVisualStyleBackColor = true;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnQLLop
            // 
            this.btnQLLop.Location = new System.Drawing.Point(210, 75);
            this.btnQLLop.Name = "btnQLLop";
            this.btnQLLop.Size = new System.Drawing.Size(75, 23);
            this.btnQLLop.TabIndex = 3;
            this.btnQLLop.Text = "QLLop";
            this.btnQLLop.UseVisualStyleBackColor = true;
            this.btnQLLop.Click += new System.EventHandler(this.btnQLLop_Click);
            // 
            // btnQLSV
            // 
            this.btnQLSV.Location = new System.Drawing.Point(59, 119);
            this.btnQLSV.Name = "btnQLSV";
            this.btnQLSV.Size = new System.Drawing.Size(75, 23);
            this.btnQLSV.TabIndex = 4;
            this.btnQLSV.Text = "QLSV";
            this.btnQLSV.UseVisualStyleBackColor = true;
            this.btnQLSV.Click += new System.EventHandler(this.btnQLSV_Click);
            // 
            // btnQLDiem
            // 
            this.btnQLDiem.Location = new System.Drawing.Point(210, 119);
            this.btnQLDiem.Name = "btnQLDiem";
            this.btnQLDiem.Size = new System.Drawing.Size(75, 23);
            this.btnQLDiem.TabIndex = 5;
            this.btnQLDiem.Text = "QLDiem";
            this.btnQLDiem.UseVisualStyleBackColor = true;
            this.btnQLDiem.Click += new System.EventHandler(this.btnQLDiem_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(136, 163);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(75, 23);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 204);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnQLDiem);
            this.Controls.Add(this.btnQLSV);
            this.Controls.Add(this.btnQLLop);
            this.Controls.Add(this.btnQLNV);
            this.Controls.Add(this.txtMaNVLogin);
            this.Controls.Add(this.label1);
            this.Name = "frmManager";
            this.Text = "Màn hình quản lý";
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNVLogin;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnQLLop;
        private System.Windows.Forms.Button btnQLSV;
        private System.Windows.Forms.Button btnQLDiem;
        private System.Windows.Forms.Button btnDangXuat;
    }
}