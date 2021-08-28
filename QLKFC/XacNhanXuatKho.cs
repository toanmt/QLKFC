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
    public partial class XacNhanXuatKho : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        string TenNV;
        public XacNhanXuatKho(string TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            load();
        }
        #region Lấy dữ liệu vào cbbox + textbox
        public void load()
        {
            var query = from x in db.Khos
                        join y in db.NguyenLieus on x.MaNl equals y.MaNl
                        select new
                        {
                            x.MaNl,
                            y.TenNl,
                            y.DonGia,
                            x.SoLuong,
                        };
            cbNguyenLieu.DataSource = query.ToList();
            cbNguyenLieu.DisplayMember = "TenNL";
            cbNguyenLieu.ValueMember = "DonGia";
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
            cbNguyenLieu.SelectedIndex = 1;
            cbNguyenLieu.SelectedIndex = 0;
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
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

        #region Các nút thêm, xóa, sửa,hủy,xuất kho
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtSoLuongTon.Text) == 0)
                    throw new Exception("Nguyên liệu này đã hết !!!");
                if (txtSoLuong.Text.Equals(""))
                    throw new Exception("Bạn chưa nhập số lượng!");
                if (int.Parse(txtSoLuong.Text) < 0)
                    throw new Exception("Số lượng phải > 0 !");
                if (int.Parse(txtSoLuong.Text) > int.Parse(txtSoLuongTon.Text))
                    throw new Exception("Số lượng xuất phải < số lượng tồn");

                var query = (from s in db.NguyenLieus
                             where s.TenNl == cbNguyenLieu.Text
                             select s).SingleOrDefault();
                for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
                    if (query.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                    {
                        int SLCu = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                        if (SLCu == int.Parse(txtSoLuongTon.Text))
                            throw new Exception("Số lượng thêm vào đã đạt tối đa. Không thể thêm nữa!!!");
                        int SLMoi = int.Parse(txtSoLuong.Text);
                        if ((SLCu + SLMoi) <= int.Parse(txtSoLuongTon.Text))
                        {
                            dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", (SLCu + SLMoi));
                            return;
                        }
                        else
                            throw new Exception("Không thể xuất nhiều hơn số lượng trong kho !!!");
                    }
                string[] row = { query.MaNl.ToString(), cbNguyenLieu.Text, string.Format("{0:#,##0}", int.Parse(txtdongia.Text)), txtSoLuong.Text };

                dgvNhapHang.Rows.Add(row);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Số lượng phải là số > 0");
                txtSoLuong.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtSoLuong.Focus();
            }
        }
        //Xóa 1 dòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (index > -1 && index < dgvNhapHang.RowCount)
            {
                dgvNhapHang.Rows.RemoveAt(index);
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
            try
            {
                var query = (from s in db.NguyenLieus
                             where s.TenNl == cbNguyenLieu.Text
                             select s).SingleOrDefault();
                for (int i = 0; i < dgvNhapHang.Rows.Count - 1; i++)
                    if (query.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                    {
                        int SLCu = int.Parse(txtSoLuongTon.Text);
                        int SLMoi = int.Parse(txtSoLuong.Text);
                        if (SLMoi < 0)
                            throw new Exception("Số lượng phải > 0");
                        if (SLMoi <= SLCu)
                            dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", SLMoi);
                        else
                            MessageBox.Show("Số lượng không đủ để cập nhập!!!");
                        return;
                    }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Số lượng phải là số > 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Xuất kho
        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            int index = dgvNhapHang.Rows.Count;
            var query = db.Khos.Select(x => x);

            if (index == 0)
                MessageBox.Show("Chưa có nguyên liệu nào !");
            else
            {
                BaoCao bc = new BaoCao();
                bc.NgayLap = DateTime.Now;
                bc.StoreId = "044";
                bc.Loai = "Xuất hàng";
                bc.TenNv = this.TenNV;
                String MoTa = "Xuất hàng thành công";
                for (int i = 0; i < index; i++)
                {
                    String d1 = dgvNhapHang.Rows[i].Cells[0].Value.ToString();
                    String d2 = dgvNhapHang.Rows[i].Cells[1].Value.ToString();
                    float d3 = float.Parse(dgvNhapHang.Rows[i].Cells[2].Value.ToString());
                    int d4 = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                    MoTa += "\n" + d2 + "- Số lượng : " + d4 + "- Tổng : " + (d3 * d4).ToString();
                    foreach (var item in query)
                    {
                        if (d1 == item.MaNl.ToString())
                            item.SoLuong -= d4;
                    }
                }
                bc.Mota = MoTa;
                db.BaoCaos.Add(bc);
            }
            db.SaveChanges();
            this.Close();
            MessageBox.Show("Xuất kho thành công !");
        } 
        #endregion
    }
}


