﻿using QLKFC.Models;
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
    public partial class DangNhap : Form
    {

        QLBHKFCContext db = new QLBHKFCContext();
        public DangNhap()
        {
            InitializeComponent();
        }

        public bool Quyen { get; set; }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text && tk.MatKhau == txtMatKhau.Text).FirstOrDefault();
            if(tk != null)
            {
                if(tk.Quyen == true)
                {
                    Quyen = true;
                    this.Hide();
                    Dashboard frm = new Dashboard(Quyen);
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    Quyen = false;
                    this.Hide();
                    Dashboard frm = new Dashboard(Quyen);
                    frm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Hãy kiểm tra lại thông tin tài khoản mật khẩu!");
                txtTaiKhoan.Focus();
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if(txtTaiKhoan.Text =="")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTaiKhoan,"Bạn hãy nhập tài khoản");
                txtTaiKhoan.Focus();
            }    
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMatKhau, "Bạn hãy nhập mật khẩu");
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMatKhau, "");
        }

        private void txtTaiKhoan_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTaiKhoan, "");
        }
    }
}
