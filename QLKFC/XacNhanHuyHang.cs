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
    public partial class XacNhanHuyHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        String TenNV;

        public XacNhanHuyHang(string TenNV)
        {
            InitializeComponent();
            load();
            this.TenNV = TenNV;
        }

        #region Lấy dữ liệu vào cbbox + textbox
        public void load()
        {
            var query = from k in db.Khos
                        join n in db.NguyenLieus on k.MaNl equals n.MaNl
                        select new
                        {
                            k.MaNl,
                            n.TenNl,
                            n.DonGia,
                            k.SoLuong
                        };
            cbNguyenLieu.DataSource = query.ToList();
            cbNguyenLieu.DisplayMember = "TenNl";
            cbNguyenLieu.ValueMember = "Dongia";
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
            cbNguyenLieu.SelectedIndex = 1;
            cbNguyenLieu.SelectedIndex = 0;
        }

        private void dgvHuyHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            txtSoLuongTon.Text = cbNguyenLieu.SelectedValue.ToString();
            var check = db.NguyenLieus.Where(x => x.TenNl == cbNguyenLieu.Text).Select(x => x.MaNl).FirstOrDefault();
            var query = db.Khos.Select(x => x);
            foreach (var item in query)
            {
                if (item.MaNl.ToString() == check.ToString())
                {
                    txtSoLuongTon.Text = item.SoLuong.ToString();
                }
                
            }
        }
        #endregion

        #region Các nút thêm, xóa hủy, sửa,xác nhận
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtSoLuongTon.Text) == 0)
                    throw new Exception("Nguyên liệu này đã hết !!!");
                if (txtSoLuongHuy.Text.Equals(""))
                    throw new Exception("Bạn chưa nhập số lượng!");
                if (int.Parse(txtSoLuongHuy.Text) < 0)
                    throw new Exception("Số lượng phải > 0 !");
                if (int.Parse(txtSoLuongHuy.Text) > int.Parse(txtSoLuongTon.Text))
                    throw new Exception("Số lượng xuất phải < số lượng tồn");

                var query = (from s in db.NguyenLieus
                             where s.TenNl == cbNguyenLieu.Text
                             select s).SingleOrDefault();
                for (int i = 0; i < dgvHuyHang.Rows.Count; i++)
                    if (query.MaNl.ToString().Equals(dgvHuyHang.Rows[i].Cells[0].Value))
                    {
                        int SLCu = int.Parse(dgvHuyHang.Rows[i].Cells[3].Value.ToString());
                        if (SLCu == int.Parse(txtSoLuongTon.Text))
                            throw new Exception("Số lượng hủy vào đã đạt tối đa. Không thể thêm nữa!!!");
                        int SLMoi = int.Parse(txtSoLuongHuy.Text);
                        if ((SLCu + SLMoi) <= int.Parse(txtSoLuongTon.Text))
                        {
                            dgvHuyHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", (SLCu + SLMoi));
                            return;
                        }
                        else
                            throw new Exception("Không thể hủy nhiều hơn số lượng trong kho !!!");
                    }
                string[] row = { query.MaNl.ToString(), cbNguyenLieu.Text, string.Format("{0:#,##0}", int.Parse(txtdongia.Text)), txtSoLuongHuy.Text };

                dgvHuyHang.Rows.Add(row);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Số lượng phải là số > 0");
                txtSoLuongHuy.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtSoLuongHuy.Focus();
            }
        }
        //Xóa 1 dòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (index > -1 && index < dgvHuyHang.RowCount - 1)
            {
                dgvHuyHang.Rows.RemoveAt(index);
                index--;
            }
            else
            {
                MessageBox.Show("Chưa chọn nguyên liệu để xóa !");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Sửa 1 dòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            var query = (from s in db.NguyenLieus
                         where s.TenNl == cbNguyenLieu.Text
                         select s).SingleOrDefault();
            for (int i = 0; i < dgvHuyHang.Rows.Count - 1; i++)
                if (query.MaNl.ToString().Equals(dgvHuyHang.Rows[i].Cells[0].Value))
                {
                    int SLCu = int.Parse(txtSoLuongTon.Text);
                    int SLMoi = int.Parse(txtSoLuongHuy.Text);
                    if (SLMoi <= SLCu)
                        dgvHuyHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", SLMoi);
                    else
                        MessageBox.Show("Số lượng không đủ để cập nhập!!!");
                    return;
                }
        }
        // Xác nhận hủy hàng
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var query = db.Khos.Select(x => x);
                int index = dgvHuyHang.Rows.Count;
                if (index == 0)
                    throw new Exception("Chưa có nguyên liệu nào");
                else
                {
                    if (txtLyDo.Text == "")
                        throw new Exception("Chưa nhập lý do");
                    BaoCao bc = new BaoCao();
                    bc.NgayLap = DateTime.Now;
                    bc.StoreId = "044";
                    bc.Loai = "Hủy hàng";
                    bc.TenNv = this.TenNV;
                    String MoTa = txtLyDo.Text;
                    for (int i = 0; i < index; i++)
                    {
                        String d1 = dgvHuyHang.Rows[i].Cells[0].Value.ToString();
                        String d2 = dgvHuyHang.Rows[i].Cells[1].Value.ToString();
                        float d3 = float.Parse(dgvHuyHang.Rows[i].Cells[2].Value.ToString());
                        int d4 = int.Parse(dgvHuyHang.Rows[i].Cells[3].Value.ToString());
                        MoTa += "\n" + d2 + "- Số lượng : " + d4 + "- Tổng : " + (d3 * d4).ToString();
                        foreach (var item in query)
                        {
                            if (d1 == item.MaNl.ToString())
                                item.SoLuong -= d4;
                        }
                    }
                    bc.Mota = MoTa;
                    db.BaoCaos.Add(bc);
                    db.SaveChanges();
                    MessageBox.Show("Hủy hàng thành công. !");
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion


    }
}

