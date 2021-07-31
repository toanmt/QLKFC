
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_control = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_DSSP = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.panel_Loc = new System.Windows.Forms.Panel();
            this.btnChonDoUong = new System.Windows.Forms.Button();
            this.btnChonMonLe = new System.Windows.Forms.Button();
            this.btnChonComBo = new System.Windows.Forms.Button();
            this.panel_Order = new System.Windows.Forms.Panel();
            this.panel_TinhTien = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_button = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_DSOrder = new System.Windows.Forms.Panel();
            this.dgvDSOrder = new System.Windows.Forms.DataGridView();
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
            this.dgv_DSSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DSSP.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSSP.Location = new System.Drawing.Point(12, 124);
            this.dgv_DSSP.Name = "dgv_DSSP";
            this.dgv_DSSP.RowHeadersWidth = 51;
            this.dgv_DSSP.RowTemplate.Height = 29;
            this.dgv_DSSP.Size = new System.Drawing.Size(444, 460);
            this.dgv_DSSP.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Controls.Add(this.txtFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 48);
            this.panel4.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::QLKFC.Properties.Resources.search;
            this.btnFind.Location = new System.Drawing.Point(400, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 37);
            this.btnFind.TabIndex = 1;
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFind.Location = new System.Drawing.Point(9, 6);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(385, 37);
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
            this.btnChonMonLe.Text = "Món lẻ";
            this.btnChonMonLe.UseVisualStyleBackColor = true;
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
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel_button);
            this.panel2.Controls.Add(this.domainUpDown1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 192);
            this.panel2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(147, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "0";
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.button2);
            this.panel_button.Controls.Add(this.button1);
            this.panel_button.Controls.Add(this.btnThanhToan);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_button.Location = new System.Drawing.Point(283, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(185, 192);
            this.panel_button.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(9, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hủy bỏ";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "In hóa đơn";
            this.button1.UseVisualStyleBackColor = false;
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
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.domainUpDown1.Location = new System.Drawing.Point(147, 19);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(46, 31);
            this.domainUpDown1.TabIndex = 5;
            this.domainUpDown1.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(147, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "0";
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
            this.dgvDSOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSOrder.Location = new System.Drawing.Point(6, 6);
            this.dgvDSOrder.Name = "dgvDSOrder";
            this.dgvDSOrder.RowHeadersWidth = 51;
            this.dgvDSOrder.RowTemplate.Height = 29;
            this.dgvDSOrder.Size = new System.Drawing.Size(450, 390);
            this.dgvDSOrder.TabIndex = 4;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_DSSP;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnChonDoUong;
        private System.Windows.Forms.Button btnChonMonLe;
        private System.Windows.Forms.Button btnChonComBo;
        private System.Windows.Forms.DataGridView dgvDSOrder;
    }
}