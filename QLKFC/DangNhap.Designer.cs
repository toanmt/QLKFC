﻿
namespace QLKFC
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 60);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(386, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(63, 182);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(63, 228);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(114, 292);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(82, 22);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(128, 188);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(208, 23);
            this.txtTaiKhoan.TabIndex = 5;
            this.txtTaiKhoan.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaiKhoan_Validating);
            this.txtTaiKhoan.Validated += new System.EventHandler(this.txtTaiKhoan_Validated);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(128, 233);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(208, 23);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.Validating += new System.ComponentModel.CancelEventHandler(this.txtMatKhau_Validating);
            this.txtMatKhau.Validated += new System.EventHandler(this.txtMatKhau_Validated);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(257, 292);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 22);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 338);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}