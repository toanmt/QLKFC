
namespace QLKFC
{
    partial class ChiTietPhieuDatHang
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
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.dgvNhapHang = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHuyDonDatHang = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.datetimpick = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaDonHang = new System.Windows.Forms.Label();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.Enabled = false;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Đag xử lý",
            "Đang giao hàng"});
            this.cbTrangThai.Location = new System.Drawing.Point(143, 60);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(109, 28);
            this.cbTrangThai.TabIndex = 49;
            this.cbTrangThai.Text = "Đang xử lý";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên nguyên liệu";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã nguyên liệu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Nguyên Liệu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDong.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(701, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 49);
            this.btnDong.TabIndex = 46;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.BackColor = System.Drawing.Color.Red;
            this.btnNhapKho.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNhapKho.ForeColor = System.Drawing.Color.White;
            this.btnNhapKho.Location = new System.Drawing.Point(434, 347);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(159, 82);
            this.btnNhapKho.TabIndex = 39;
            this.btnNhapKho.Text = "Nhập Kho";
            this.btnNhapKho.UseVisualStyleBackColor = false;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // dgvNhapHang
            // 
            this.dgvNhapHang.AllowUserToAddRows = false;
            this.dgvNhapHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column8,
            this.Column7,
            this.Column9,
            this.Column5});
            this.dgvNhapHang.Location = new System.Drawing.Point(17, 92);
            this.dgvNhapHang.Name = "dgvNhapHang";
            this.dgvNhapHang.RowHeadersWidth = 51;
            this.dgvNhapHang.RowTemplate.Height = 29;
            this.dgvNhapHang.Size = new System.Drawing.Size(767, 234);
            this.dgvNhapHang.TabIndex = 38;
            this.dgvNhapHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapHang_CellClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Tên nguyên liệu";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Đơn giá";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Số lượng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Tổng tiền";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số lượng nhập";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Trạng thái";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số lượng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // btnHuyDonDatHang
            // 
            this.btnHuyDonDatHang.BackColor = System.Drawing.Color.Red;
            this.btnHuyDonDatHang.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHuyDonDatHang.ForeColor = System.Drawing.Color.White;
            this.btnHuyDonDatHang.Location = new System.Drawing.Point(17, 347);
            this.btnHuyDonDatHang.Name = "btnHuyDonDatHang";
            this.btnHuyDonDatHang.Size = new System.Drawing.Size(235, 82);
            this.btnHuyDonDatHang.TabIndex = 51;
            this.btnHuyDonDatHang.Text = "Hủy đơn đặt hàng";
            this.btnHuyDonDatHang.UseVisualStyleBackColor = false;
            this.btnHuyDonDatHang.Click += new System.EventHandler(this.btnHuyDonDatHang_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(469, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 53;
            this.label2.Text = "Ngày đặt hàng :";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(17, 366);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(89, 38);
            this.lblNote.TabIndex = 54;
            this.lblNote.Text = "Note";
            // 
            // datetimpick
            // 
            this.datetimpick.Enabled = false;
            this.datetimpick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimpick.Location = new System.Drawing.Point(639, 61);
            this.datetimpick.Name = "datetimpick";
            this.datetimpick.Size = new System.Drawing.Size(145, 27);
            this.datetimpick.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(17, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 23);
            this.label8.TabIndex = 58;
            this.label8.Text = "Store ID : 044";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(17, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 23);
            this.label7.TabIndex = 57;
            this.label7.Text = "KFC Trần Phú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(253, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 40);
            this.label1.TabIndex = 59;
            this.label1.Text = "Đơn hàng : ";
            // 
            // lblMaDonHang
            // 
            this.lblMaDonHang.AutoSize = true;
            this.lblMaDonHang.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaDonHang.Location = new System.Drawing.Point(469, 16);
            this.lblMaDonHang.Name = "lblMaDonHang";
            this.lblMaDonHang.Size = new System.Drawing.Size(36, 40);
            this.lblMaDonHang.TabIndex = 60;
            this.lblMaDonHang.Text = "X";
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.Red;
            this.btnHoanThanh.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.Location = new System.Drawing.Point(611, 347);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(159, 82);
            this.btnHoanThanh.TabIndex = 61;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // ChiTietPhieuDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.lblMaDonHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.datetimpick);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHuyDonDatHang);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnNhapKho);
            this.Controls.Add(this.dgvNhapHang);
            this.Controls.Add(this.label3);
            this.Name = "ChiTietPhieuDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn đặt hàng : X";
            this.Load += new System.EventHandler(this.ChiTietPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnNhapKho;
        public System.Windows.Forms.DataGridView dgvNhapHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnHuyDonDatHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.DateTimePicker datetimpick;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaDonHang;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}