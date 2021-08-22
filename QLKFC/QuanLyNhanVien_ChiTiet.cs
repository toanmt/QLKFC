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
    public partial class QuanLyNhanVien_ChiTiet : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhanVien_ChiTiet()
        {
            InitializeComponent();
        }
        public string soCMND;
        public QuanLyNhanVien_ChiTiet(String cmnd)
        {
            InitializeComponent();
            soCMND = cmnd;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string pathImage()
        {
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }
        private void QuanLyNhanVien_ChiTiet_Load(object sender, EventArgs e)
        {

            var query = from nv in db.NhanViens
                        where nv.SoCmt == soCMND
                        select new
                        {
                            nv.SoCmt,
                            nv.TenNv,
                            nv.GioiTinh,
                            nv.NgaySinh,
                            nv.DiaChi,
                            nv.SoDienThoai,
                            nv.Email,
                            nv.NgayBatDau,
                            nv.HinhAnh,
                            nv.MaCvNavigation.TenCv,
                            nv.IdNavigation.TaiKhoan1,
                            nv.IdNavigation.MatKhau
                        };

            foreach (var item in query)
            {
                txtSoCMND.Text = item.SoCmt;
                txtTenNV.Text = item.TenNv;
                if (item.GioiTinh == "Nam")
                    radNam.Checked = true;
                else if (item.GioiTinh == "Nữ")
                    radNu.Checked = true;
                dtpNgaySinh.Value = item.NgaySinh.Value;
                txtDiaChi.Text = item.DiaChi;
                txtSDT.Text = item.SoDienThoai;
                txtEmail.Text = item.Email;
                dtpNgayBD.Value = item.NgayBatDau.Value;
                cbChucVu.Text = item.TenCv;
                txtTaiKhoan.Text = item.TaiKhoan1;
                txtMatKhau.Text = item.MatKhau;
                try
                {
                    ptbNV.Image = new Bitmap(pathImage() + item.HinhAnh);
                }
                catch (Exception)
                {
                    ptbNV.Image = null;
                }

            }
        }
    }
}
