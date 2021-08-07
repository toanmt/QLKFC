
namespace QLKFC
{
    partial class Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_header = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_control = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_DSSP = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.panel_Loc = new System.Windows.Forms.Panel();
            this.btnChonDoUong = new System.Windows.Forms.Button();
            this.btnChonMonLe = new System.Windows.Forms.Button();
            this.btnChonComBo = new System.Windows.Forms.Button();
            this.panel_Order = new System.Windows.Forms.Panel();
            this.panel_TinhTien = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblVAT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_DSOrder = new System.Windows.Forms.Panel();
            this.dgvDSOrder = new System.Windows.Forms.DataGridView();
            this.Mamon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtKM = new System.Windows.Forms.TextBox();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_control.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel_Loc.SuspendLayout();
            this.panel_Order.SuspendLayout();
            this.panel_TinhTien.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_button.SuspendLayout();
            this.panel_DSOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSOrder)).BeginInit();
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
            this.panel_header.Size = new System.Drawing.Size(930, 84);
            this.panel_header.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::QLKFC.Properties.Resources.online_order;
            this.pictureBox2.Location = new System.Drawing.Point(680, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 62);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLKFC.Properties.Resources.online_order;
            this.pictureBox1.Location = new System.Drawing.Point(227, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 62);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(431, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order";
            // 
            // panel_control
            // 
            this.panel_control.Controls.Add(this.panel1);
            this.panel_control.Controls.Add(this.panel_Order);
            this.panel_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_control.Location = new System.Drawing.Point(0, 84);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(930, 596);
            this.panel_control.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_DSSP);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel_Loc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 596);
            this.panel1.TabIndex = 1;
            // 
            // dgv_DSSP
            // 
            this.dgv_DSSP.AllowUserToResizeRows = false;
            this.dgv_DSSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DSSP.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSSP.EnableHeadersVisualStyles = false;
            this.dgv_DSSP.Location = new System.Drawing.Point(3, 124);
            this.dgv_DSSP.Name = "dgv_DSSP";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_DSSP.RowHeadersVisible = false;
            this.dgv_DSSP.RowHeadersWidth = 51;
            this.dgv_DSSP.RowTemplate.Height = 150;
            this.dgv_DSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DSSP.Size = new System.Drawing.Size(453, 469);
            this.dgv_DSSP.TabIndex = 5;
            this.dgv_DSSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSSP_CellClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Controls.Add(this.txtFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 48);
            this.panel4.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::QLKFC.Properties.Resources.refresh__1_;
            this.button1.Location = new System.Drawing.Point(3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 37);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::QLKFC.Properties.Resources.search;
            this.btnFind.Location = new System.Drawing.Point(400, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 37);
            this.btnFind.TabIndex = 1;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFind.Location = new System.Drawing.Point(65, 6);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(329, 37);
            this.txtFind.TabIndex = 0;
            // 
            // panel_Loc
            // 
            this.panel_Loc.Controls.Add(this.btnChonDoUong);
            this.panel_Loc.Controls.Add(this.btnChonMonLe);
            this.panel_Loc.Controls.Add(this.btnChonComBo);
            this.panel_Loc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Loc.Location = new System.Drawing.Point(0, 0);
            this.panel_Loc.Name = "panel_Loc";
            this.panel_Loc.Size = new System.Drawing.Size(462, 70);
            this.panel_Loc.TabIndex = 0;
            // 
            // btnChonDoUong
            // 
            this.btnChonDoUong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDoUong.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChonDoUong.ForeColor = System.Drawing.Color.Red;
            this.btnChonDoUong.Location = new System.Drawing.Point(306, 6);
            this.btnChonDoUong.Name = "btnChonDoUong";
            this.btnChonDoUong.Size = new System.Drawing.Size(150, 58);
            this.btnChonDoUong.TabIndex = 2;
            this.btnChonDoUong.Text = "Đồ uống";
            this.btnChonDoUong.UseVisualStyleBackColor = true;
            this.btnChonDoUong.Click += new System.EventHandler(this.btnChonDoUong_Click);
            // 
            // btnChonMonLe
            // 
            this.btnChonMonLe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonMonLe.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChonMonLe.ForeColor = System.Drawing.Color.Red;
            this.btnChonMonLe.Location = new System.Drawing.Point(157, 6);
            this.btnChonMonLe.Name = "btnChonMonLe";
            this.btnChonMonLe.Size = new System.Drawing.Size(150, 58);
            this.btnChonMonLe.TabIndex = 1;
            this.btnChonMonLe.Text = "Món ăn";
            this.btnChonMonLe.UseVisualStyleBackColor = true;
            this.btnChonMonLe.Click += new System.EventHandler(this.btnChonMonLe_Click);
            // 
            // btnChonComBo
            // 
            this.btnChonComBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonComBo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChonComBo.ForeColor = System.Drawing.Color.Red;
            this.btnChonComBo.Location = new System.Drawing.Point(9, 6);
            this.btnChonComBo.Name = "btnChonComBo";
            this.btnChonComBo.Size = new System.Drawing.Size(150, 58);
            this.btnChonComBo.TabIndex = 0;
            this.btnChonComBo.Text = "Combo";
            this.btnChonComBo.UseVisualStyleBackColor = true;
            this.btnChonComBo.Click += new System.EventHandler(this.btnChonComBo_Click);
            // 
            // panel_Order
            // 
            this.panel_Order.Controls.Add(this.panel_TinhTien);
            this.panel_Order.Controls.Add(this.panel_DSOrder);
            this.panel_Order.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Order.Location = new System.Drawing.Point(462, 0);
            this.panel_Order.Name = "panel_Order";
            this.panel_Order.Size = new System.Drawing.Size(468, 596);
            this.panel_Order.TabIndex = 0;
            // 
            // panel_TinhTien
            // 
            this.panel_TinhTien.Controls.Add(this.panel2);
            this.panel_TinhTien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_TinhTien.Location = new System.Drawing.Point(0, 402);
            this.panel_TinhTien.Name = "panel_TinhTien";
            this.panel_TinhTien.Size = new System.Drawing.Size(468, 194);
            this.panel_TinhTien.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtKM);
            this.panel2.Controls.Add(this.lblThanhTien);
            this.panel2.Controls.Add(this.panel_button);
            this.panel2.Controls.Add(this.lblVAT);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 192);
            this.panel2.TabIndex = 2;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblThanhTien.ForeColor = System.Drawing.Color.Red;
            this.lblThanhTien.Location = new System.Drawing.Point(147, 157);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(23, 25);
            this.lblThanhTien.TabIndex = 7;
            this.lblThanhTien.Text = "0";
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.btnHuyBo);
            this.panel_button.Controls.Add(this.btnInHD);
            this.panel_button.Controls.Add(this.btnThanhToan);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_button.Location = new System.Drawing.Point(283, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(185, 192);
            this.panel_button.TabIndex = 6;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.BackColor = System.Drawing.Color.Red;
            this.btnHuyBo.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHuyBo.ForeColor = System.Drawing.Color.White;
            this.btnHuyBo.Location = new System.Drawing.Point(9, 129);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(170, 52);
            this.btnHuyBo.TabIndex = 2;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnInHD.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInHD.ForeColor = System.Drawing.Color.White;
            this.btnInHD.Location = new System.Drawing.Point(9, 71);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(170, 52);
            this.btnInHD.TabIndex = 1;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Green;
            this.btnThanhToan.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(9, 11);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(170, 52);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVAT.ForeColor = System.Drawing.Color.Red;
            this.lblVAT.Location = new System.Drawing.Point(147, 88);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(23, 25);
            this.lblVAT.TabIndex = 4;
            this.lblVAT.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Khuyến mãi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "VAT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thành tiền:";
            // 
            // panel_DSOrder
            // 
            this.panel_DSOrder.Controls.Add(this.dgvDSOrder);
            this.panel_DSOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DSOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_DSOrder.Name = "panel_DSOrder";
            this.panel_DSOrder.Size = new System.Drawing.Size(468, 596);
            this.panel_DSOrder.TabIndex = 0;
            // 
            // dgvDSOrder
            // 
            this.dgvDSOrder.AllowUserToAddRows = false;
            this.dgvDSOrder.AllowUserToResizeRows = false;
            this.dgvDSOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSOrder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDSOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mamon,
            this.TenMon,
            this.DonGai,
            this.SoLuong,
            this.ThanhTien,
            this.Xoa});
            this.dgvDSOrder.EnableHeadersVisualStyles = false;
            this.dgvDSOrder.Location = new System.Drawing.Point(6, 6);
            this.dgvDSOrder.Name = "dgvDSOrder";
            this.dgvDSOrder.RowHeadersVisible = false;
            this.dgvDSOrder.RowHeadersWidth = 51;
            this.dgvDSOrder.RowTemplate.Height = 29;
            this.dgvDSOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSOrder.Size = new System.Drawing.Size(456, 390);
            this.dgvDSOrder.TabIndex = 4;
            this.dgvDSOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSOrder_CellContentClick);
            // 
            // Mamon
            // 
            this.Mamon.HeaderText = "Mã món";
            this.Mamon.MinimumWidth = 6;
            this.Mamon.Name = "Mamon";
            this.Mamon.ReadOnly = true;
            // 
            // TenMon
            // 
            this.TenMon.HeaderText = "Tên Món";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            // 
            // DonGai
            // 
            this.DonGai.HeaderText = "Đơn giá";
            this.DonGai.MinimumWidth = 6;
            this.DonGai.Name = "DonGai";
            this.DonGai.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // Xoa
            // 
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.MinimumWidth = 6;
            this.Xoa.Name = "Xoa";
            this.Xoa.Text = "X";
            this.Xoa.UseColumnTextForButtonValue = true;
            // 
            // txtKM
            // 
            this.txtKM.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKM.Location = new System.Drawing.Point(135, 15);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(35, 34);
            this.txtKM.TabIndex = 8;
            this.txtKM.TextChanged += new System.EventHandler(this.txtKM_TextChanged);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 680);
            this.Controls.Add(this.panel_control);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order";
            this.Text = "Order";
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_control.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel_Loc.ResumeLayout(false);
            this.panel_Order.ResumeLayout(false);
            this.panel_TinhTien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_button.ResumeLayout(false);
            this.panel_DSOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel_control;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Order;
        private System.Windows.Forms.Panel panel_DSOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_Loc;
        private System.Windows.Forms.Panel panel_TinhTien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnChonDoUong;
        private System.Windows.Forms.Button btnChonMonLe;
        private System.Windows.Forms.Button btnChonComBo;
        private System.Windows.Forms.DataGridView dgvDSOrder;
        private System.Windows.Forms.DataGridView dgv_DSSP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mamon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewButtonColumn Xoa;
        private System.Windows.Forms.TextBox txtKM;
    }
}