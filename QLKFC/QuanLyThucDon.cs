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
        string filename;

        #region điều khiển
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
            try
            {
                var query = from sp in db.SanPhams
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                sp.Loai,
                                sp.HinhAnh
                            };
                dgv_DSSP.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }
}

        #endregion

        #region Tương tác
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog() { Filter = "All files|*.*|Png files(*.png)|*.png|Jpeg files(*.jpeg)|*.jpeg" };
            if (browse.ShowDialog() == DialogResult.OK)
            {
                filename = browse.FileName;
                pcbMoTa.Image = Image.FromFile(filename);
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
                    MemoryStream mstr = new MemoryStream(sp.HinhAnh.ToArray());
                    Image img = Image.FromStream(mstr);
                    if (img == null)
                    {
                        return;
                    }
                    pcbMoTa.Image = img;
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
            if (spt == null || (spt != null && spt.Loai!=txtLoai.Text))
            {
                SanPham sp = new SanPham();
                sp.TenSp = txtTenMon.Text;
                sp.MaLsp = db.LoaiSanPhams.SingleOrDefault(s => s.TenLsp.Equals(cmbLoai.SelectedItem.ToString())).MaLsp;
                sp.DonGia = int.Parse(txtGiaBan.Text);
                sp.Loai = txtLoai.Text;
                sp.Mota = txtMoTa.Text;
                MemoryStream str = new MemoryStream();
                pcbMoTa.Image.Save(str, System.Drawing.Imaging.ImageFormat.Png);
                sp.HinhAnh = str.ToArray();
                try
                {
                    db.SanPhams.Add(sp);
                    db.SaveChanges();
                    loadDGV();
                    clearTextBox();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Đã tồn tại loại sản phẩm này!", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var spSua = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(txtMaMon.Text));
            spSua.TenSp = txtTenMon.Text;
            spSua.MaLsp = db.LoaiSanPhams.SingleOrDefault(s => s.TenLsp.Equals(cmbLoai.SelectedItem.ToString())).MaLsp;
            spSua.DonGia = int.Parse(txtGiaBan.Text);
            spSua.Loai = txtLoai.Text;
            spSua.Mota = txtMoTa.Text;
            MemoryStream str = new MemoryStream();
            pcbMoTa.Image.Save(str, System.Drawing.Imaging.ImageFormat.Png);
            spSua.HinhAnh = str.ToArray();
            try
            {
                db.SanPhams.Add(spSua);
                db.SaveChanges();
                loadDGV();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }
            clearTextBox();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var spXoa = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(txtMaMon.Text));
            DialogResult dialog = MessageBox.Show("Bạn muốn đóng xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    db.Remove(spXoa);
                    db.SaveChanges();
                    loadDGV();
                    clearTextBox();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), "Thông báo");
                }

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(txtFind.Text, out n))
            {
                var query = from sp in db.SanPhams
                            where sp.MaSp == int.Parse(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                sp.Loai,
                                sp.HinhAnh
                            };
                dgv_DSSP.DataSource = query.ToList();
            }
            else
            {
                var query = from sp in db.SanPhams
                            where sp.TenSp.Contains(txtFind.Text)
                            select new
                            {
                                sp.MaSp,
                                sp.TenSp,
                                sp.DonGia,
                                sp.Loai,
                                sp.HinhAnh
                            };
                dgv_DSSP.DataSource = query.ToList();
            }
        }

        #endregion
    }
}