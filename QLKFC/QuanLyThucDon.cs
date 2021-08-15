using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLKFC.Models;

namespace QLKFC
{
    public partial class QuanLyThucDon : Form
    {
        public QuanLyThucDon()
        {
            InitializeComponent();
            loadCmb();
            loadDGV();
        }

        QLBHKFCContext db = new QLBHKFCContext();
        string filename, iname;

        #region Hàm khai báo
        private void clearTextBox()
        {
            txtFind.Clear();
            txtGiaBan.Clear();
            txtMaMon.Clear();
            txtMoTa.Clear();
            txtTenMon.Clear();
            txtLoai.Clear();
            cmbLoai.SelectedItem = null;
            pcbMoTa.Image = null;
        }

        private void loadCmb()
        {
            try
            {
                var query = from lsp in db.LoaiSanPhams
                            select new
                            {
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    cmbLoai.Items.Add(item.TenLsp);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }
            
        }

        private void loadDGV()
        {
            dgv_DSSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            lsp.TenLsp,
                            sp.Loai,
                            sp.HinhAnh
                        };
            foreach (var item in query)
            {
                if (item.HinhAnh != null)
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia, new Bitmap(pathImage() + item.HinhAnh));
                else
                    dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia);
            }
        }

        private bool checkBoTrong()
        {
            if (txtGiaBan.Text == "" || txtLoai.Text == "" || txtTenMon.Text == "" || cmbLoai.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }
        #endregion

        #region Tương tác người dùng
        private void btnChonAnh_Click(object sender, EventArgs e)
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
                    pcbMoTa.Image = Image.FromFile(browse.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != - 1)
            {
                var sp = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(dgv_DSSP.Rows[e.RowIndex].Cells[0].Value.ToString()));
                txtMaMon.Text = sp.MaSp + "";
                txtGiaBan.Text = sp.DonGia + "";
                txtLoai.Text = sp.Loai;
                txtMoTa.Text = sp.Mota;
                txtTenMon.Text = sp.TenSp;
                cmbLoai.Text = db.LoaiSanPhams.SingleOrDefault(s => s.MaLsp.Equals(sp.MaLsp)).TenLsp;
                try
                {
                    pcbMoTa.Image = new Bitmap(pathImage() + sp.HinhAnh);
                }
                catch (Exception)
                {
                    pcbMoTa.Image = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var spt = db.SanPhams.SingleOrDefault(lsp => lsp.TenSp == txtTenMon.Text);
            if (spt == null || (spt != null && spt.Loai != txtLoai.Text))
            {
                if (checkBoTrong())
                {
                    SanPham sp = new SanPham();
                    sp.TenSp = txtTenMon.Text;
                    sp.MaLsp = db.LoaiSanPhams.SingleOrDefault(s => s.TenLsp.Equals(cmbLoai.SelectedItem.ToString())).MaLsp;
                    try
                    {
                        if (int.Parse(txtGiaBan.Text)<1)
                        {
                            errorProvider1.SetError(txtGiaBan, "Giá bán bải là số dương!");
                            txtGiaBan.Focus();
                            txtGiaBan.SelectAll();
                        }
                        else
                        {
                            sp.DonGia = int.Parse(txtGiaBan.Text);
                            sp.Loai = txtLoai.Text;
                            sp.Mota = txtMoTa.Text;
                            if (iname != null)
                            {
                                sp.HinhAnh = iname;
                                if (!File.Exists(pathImage() + iname))
                                {
                                    File.Copy(filename, pathImage() + iname);
                                }
                            }
                            try
                            {
                                db.SanPhams.Add(sp);
                                db.SaveChanges();
                                iname = null;
                                MessageBox.Show("Đã thêm sản phẩm");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Thông báo");
                            }
                            loadDGV();
                            clearTextBox();
                        }
                    }
                    catch
                    {
                        errorProvider1.SetError(txtGiaBan, "Phải nhập giá tiền là số!");
                    }
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống dữ liêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Đã tồn tại loại sản phẩm này!", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkBoTrong())
            {
                var spSua = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(txtMaMon.Text));
                spSua.TenSp = txtTenMon.Text;
                spSua.MaLsp = db.LoaiSanPhams.SingleOrDefault(s => s.TenLsp.Equals(cmbLoai.SelectedItem.ToString())).MaLsp;
                try
                {
                    if (int.Parse(txtGiaBan.Text) < 1)
                    {
                        errorProvider1.SetError(txtGiaBan, "Giá bán bải là số dương!");
                        txtGiaBan.Focus();
                        txtGiaBan.SelectAll();
                    }
                    else
                    {
                        spSua.DonGia = int.Parse(txtGiaBan.Text);
                        spSua.Loai = txtLoai.Text;
                        spSua.Mota = txtMoTa.Text;
                        if (iname != null)
                        {
                            spSua.HinhAnh = iname;
                            if (!File.Exists(pathImage() + iname))
                            {
                                File.Copy(filename, pathImage() + iname);
                            }
                        }
                        try
                        {
                            db.SaveChanges();
                            loadDGV();
                            clearTextBox();
                            iname = null;
                            MessageBox.Show("Đã được sửa");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Thông báo");
                        }
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtGiaBan, "Phải nhập giá tiền là số!");
                }
            }
            else
            {
                MessageBox.Show("Đã tồn tại loại sản phẩm này!", "Thông báo");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void dgv_DSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_DSSP.Columns[e.ColumnIndex].Name == "Xoa")
            {
                var spXoa = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(txtMaMon.Text));
                clearTextBox();
                DialogResult dialog = MessageBox.Show("Bạn muốn đóng xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        db.Remove(spXoa);
                        db.SaveChanges();
                        MessageBox.Show("Đã được xóa!");
                        loadDGV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Thông báo");
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDGV();
            txtFind.Clear();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            dgv_DSSP.Rows.Clear();
            try
            {
                var query = from sp in db.SanPhams
                            join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                            where sp.MaSp == int.Parse(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                lsp.TenLsp,
                                sp.Loai,
                                sp.HinhAnh
                            };
                foreach (var item in query)
                {
                    if (item.HinhAnh != null)
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia, new Bitmap(pathImage() + item.HinhAnh));
                    else
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia);
                }
            }
            catch
            {
                var query = from sp in db.SanPhams
                            join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                            where sp.TenSp.Contains(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                lsp.TenLsp,
                                sp.Loai,
                                sp.HinhAnh
                            };
                foreach (var item in query)
                {
                    if (item.HinhAnh != null)
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia, new Bitmap(pathImage() + item.HinhAnh));
                    else
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia);
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgv_DSSP.Rows.Clear();
            try
            {
                var query = from sp in db.SanPhams
                            join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                            where sp.MaSp == int.Parse(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                lsp.TenLsp,
                                sp.Loai,
                                sp.HinhAnh
                            };
                foreach (var item in query)
                {
                    if (item.HinhAnh != null)
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia, new Bitmap(pathImage() + item.HinhAnh));
                    else
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia);
                }
            }
            catch
            {
                var query = from sp in db.SanPhams
                            join lsp in db.LoaiSanPhams on sp.MaLsp equals lsp.MaLsp
                            where sp.TenSp.Contains(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                lsp.TenLsp,
                                sp.Loai,
                                sp.HinhAnh
                            };
                foreach (var item in query)
                {
                    if (item.HinhAnh != null)
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia, new Bitmap(pathImage() + item.HinhAnh));
                    else
                        dgv_DSSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.Loai, item.DonGia);
                }
            }
        }
        #endregion
    }
}