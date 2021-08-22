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
    public partial class QuanLyNhanVien_Them : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhanVien_Them()
        {
            InitializeComponent();
        }
        #region check lỗi nhập dữ liệu
        
        private void txtSoCMND_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoCMND.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSoCMND, "Bạn hãy nhập số CMND!");
                txtSoCMND.Focus();
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

        private void txtSoCMND_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoCMND, "");
        }

        private void txtTenNV_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenNV, "");
        }

        private void dtpNgaySinh_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpNgaySinh, "");
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaChi, "");
        }

        private void txtSDT_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSDT, "");
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtEmail, "");
        }

        private void dtpNgayBD_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpNgayBD, "");
        }

        private void cbChucVu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbChucVu, "");
        }

        private void txtTaiKhoan_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTaiKhoan, "");
        }

        private void txtMatKhau_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMatKhau, "");
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
        private void btnAnh_Click(object sender, EventArgs e)
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
        private void ChonChucVu()
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

        private void Thêm_NV_Load(object sender, EventArgs e)
        {
            ChonChucVu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KT();
            try
            {
                if (KT() == false)
                    throw new Exception("Hãy nhập đầy đủ thông tin");
                if (db.NhanViens.Find(txtSoCMND.Text) != null)
                    throw new Exception("Số CMND đã tồn tại");
                NhanVien nvm = new NhanVien();
                nvm.SoCmt = txtSoCMND.Text;
                nvm.TenNv = txtTenNV.Text;
                if (radNam.Checked)
                    nvm.GioiTinh = "Nam";
                else if (radNu.Checked)
                    nvm.GioiTinh = "Nữ";
                nvm.NgaySinh = dtpNgaySinh.Value;
                nvm.DiaChi = txtDiaChi.Text;
                nvm.SoDienThoai = txtSDT.Text;
                nvm.Email = txtEmail.Text;
                nvm.NgayBatDau = dtpNgayBD.Value;
                foreach (var item in db.ChucVus)
                {
                    if (item.TenCv == cbChucVu.Text)
                    {
                        nvm.MaCv = item.MaCv;
                    }
                }
                
                if (iname != null)
                {
                    nvm.HinhAnh = iname;
                    if (!File.Exists(pathImage() + iname))
                    {
                        File.Copy(filename, pathImage() + iname);
                    }
                }

                if (db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text).FirstOrDefault() != null)
                    throw new Exception("Tài khoản đã tồn tại");
                TaiKhoan tkm = new TaiKhoan();
                tkm.TaiKhoan1 = txtTaiKhoan.Text;
                tkm.MatKhau = txtMatKhau.Text;
                if (cbChucVu.Text == "Quản lý")
                    tkm.Quyen = 1;
                else if (cbChucVu.Text == "Đầu Bếp")
                    tkm.Quyen = 3;
                else
                    tkm.Quyen = 2;
                db.TaiKhoans.Add(tkm);
                db.SaveChanges();


                foreach (var item in db.TaiKhoans)
                {
                    if (item.TaiKhoan1 == txtTaiKhoan.Text)
                        nvm.Id = item.Id;
                }
                db.NhanViens.Add(nvm);

                db.SaveChanges();

                iname = null;
                MessageBox.Show("Thêm thành công");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
