
namespace QLKFC
{
    partial class QuanLyBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyBaoCao));
            this.panel_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTenBaoCao = new System.Windows.Forms.Panel();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLocDuLieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLocDuLieu = new System.Windows.Forms.Button();
            this.btnHienThiToanBo = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPRDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.lblTenBaoCao.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.Red;
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Controls.Add(this.pictureBox3);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(912, 84);
            this.panel_header.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(264, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách báo cáo";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(831, 75);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(8, 8);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // lblTenBaoCao
            // 
            this.lblTenBaoCao.Controls.Add(this.btnXuatBaoCao);
            this.lblTenBaoCao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTenBaoCao.Location = new System.Drawing.Point(0, 445);
            this.lblTenBaoCao.Name = "lblTenBaoCao";
            this.lblTenBaoCao.Size = new System.Drawing.Size(912, 188);
            this.lblTenBaoCao.TabIndex = 4;
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatBaoCao.BackColor = System.Drawing.Color.Red;
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXuatBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(718, 62);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(182, 102);
            this.btnXuatBaoCao.TabIndex = 35;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = false;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbLocDuLieu);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnLocDuLieu);
            this.panel2.Controls.Add(this.btnHienThiToanBo);
            this.panel2.Controls.Add(this.dgvBaoCao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 361);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(236, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 47);
            this.label3.TabIndex = 37;
            this.label3.Text = "X";
            // 
            // cbLocDuLieu
            // 
            this.cbLocDuLieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLocDuLieu.FormattingEnabled = true;
            this.cbLocDuLieu.Items.AddRange(new object[] {
            "Xuất hàng",
            "Hủy hàng"});
            this.cbLocDuLieu.Location = new System.Drawing.Point(487, 26);
            this.cbLocDuLieu.Name = "cbLocDuLieu";
            this.cbLocDuLieu.Size = new System.Drawing.Size(162, 28);
            this.cbLocDuLieu.TabIndex = 34;
            this.cbLocDuLieu.Text = "Nhập hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 47);
            this.label2.TabIndex = 36;
            this.label2.Text = "Danh Sách";
            // 
            // btnLocDuLieu
            // 
            this.btnLocDuLieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLocDuLieu.BackColor = System.Drawing.Color.Red;
            this.btnLocDuLieu.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLocDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLocDuLieu.Location = new System.Drawing.Point(302, 6);
            this.btnLocDuLieu.Name = "btnLocDuLieu";
            this.btnLocDuLieu.Size = new System.Drawing.Size(182, 64);
            this.btnLocDuLieu.TabIndex = 33;
            this.btnLocDuLieu.Text = "Loc dữ liệu";
            this.btnLocDuLieu.UseVisualStyleBackColor = false;
            this.btnLocDuLieu.Click += new System.EventHandler(this.btnLocDuLieu_Click);
            // 
            // btnHienThiToanBo
            // 
            this.btnHienThiToanBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHienThiToanBo.BackColor = System.Drawing.Color.Red;
            this.btnHienThiToanBo.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHienThiToanBo.ForeColor = System.Drawing.Color.White;
            this.btnHienThiToanBo.Location = new System.Drawing.Point(651, 6);
            this.btnHienThiToanBo.Name = "btnHienThiToanBo";
            this.btnHienThiToanBo.Size = new System.Drawing.Size(249, 62);
            this.btnHienThiToanBo.TabIndex = 35;
            this.btnHienThiToanBo.Text = "Hiển thị toàn bộ";
            this.btnHienThiToanBo.UseVisualStyleBackColor = false;
            this.btnHienThiToanBo.Click += new System.EventHandler(this.btnHienThiToanBo_Click);
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBaoCao.ColumnHeadersHeight = 45;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvBaoCao.Location = new System.Drawing.Point(12, 74);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 29;
            this.dgvBaoCao.Size = new System.Drawing.Size(888, 281);
            this.dgvBaoCao.TabIndex = 0;
            this.dgvBaoCao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaoCao_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 53.04351F;
            this.Column1.HeaderText = "Mã báo cáo";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 55.51887F;
            this.Column2.HeaderText = "Tên nhân viên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 64.17112F;
            this.Column3.HeaderText = "Ngày lập";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 55.51887F;
            this.Column4.HeaderText = "Loại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 55.51887F;
            this.Column5.HeaderText = "StoreID";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.FillWeight = 316.2287F;
            this.Column6.HeaderText = "Mô tả";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // printPRDialog
            // 
            this.printPRDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPRDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPRDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPRDialog.Document = this.printDoc;
            this.printPRDialog.Enabled = true;
            this.printPRDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPRDialog.Icon")));
            this.printPRDialog.Name = "printPRDialog";
            this.printPRDialog.Visible = false;
            // 
            // QuanLyBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 633);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTenBaoCao);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyBaoCao";
            this.Text = "QuanLyBaoCao";
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.lblTenBaoCao.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel lblTenBaoCao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.ComboBox cbLocDuLieu;
        private System.Windows.Forms.Button btnLocDuLieu;
        private System.Windows.Forms.Button btnHienThiToanBo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXuatBaoCao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printPRDialog;
    }
}