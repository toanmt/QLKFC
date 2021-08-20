
namespace QLKFC
{
    partial class QuanLyHoaDon
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtpick1 = new System.Windows.Forms.DateTimePicker();
            this.dtpick2 = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            this.btncuoi = new System.Windows.Forms.Button();
            this.btnTrangsau = new System.Windows.Forms.Button();
            this.btnTrangtrc = new System.Windows.Forms.Button();
            this.btnTrangHienTai = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvHDBH = new System.Windows.Forms.DataGridView();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.Red;
            this.panel_header.Controls.Add(this.pictureBox2);
            this.panel_header.Controls.Add(this.pictureBox1);
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(912, 84);
            this.panel_header.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::QLKFC.Properties.Resources.iconTrinhquanlyHoaDon;
            this.pictureBox2.Location = new System.Drawing.Point(711, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::QLKFC.Properties.Resources.iconTrinhquanlyHoaDon;
            this.pictureBox1.Location = new System.Drawing.Point(99, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(279, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa Đơn Bán Hàng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnChiTiet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 74);
            this.panel1.TabIndex = 3;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiTiet.BackColor = System.Drawing.Color.Red;
            this.btnChiTiet.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(24, 15);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(172, 47);
            this.btnChiTiet.TabIndex = 22;
            this.btnChiTiet.Text = "Chi Tiết";
            this.btnChiTiet.UseVisualStyleBackColor = false;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTimKiem.Location = new System.Drawing.Point(155, 23);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(172, 27);
            this.txtTimKiem.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimKiem.BackColor = System.Drawing.Color.Red;
            this.btnTimKiem.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(24, 16);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 36);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpick1
            // 
            this.dtpick1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpick1.CustomFormat = "dd/MM/yyy";
            this.dtpick1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpick1.Location = new System.Drawing.Point(24, 65);
            this.dtpick1.Name = "dtpick1";
            this.dtpick1.Size = new System.Drawing.Size(125, 27);
            this.dtpick1.TabIndex = 1;
            this.dtpick1.Value = new System.DateTime(2021, 8, 12, 14, 46, 6, 0);
            // 
            // dtpick2
            // 
            this.dtpick2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpick2.CustomFormat = "dd/MM/yyy";
            this.dtpick2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpick2.Location = new System.Drawing.Point(766, 65);
            this.dtpick2.Name = "dtpick2";
            this.dtpick2.Size = new System.Drawing.Size(124, 27);
            this.dtpick2.TabIndex = 10;
            this.dtpick2.Value = new System.DateTime(2021, 8, 12, 14, 45, 58, 0);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.BackColor = System.Drawing.Color.Red;
            this.btnThongKe.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(400, 47);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(150, 45);
            this.btnThongKe.TabIndex = 11;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnDau
            // 
            this.btnDau.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDau.Location = new System.Drawing.Point(163, 428);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(94, 29);
            this.btnDau.TabIndex = 23;
            this.btnDau.Text = "Đầu";
            this.btnDau.UseVisualStyleBackColor = true;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // btncuoi
            // 
            this.btncuoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btncuoi.Location = new System.Drawing.Point(642, 428);
            this.btncuoi.Name = "btncuoi";
            this.btncuoi.Size = new System.Drawing.Size(94, 29);
            this.btncuoi.TabIndex = 24;
            this.btncuoi.Text = "Cuối";
            this.btncuoi.UseVisualStyleBackColor = true;
            this.btncuoi.Click += new System.EventHandler(this.btncuoi_Click);
            // 
            // btnTrangsau
            // 
            this.btnTrangsau.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTrangsau.Location = new System.Drawing.Point(518, 428);
            this.btnTrangsau.Name = "btnTrangsau";
            this.btnTrangsau.Size = new System.Drawing.Size(94, 29);
            this.btnTrangsau.TabIndex = 26;
            this.btnTrangsau.Text = "Trang sau";
            this.btnTrangsau.UseVisualStyleBackColor = true;
            this.btnTrangsau.Click += new System.EventHandler(this.btnTrangsau_Click);
            // 
            // btnTrangtrc
            // 
            this.btnTrangtrc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTrangtrc.Location = new System.Drawing.Point(276, 428);
            this.btnTrangtrc.Name = "btnTrangtrc";
            this.btnTrangtrc.Size = new System.Drawing.Size(94, 29);
            this.btnTrangtrc.TabIndex = 27;
            this.btnTrangtrc.Text = "Trang trước";
            this.btnTrangtrc.UseVisualStyleBackColor = true;
            this.btnTrangtrc.Click += new System.EventHandler(this.btnTrangtrc_Click);
            // 
            // btnTrangHienTai
            // 
            this.btnTrangHienTai.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTrangHienTai.Location = new System.Drawing.Point(421, 428);
            this.btnTrangHienTai.Name = "btnTrangHienTai";
            this.btnTrangHienTai.Size = new System.Drawing.Size(58, 29);
            this.btnTrangHienTai.TabIndex = 28;
            this.btnTrangHienTai.Text = "1";
            this.btnTrangHienTai.UseVisualStyleBackColor = true;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHienThi.BackColor = System.Drawing.Color.Red;
            this.btnHienThi.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHienThi.ForeColor = System.Drawing.Color.White;
            this.btnHienThi.Location = new System.Drawing.Point(593, 9);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(297, 47);
            this.btnHienThi.TabIndex = 29;
            this.btnHienThi.Text = "Hiển thị toàn bộ";
            this.btnHienThi.UseVisualStyleBackColor = false;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.dgvHDBH);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Controls.Add(this.dtpick1);
            this.panel3.Controls.Add(this.btnTrangHienTai);
            this.panel3.Controls.Add(this.btnHienThi);
            this.panel3.Controls.Add(this.btnTrangtrc);
            this.panel3.Controls.Add(this.btnThongKe);
            this.panel3.Controls.Add(this.btnTrangsau);
            this.panel3.Controls.Add(this.dtpick2);
            this.panel3.Controls.Add(this.btncuoi);
            this.panel3.Controls.Add(this.btnDau);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 481);
            this.panel3.TabIndex = 30;
            // 
            // dgvHDBH
            // 
            this.dgvHDBH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHDBH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHDBH.ColumnHeadersHeight = 70;
            this.dgvHDBH.Location = new System.Drawing.Point(24, 108);
            this.dgvHDBH.MultiSelect = false;
            this.dgvHDBH.Name = "dgvHDBH";
            this.dgvHDBH.ReadOnly = true;
            this.dgvHDBH.RowHeadersWidth = 51;
            this.dgvHDBH.RowTemplate.Height = 29;
            this.dgvHDBH.Size = new System.Drawing.Size(866, 273);
            this.dgvHDBH.TabIndex = 0;
            this.dgvHDBH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDBH_CellClick);
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 639);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyHoaDon";
            this.Text = "Quản_Lý_Hóa_Đơn";
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpick1;
        private System.Windows.Forms.DateTimePicker dtpick2;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Button btncuoi;
        private System.Windows.Forms.Button btnTrangsau;
        private System.Windows.Forms.Button btnTrangtrc;
        private System.Windows.Forms.Button btnTrangHienTai;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvHDBH;
    }
}