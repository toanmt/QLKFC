using QLKFC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKFC
{
    public partial class QuanLyNhanVien_Sua : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhanVien_Sua()
        {
            InitializeComponent();
        }
        public string soCMND;
        public QuanLyNhanVien_Sua(String cmnd)
        {
            InitializeComponent();
            soCMND = cmnd;
        }
        #region KT lỗi nhập dữ liệu
        private void txtSoCMND_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoCMND.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSoCMND, "Bạn hãy nhập số CMND!");
                txtSoCMND.Focus();
            }
        }

        private bool KTEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtTenNV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenNV, "Bạn hãy nhập tên nhân viên!");
                txtTenNV.Focus();
            }
        }

        private void dtpNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if (dtpNgaySinh.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpNgaySinh, "Bạn hãy nhập ngày sinh!");
                dtpNgaySinh.Focus();
            }
            else
            {
                try
                {
                    int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;
                    if (tuoi < 18)
                        throw new Exception("Nhân viên phải từ 18 tuổi trở lên!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDiaChi, "Bạn hãy nhập địa chỉ!");
                txtDiaChi.Focus();
            }
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSDT, "Bạn hãy nhập số điện thoại!");
                txtSDT.Focus();
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Bạn hãy nhập Email!");
                txtEmail.Focus();
            }
            else
            {
                if (KTEmail(txtEmail.Text) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Email bạn nhập không chính xác");
                    txtEmail.Focus();
                }
            }
        }

        private void dtpNgayBD_Validating(object sender, CancelEventArgs e)
        {
            if (dtpNgayBD.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpNgayBD, "Bạn hãy nhập ngày bắt đầu!");
                dtpNgayBD.Focus();
            }
        }

        private void cbChucVu_Validating(object sender, CancelEventArgs e)
        {
            if (cbChucVu.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(cbChucVu, "Bạn hãy chọn chức vụ!");
                cbChucVu.Focus();
            }
        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTaiKhoan, "Bạn hãy nhập tài khoản");
                txtTaiKhoan.Focus();
            }
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMatKhau, "Bạn hãy nhập tài khoản");
                txtMatKhau.Focus();
            }
        }

        private bool KT()
        {
            if (txtSoCMND.Text == "")
                return false;
            else if (txtTenNV.Text == "")
                return false;
            else if (radNam.Checked == false && radNu.Checked == false)
                return false;
            else if (txtDiaChi.Text == "")
                return false;
            else if (txtSDT.Text == "")
                return false;
            else if (txtEmail.Text == "")
                return false;
            else if (cbChucVu.Text == "")
                return false;
            else if (txtTaiKhoan.Text == "")
                return false;
            else if (txtMatKhau.Text == "")
                return false;

            return true;

        }

        #endregion
        #region chọn ảnh
        string filename, iname;
        private void btnAnh_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog browse = new OpenFileDialog()
                {
                    Title = "Chọn ảnh",
                    Filter = "All files|*.*|Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|Png files(*.png)|*.png|Jpeg files(*.jpeg)|*.jpeg|Jpe files(*.jpe)|*.jpe|Jpg files(*.jpg)|*.jpg"
                };
                if (browse.ShowDialog() == DialogResult.OK)
                {
                    iname = Path.GetFileName(browse.FileName);
                    filename = browse.FileName;
                    ptbNV.Image = Image.FromFile(browse.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi lấy hình ảnh", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string pathImage()
        {
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }
        #endregion
        #region nút
        public void ChonChucVu()
        {
            try
            {
                foreach (var item in db.ChucVus)
                {
                    cbChucVu.Items.Add(item.TenCv);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KT() == false)
                    throw new Exception("Hãy nhập đầy đủ thông tin");
                NhanVien nvs = db.NhanViens.Where(nv => nv.SoCmt == soCMND).FirstOrDefault();
                nvs.SoCmt = txtSoCMND.Text;
                nvs.TenNv = txtTenNV.Text;
                if (radNam.Checked)
                    nvs.GioiTinh = "Nam";
                else if (radNu.Checked)
                    nvs.GioiTinh = "Nữ";
                nvs.NgaySinh = dtpNgaySinh.Value;
                nvs.DiaChi = txtDiaChi.Text;
                nvs.SoDienThoai = txtSDT.Text;
                nvs.Email = txtEmail.Text;
                nvs.NgayBatDau = dtpNgayBD.Value;
                foreach (var item in db.ChucVus)
                {
                    if (item.TenCv == cbChucVu.Text)
                    {
                        nvs.MaCv = item.MaCv;
                    }
                }

                if (iname != null)
                {
                    nvs.HinhAnh = iname;
                    if (!File.Exists(pathImage() + iname))
                    {
                        File.Copy(filename, pathImage() + iname);
                    }
                }

                TaiKhoan tkS = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text).FirstOrDefault();
                tkS.TaiKhoan1 = txtTaiKhoan.Text;
                tkS.MatKhau = txtMatKhau.Text;
                if (cbChucVu.Text == "Quản lý")
                    tkS.Quyen = 1;
                else if (cbChucVu.Text == "Đầu bếp")
                    tkS.Quyen = 3;
                else
                    tkS.Quyen = 2;

                db.SaveChanges();

                iname = null;
                MessageBox.Show("Sửa thành công");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void QuanLyNhanVien_Sua_Load(object sender, EventArgs e)
        {
            ChonChucVu();
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
        #endregion
    }
}
