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
    public partial class NhapHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = 0;
        public NhapHang()
        {
            InitializeComponent();
            load();
        }

        #region Tương tác với bảng + combo box
        public void load()
        {

            var query = from x in db.NguyenLieus
                        select x;
            cbNguyenLieu.DataSource = query.ToList();
            cbNguyenLieu.DisplayMember = "TenNL";
            cbNguyenLieu.ValueMember = "DonGia";
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        private void cbNguyenLieu_SelectedValueChanged(object sender, EventArgs e)
        {
            txtdongia.Text = cbNguyenLieu.SelectedValue.ToString();
        }
        #endregion


        #region Các nút thêm trong form
        //Thêm 1 dòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text.Equals(""))
                    throw new Exception("Bạn chưa nhập số lượng!");
                if (int.Parse(txtSoLuong.Text) < 0)
                    throw new Exception("Số lượng phải > 0 !");
                var query = (from s in db.NguyenLieus
                             where s.TenNl == cbNguyenLieu.Text
                             select s).SingleOrDefault();
                for (int i = 0; i < dgvNhapHang.Rows.Count - 1; i++)
                    if (query.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                    {
                        int SLCu = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                        int SLMoi = int.Parse(txtSoLuong.Text);

                        dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", (SLCu + SLMoi));
                        dgvNhapHang.Rows[i].Cells[4].Value = string.Format("{0:#,##0}", (SLCu + SLMoi) * query.DonGia);
                        return;
                    }
                float tongtien = (float.Parse(txtdongia.Text) * float.Parse(txtSoLuong.Text));

                string[] row = { query.MaNl.ToString(), cbNguyenLieu.Text, string.Format("{0:#,##0}", int.Parse(txtdongia.Text)), txtSoLuong.Text, string.Format("{0:#,##0}", int.Parse(tongtien.ToString())) };

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
            if (index > -1)
            {
                dgvNhapHang.Rows.RemoveAt(index);
                index--;
            }
            else
            {
                MessageBox.Show("Chưa chọn nguyên liệu để xóa !");
            }
        }
        //Gửi đơn hàng đi
        private void btnGuiDi_Click(object sender, EventArgs e)
        {
            int index = dgvNhapHang.Rows.Count;
            if (index == 1)
            {
                MessageBox.Show("Chưa có nguyên liệu nào !!!");
            }
            else
            {
                HoaDonKho hdk = new HoaDonKho();

                hdk.NgayCc = datatimepick.Value;
                hdk.TrangThai = "Đang xử lý";
                db.HoaDonKhos.Add(hdk);
                db.SaveChanges();

                var query = db.HoaDonKhos.Where(x => x.NgayCc == datatimepick.Value).FirstOrDefault();

                for (int i = 0; i < (index - 1); i++)
                {
                    CthoaDonKho cthdk = new CthoaDonKho();
                    cthdk.MaHdk = query.MaHdk;
                    cthdk.MaNl = int.Parse(dgvNhapHang.Rows[i].Cells[0].Value.ToString());
                    cthdk.SoLuong = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                    db.CthoaDonKhos.Add(cthdk);
                }
                db.SaveChanges();
                this.Close();
                MessageBox.Show("Đặt hàng thành công !");
            }
        }
        //Hủy đặt hàng
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
            for (int i = 0; i < dgvNhapHang.Rows.Count - 1; i++)
                if (query.MaNl.ToString().Equals(dgvNhapHang.Rows[i].Cells[0].Value))
                {
                    int SLCu = int.Parse(dgvNhapHang.Rows[i].Cells[3].Value.ToString());
                    int SLMoi = int.Parse(txtSoLuong.Text);

                    dgvNhapHang.Rows[i].Cells[3].Value = string.Format("{0:#,##0}", SLMoi);
                    dgvNhapHang.Rows[i].Cells[4].Value = string.Format("{0:#,##0}", SLMoi * query.DonGia);
                    return;
                }
        }
        #endregion
    }
}
