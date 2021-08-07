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
    public partial class QuanLyLoaiSanPham : Form
    {
        public QuanLyLoaiSanPham()
        {
            InitializeComponent();
            loadData();
        }

        QLBHKFCContext db = new QLBHKFCContext();

        #region Kiểm tra dữ liệu người nhập
        private void txtTenLoaiMon_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenLoaiMon.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenLoaiMon, "Bạn phải nhập tên loại sản phẩm!");
                txtTenLoaiMon.Focus();
            }
        }
        #endregion

        #region Lệnh điều khiển
        private void clearTextBox()
        {
            txtMaMon.Clear();
            txtTenLoaiMon.Clear();
            txtTenLoaiMon.Focus();
        }
        private void loadData()
        {
            try
            {
                var query = from lsp in db.LoaiSanPhams
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                dgv_DSLoaiSPham.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }
            dgv_DSLoaiSPham.Columns[0].HeaderText = "Mã loại sản phẩm";
            dgv_DSLoaiSPham.Columns[1].HeaderText = "Tên loại sản phẩm";
           
        }
        #endregion

        #region Tương tác
        private void btnThem_Click(object sender, EventArgs e)
        {
            if ((db.LoaiSanPhams.SingleOrDefault(lsp => lsp.TenLsp == txtTenLoaiMon.Text))==null)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.TenLsp = txtTenLoaiMon.Text;
                try {
                db.LoaiSanPhams.Add(lsp);
                db.SaveChanges();
                loadData();
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
            var spSua = db.LoaiSanPhams.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
            if (spSua != null)
            {
                spSua.TenLsp = txtTenLoaiMon.Text;
                db.SaveChanges();
                loadData();
                clearTextBox();
            }
            else
            {
                MessageBox.Show("Không tồn tại loại sản phẩm này!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var lspXoa = db.LoaiSanPhams.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
            if (lspXoa != null)
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn đóng xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    db.Remove(lspXoa);
                    db.SaveChanges();
                    loadData();
                    clearTextBox();
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại loại sản phẩm này!", "Thông báo");
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
        #endregion
    }
}
