using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKFC.Models;

namespace QLKFC
{
    public partial class QuanLyLoaiMonAn : Form
    {
        public QuanLyLoaiMonAn()
        {
            InitializeComponent();
            loadData();
            txtTenLoaiMon.Focus();
        }

        QLBHKFCContext db = new QLBHKFCContext();

        #region Lệnh điều khiển
        private bool kiemTraDuLieuNhap()
        {
            if (txtTenLoaiMon.Text == "")
            {
                errorProvider1.SetError(txtTenLoaiMon, "Bạn phải nhập tên loại sản phẩm!");
                return false;
            }
            return true;
        }
        private void clearTextBox()
        {
            txtMaMon.Clear();
            txtTenLoaiMon.Clear();
        }
        private void loadData()
        {
            try
            {
                dgv_DSLoaiSPham.Rows.Clear();
                var query = from lsp in db.LoaiSanPhams
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp, item.TenLsp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }
           
        }
        #endregion

        #region Tương tác
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                if ((db.LoaiSanPhams.SingleOrDefault(lsp => lsp.TenLsp == txtTenLoaiMon.Text)) == null)
                {
                    LoaiSanPham lsp = new LoaiSanPham();
                    lsp.TenLsp = txtTenLoaiMon.Text;
                    try
                    {
                        db.LoaiSanPhams.Add(lsp);
                        db.SaveChanges();
                        MessageBox.Show("Đã được thêm!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Thông báo");
                    }
                    loadData();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại loại sản phẩm này!", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (kiemTraDuLieuNhap())
            {
                var spSua = db.LoaiSanPhams.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
                if (spSua != null)
                {
                    try
                    {
                        spSua.TenLsp = txtTenLoaiMon.Text;
                        db.SaveChanges();
                        MessageBox.Show("Đã được sửa!");
                        loadData();
                        clearTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Không tồn tại loại sản phẩm này!", "Thông báo");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void dgv_DSLoaiSPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txtMaMon.Text = dgv_DSLoaiSPham.Rows[index].Cells[0].Value.ToString();
                txtTenLoaiMon.Text = dgv_DSLoaiSPham.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void dgv_DSLoaiSPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_DSLoaiSPham.Columns[e.ColumnIndex].Name == "Xoa")
            {
                var lspXoa = db.LoaiSanPhams.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
                if (lspXoa != null)
                {
                    DialogResult dialog = MessageBox.Show("Bạn muốn đóng xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            db.Remove(lspXoa);
                            db.SaveChanges();
                            MessageBox.Show("Đã được xóa!");
                            loadData();
                            clearTextBox();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại loại sản phẩm này!", "Thông báo");
                }
            }
        }

        private void txtTenLoaiMon_TextChanged(object sender, EventArgs e)
        {
            if(txtTenLoaiMon.Text!=null)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(txtTenLoaiMon, "Bạn phải nhập tên loại sản phẩm!");
            }
        }
        #endregion

    }
}
