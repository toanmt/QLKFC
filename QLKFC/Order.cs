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
    public partial class Order : Form
    {
        string pos, storeid, tennv;
        public Order(string storeid, string pos, string tennv)
        {
            InitializeComponent();
            this.pos = pos;
            this.storeid = storeid;
            this.tennv = tennv;
            loadDGVSP();
        }
        QLBHKFCContext db = new QLBHKFCContext();

        #region Tương tác dữ liệu
        private void loadDGVSP()
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
            dgv_DSSP.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_DSSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_DSSP.Columns[2].HeaderText = "Đơn giá";
            dgv_DSSP.Columns[3].HeaderText = "Loại";
            dgv_DSSP.Columns[4].HeaderText = "Hình ảnh";
        }

        private void locDL(string loc)
        {
            var query = from sp in db.SanPhams
                        where sp.MaLsp.Equals(db.LoaiSanPhams.SingleOrDefault(lsp => lsp.TenLsp ==loc).MaLsp)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            dgv_DSSP.DataSource = query.ToList();
            dgv_DSSP.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_DSSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_DSSP.Columns[2].HeaderText = "Đơn giá";
            dgv_DSSP.Columns[3].HeaderText = "Loại";
            dgv_DSSP.Columns[4].HeaderText = "Hình ảnh";
        }
        private void TinhTien()
        {
            float tt = 0;
            for (int i = 0; i < dgvDSOrder.RowCount; i++)
            {
                tt += float.Parse(dgvDSOrder.Rows[i].Cells[4].Value.ToString());
            }

            if(txtKM.Text=="")
            {
                txtKM.Text = 0 + "";
            }    
            lblThanhTien.Text = tt * (100 - float.Parse(txtKM.Text)) / 100 + "";
        }
        private void Don()
        {
            dgvDSOrder.Rows.Clear();
            lblThanhTien.Text = 0 + "";
            lblVAT.Text = 0 + "";
            txtKM.Text = 0 + "";
        }
        #endregion

        #region Tương tác
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp = dgv_DSSP.Rows[e.RowIndex].Cells[0].Value.ToString();
            string tensp = dgv_DSSP.Rows[e.RowIndex].Cells[1].Value.ToString();
            string dongia = dgv_DSSP.Rows[e.RowIndex].Cells[2].Value.ToString();
            using (XacNhanSL xn = new XacNhanSL())
            {
                if (xn.ShowDialog() == DialogResult.OK)
                {
                    int check = 0;
                    if (dgvDSOrder.RowCount > 0)
                    {
                        for (int i = 0; i < dgvDSOrder.RowCount; i++)
                        {
                            var rowss = dgvDSOrder.Rows[i];
                            if (rowss.Cells[1].Value.ToString() == tensp
                                && rowss.Cells[2].Value.ToString() == dongia)
                            {
                                int sl = xn.soluong + int.Parse(rowss.Cells[3].Value.ToString());
                                if (sl < 1)
                                {
                                    dgvDSOrder.Rows.RemoveAt(i);
                                }
                                else
                                {
                                    rowss.Cells[3].Value = sl;
                                    rowss.Cells[4].Value = sl * float.Parse(dongia);
                                }
                                check++;
                            }
                        }
                    }
                    if (check == 0)
                    {
                        dgvDSOrder.Rows.Add(masp, tensp, dongia, xn.soluong, float.Parse(dongia) * xn.soluong);
                    }
                }
            }
            TinhTien();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            dgvDSOrder.ClearSelection();
        }

        private void dgvDSOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSOrder.Columns[e.ColumnIndex].Name=="Xoa")
            {
                if(MessageBox.Show("Xóa sản phẩm này?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                    ==DialogResult.Yes)
                {
                    dgvDSOrder.Rows.RemoveAt(e.RowIndex);
                    TinhTien();
                }    
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadDGVSP();
        }

        #region Lọc
        private void btnChonComBo_Click(object sender, EventArgs e)
        {
            locDL("Combo");
        }

        private void btnChonMonLe_Click(object sender, EventArgs e)
        {
            locDL("Đồ ăn");
        }

        private void btnChonDoUong_Click(object sender, EventArgs e)
        {
            locDL("Đồ uống");
        }
        #endregion
        private void txtKM_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var query = from sp in db.SanPhams
                        where sp.TenSp.Contains(txtFind.Text)
                        select new
                        {
                            sp.TenSp,
                            sp.DonGia,
                            sp.Loai,
                            sp.HinhAnh
                        };
            dgv_DSSP.DataSource = query.ToList();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.TenNv = tennv;
            hd.StoreId = storeid;
            hd.Pos = pos;
            DateTime tg = DateTime.Now;
            hd.NgayThang = tg;
            db.HoaDons.Add(hd);
            db.SaveChanges();
            CthoaDon cthd = new CthoaDon();
            cthd.MaHd = db.HoaDons.SingleOrDefault(hdm => hdm.NgayThang == tg).MaHd;
            for (int i = 0; i < dgvDSOrder.RowCount; i++)
            {
                cthd.MaSp = int.Parse(dgvDSOrder.Rows[i].Cells[0].Value.ToString());
                cthd.SoLuong = int.Parse(dgvDSOrder.Rows[i].Cells[3].Value.ToString());
                db.CthoaDons.Add(cthd);
                db.SaveChanges();
            }
            Don();
        }
        #endregion
    }
}
