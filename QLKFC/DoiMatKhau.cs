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
    public partial class DoiMatKhau : Form
    {

        QLBHKFCContext db = new QLBHKFCContext();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        #region kt lỗi nhập dữ liệu

        #region lỗi để trắng
        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if(txtTaiKhoan.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTaiKhoan, "Hãy nhập tài khoản");
                txtTaiKhoan.Focus();
            }
        }

        private void txtTaiKhoan_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTaiKhoan, "");
        }


        private void txtMKCu_Validating(object sender, CancelEventArgs e)
        {
            if (txtMKCu.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMKCu, "Hãy nhập mật khẩu");
                txtMKCu.Focus();
            }
        }

        private void txtMKCu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMKCu, "");
        }

        private void txtMKMoi_Validating(object sender, CancelEventArgs e)
        {
            if (txtMKMoi.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMKMoi, "Hãy nhập mật khẩu mới");
                txtMKMoi.Focus();
            }
        }

        private void txtMKMoi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMKMoi, "");
        }

        private void txtNhapLaiMK_Validating(object sender, CancelEventArgs e)
        {
            if (txtNhapLaiMK.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNhapLaiMK, "Hãy nhập mật khẩu");
                txtNhapLaiMK.Focus();
            }
        }

        private void txtNhapLaiMK_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNhapLaiMK, "");
        }
        #endregion

        #region lỗi nhập
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            var query = from tk in db.TaiKhoans
                        select new
                        {
                            tk.TaiKhoan1,
                            tk.MatKhau
                        };
            foreach (var item in query)
            {
                if (txtTaiKhoan.Text != item.TaiKhoan1)
                {
                    errorProvider1.SetError(txtTaiKhoan, "Hãy nhập đúng tên tài khoản");
                    txtTaiKhoan.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void txtMKCu_TextChanged(object sender, EventArgs e)
        {
            TaiKhoan tk = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text).FirstOrDefault();
            if (txtMKCu.Text != tk.MatKhau)
            {
                errorProvider1.SetError(txtMKCu, "Hãy nhập đúng mật khẩu");
                txtMKCu.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMKMoi_TextChanged(object sender, EventArgs e)
        {
            if (txtMKCu.Text == txtMKMoi.Text)
            {
                errorProvider1.SetError(txtMKMoi, "Hãy nhập 1 mật khẩu khác");
                txtMKMoi.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtNhapLaiMK_TextChanged(object sender, EventArgs e)
        {
            if (txtNhapLaiMK.Text != txtMKMoi.Text)
            {
                errorProvider1.SetError(txtNhapLaiMK, "Mật khẩu chưa trùng khớp");
                txtNhapLaiMK.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        #endregion

        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            TaiKhoan tkSua = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text).FirstOrDefault();
            tkSua.MatKhau = txtMKMoi.Text;
            db.SaveChanges();
            MessageBox.Show("Đã đổi mật khẩu");
            this.Close();
        }

       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
