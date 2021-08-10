using QLKFC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKFC
{
    public partial class QuanLyTaiKhoan : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        public void HienThi()
        {
            try
            {
                var query = from tk in db.TaiKhoans
                            select new
                            {
                                tk.Id,
                                tk.TaiKhoan1,
                                tk.MatKhau,
                            };
                dgvTaiKhoan.DataSource = query.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvTaiKhoan.Columns[0].HeaderText = "ID";
            dgvTaiKhoan.Columns[1].HeaderText = "Tài khoản";
            dgvTaiKhoan.Columns[2].HeaderText = "Mật khẩu";

            dgvTaiKhoan.Columns[0].Width = 160;
            dgvTaiKhoan.Columns[1].Width = 300;
            dgvTaiKhoan.Columns[2].Width = 300;
        }

        public void XoaTrang()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cbQuyen.Text = "";
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtID.Text = dgvTaiKhoan.Rows[index].Cells[0].Value.ToString();
            txtTaiKhoan.Text = dgvTaiKhoan.Rows[index].Cells[1].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[index].Cells[2].Value.ToString();
            if (txtID.Text == "1")
                cbQuyen.Text = "Quản lý";
            else
                cbQuyen.Text = "Nhân Viên";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                    throw new Exception("Chọn tài khoản muốn cập nhật!");
                if (txtTaiKhoan.Text == "")
                    throw new Exception("Nhập tài khoản!");
                if (txtMatKhau.Text == "")
                    throw new Exception("Nhập mật khẩu!");
                if (cbQuyen.Text == "")
                    throw new Exception("Chọn quyền tài khoản!");

                TaiKhoan tk = db.TaiKhoans.Where(tk => tk.Id == int.Parse(txtID.Text)).FirstOrDefault();
                tk.TaiKhoan1 = txtTaiKhoan.Text;
                tk.MatKhau = txtMatKhau.Text;
                if (cbQuyen.Text == "Admin")
                    tk.Quyen = true;
                else
                    tk.Quyen = false;

                db.SaveChanges();
                HienThi();
                XoaTrang();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
