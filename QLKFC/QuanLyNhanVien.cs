using OfficeOpenXml;
using QLKFC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKFC
{
    public partial class QuanLyNhanVien : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        #region bắt lỗi
        private void txtCMND_Validating(object sender, CancelEventArgs e)
        {
            if (txtCMND.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCMND, "Bạn hãy nhập số CMND!");
                txtCMND.Focus();
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

        private void txtNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgaySinh.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNgaySinh, "Bạn hãy nhập ngày sinh!");
                txtNgaySinh.Focus();
            }
            else
            {
                try
                {
                    int tuoi = DateTime.Now.Year - txtNgaySinh.Value.Year;
                    if (tuoi < 18)
                        throw new Exception("Nhân viên phải từ 18 tuổi trở lên!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtNgaySinh.Focus();
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
        }

        private void txtNgayBD_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgayBD.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNgayBD, "Bạn hãy nhập ngày bắt đầu!");
                txtNgayBD.Focus();
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

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (radNam.Checked == false && radNu.Checked == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(groupBox1, "Bạn hãy chọn giới tính!");
            }
        }

        private void txtCMND_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCMND, "");
        }

        private void txtTenNV_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenNV, "");
        }

        private void groupBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(groupBox1, "");
        }

        private void txtNgaySinh_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNgaySinh, "");
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

        private void txtNgayBD_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNgayBD, "");
        }

        private void cbChucVu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbChucVu, "");
        }

        public void CheckLoi()
        {
            try
            {
                if (txtCMND.Text == "")
                    throw new Exception("Bạn chưa nhập số CMND");
                if (txtTenNV.Text == "")
                    throw new Exception("Bạn chưa nhập tên nhân viên");
                if (radNam.Checked == false && radNu.Checked == false)
                    throw new Exception("Bạn hãy chọn giới tính của nhân viên");
                if (txtDiaChi.Text == "")
                    throw new Exception("Bạn hãy nhập địa chỉ");
                if (txtSDT.Text == "")
                    throw new Exception("Bạn hãy nhập số điện thoại");
                if (cbChucVu.Text == "")
                    throw new Exception("Bạn hãy chọn chức vụ");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Hiển thị
        public void HienThi()
        {
            try
            {
                var query = from nv in db.NhanViens
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
                                nv.MaCvNavigation.TenCv
                            };
                dgvNhanVien.DataSource = query.ToList();
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dgvNhanVien.Columns[0].HeaderText = "Số CMND";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[5].HeaderText = "SĐT";
            dgvNhanVien.Columns[6].HeaderText = "Email";
            dgvNhanVien.Columns[7].HeaderText = "Ngày bắt đầu";
            dgvNhanVien.Columns[8].HeaderText = "Chức vụ";

            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 50;
            dgvNhanVien.Columns[3].Width = 100;
            dgvNhanVien.Columns[4].Width = 100;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 300;
            dgvNhanVien.Columns[7].Width = 100;
            dgvNhanVien.Columns[8].Width = 100;

        }

        public void ChonChucVu()
        {
            try
            {
                foreach (var item in db.ChucVus)
                {
                    cbChucVu.Items.Add(item.TenCv);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaTrang()
        {
            txtCMND.Clear();
            txtTenNV.Clear();
            radNam.Checked = true;
            txtNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtNgayBD.Value = DateTime.Now;
            cbChucVu.Text = "";
        }
        
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
            ChonChucVu();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtCMND.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString();
            string gt = dgvNhanVien.Rows[index].Cells[2].Value.ToString();
            if (gt == "Nam")
                radNam.Checked = true;
            if (gt == "Nữ")
                radNu.Checked = true;
            txtNgaySinh.Text = dgvNhanVien.Rows[index].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[index].Cells[5].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[index].Cells[6].Value.ToString();
            txtNgayBD.Text = dgvNhanVien.Rows[index].Cells[7].Value.ToString();
            cbChucVu.Text = dgvNhanVien.Rows[index].Cells[8].Value.ToString();
        }
        #endregion

        #region Các nút

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            HienThi();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CheckLoi();
            try
            {
                if (db.NhanViens.Find(txtCMND.Text) != null)
                    throw new Exception("Số CMND đã tồn tại");
                NhanVien nvm = new NhanVien();
                nvm.SoCmt = txtCMND.Text;
                nvm.TenNv = txtTenNV.Text;
                if (radNam.Checked)
                    nvm.GioiTinh = "Nam";
                else if (radNu.Checked)
                    nvm.GioiTinh = "Nữ";
                nvm.NgaySinh = txtNgaySinh.Value;
                nvm.DiaChi = txtDiaChi.Text;
                nvm.SoDienThoai = txtSDT.Text;
                nvm.Email = txtEmail.Text;
                nvm.NgayBatDau = txtNgayBD.Value;

                foreach (var item in db.ChucVus)
                {
                    if (item.TenCv == cbChucVu.SelectedItem.ToString())
                    {
                        nvm.MaCv = item.MaCv;
                    }
                }

                db.NhanViens.Add(nvm);
                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Thêm thành công!", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CheckLoi();
            try
            {
                NhanVien nvSua = db.NhanViens.Where(nv => nv.SoCmt == txtCMND.Text).FirstOrDefault();
                if (nvSua == null)
                    throw new Exception("Nhân viên không tồn tại");
                nvSua.TenNv = txtTenNV.Text;
                if (radNam.Checked)
                    nvSua.GioiTinh = "Nam";
                else if (radNu.Checked)
                    nvSua.GioiTinh = "Nữ";
                nvSua.NgaySinh = txtNgaySinh.Value;
                nvSua.DiaChi = txtDiaChi.Text;
                nvSua.SoDienThoai = txtSDT.Text;
                nvSua.Email = txtEmail.Text;
                nvSua.NgayBatDau = txtNgayBD.Value;

                foreach (var item in db.ChucVus)
                {
                    if (item.TenCv == cbChucVu.Text)
                    {
                        nvSua.MaCv = item.MaCv;
                    }
                }

                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Sửa thành công!", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCMND.Text == "")
                    throw new Exception("Bạn phải nhập Số CMND");
                NhanVien nvXoa = db.NhanViens.Where(nv => nv.SoCmt == txtCMND.Text).FirstOrDefault();
                if (nvXoa == null)
                    throw new Exception("Nhân viên không tồn tại");
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    db.NhanViens.Remove(nvXoa);
                    db.SaveChanges();
                    HienThi();
                    XoaTrang();
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var p = new ExcelPackage())
                {
                    var ws = p.Workbook.Worksheets.Add("Nhân Viên");

                    for (int i = 0; i < dgvNhanVien.ColumnCount; i++)
                    {
                        ws.Cells[1, i + 1].Value = dgvNhanVien.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvNhanVien.RowCount; i++)
                    {
                        for (int j = 0; j < dgvNhanVien.ColumnCount; j++)
                        {
                            ws.Cells[i + 2, j + 1].Value = dgvNhanVien.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    ws.Cells["1:1"].Style.Font.Bold = true;
                    ws.Cells.Style.Font.Name = "Arial";

                    p.SaveAs(new FileInfo(@"\Nhân viên.xlsx"));
                }
                MessageBox.Show("Thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text == "")
                    throw new Exception("Bạn hãy nhập Số CMND của nhân viên cần tìm");
                var query1 = from nv in db.NhanViens
                             where nv.SoCmt == txtTim.Text
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
                                 nv.MaCvNavigation.TenCv
                             };
                dgvNhanVien.DataSource = query1.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
