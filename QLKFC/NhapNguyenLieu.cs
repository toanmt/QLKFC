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
    
    public partial class NhapNguyenLieu : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public NhapNguyenLieu()
        {
            InitializeComponent();
        }
        #region check lỗi
        private void txtTenNL_Validating(object sender, CancelEventArgs e)
        {
            if(txtTenNL.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenNL,"Bạn cần phải nhập tên nguyên liệu");
                txtTenNL.Focus();
            }
        }

        private void txtDonGia_Validating(object sender, CancelEventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDonGia, "Bạn cần phải nhập đơn giá của nguyên liệu");
                txtDonGia.Focus();
            }
        }

        private void txtTenNL_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenNL, "");
        }

        private void txtDonGia_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDonGia, "");
        }
        
        public void LoiThieuTT()
        {
            try
            {
                if (txtTenNL.Text == "")
                    throw new Exception("Bạn phải nhập tên nguyên liệu");
                if (txtDonGia.Text == "")
                    throw new Exception("Bạn phải nhập đơn giá");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi nhập thông tin nguyên liệu");
            }
        }
        #endregion
        #region hiển thị
        public void HienThi()
        {
            try
            {
                dgvNguyenLieu.Rows.Clear();
                var query = from nl in db.NguyenLieus
                            select new
                            {
                                nl.MaNl,
                                nl.TenNl,
                                nl.DonGia
                            };
                foreach (var item in query)
                {
                    dgvNguyenLieu.Rows.Add(item.MaNl, item.TenNl, item.DonGia);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void XoaTrang()
        {
            txtMaNL.Clear();
            txtTenNL.Clear();
            txtDonGia.Clear();
        }

        private void NhapNguyenLieu_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index > -1)
                {
                    txtMaNL.Text = dgvNguyenLieu.Rows[index].Cells[0].Value.ToString();
                    txtTenNL.Text = dgvNguyenLieu.Rows[index].Cells[1].Value.ToString();
                    txtDonGia.Text = dgvNguyenLieu.Rows[index].Cells[2].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi chọn thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region các nút
        private void btnThem_Click(object sender, EventArgs e)
        {
            LoiThieuTT();
            try
            {
                if (db.NguyenLieus.Where(nl => nl.TenNl == txtTenNL.Text).FirstOrDefault() != null)
                    throw new Exception("Nguyên liệu đang đợi nhập!");
                NguyenLieu nlMoi = new NguyenLieu();
                nlMoi.TenNl = txtTenNL.Text;
                nlMoi.DonGia = float.Parse(txtDonGia.Text);
                db.NguyenLieus.Add(nlMoi);
                db.SaveChanges();
                Kho nl = new Kho();
                nl.MaNl = db.NguyenLieus.Select(x => x).Last().MaNl;
                nl.SoLuong = 0;
                db.Khos.Add(nl);
                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Đã thêm nguyên liệu mới");
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi thêm nguyên liệu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoiThieuTT();
            try
            {
                NguyenLieu nlSua = db.NguyenLieus.Where(nl => nl.MaNl == int.Parse(txtMaNL.Text)).FirstOrDefault();
                if (nlSua == null)
                    throw new Exception("Không có nguyên liệu này!");
                nlSua.TenNl = txtTenNL.Text;
                nlSua.DonGia = float.Parse(txtDonGia.Text);

                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Sửa thành công");
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi sửa thông tin nguyên liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            HienThi();
            XoaTrang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text == "")
                    throw new Exception("Hãy nhập tên nguyên liệu muốn tìm");
                if (db.NguyenLieus.Where(nl => nl.TenNl == txtTim.Text).FirstOrDefault() == null)
                    throw new Exception("Không có nguyên liệu này trong kế hoạch nhập");
                dgvNguyenLieu.Rows.Clear();
                var query1 = from nl in db.NguyenLieus
                             where nl.TenNl == txtTim.Text
                             select new
                             {
                                 nl.MaNl,
                                 nl.TenNl,
                                 nl.DonGia
                             };
                foreach (var item in query1)
                {
                    dgvNguyenLieu.Rows.Add(item.MaNl, item.TenNl, item.DonGia);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi tìm nguyên liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu nlXoa = db.NguyenLieus.Where(nl => nl.MaNl == int.Parse(txtMaNL.Text)).FirstOrDefault();
                if (nlXoa == null)
                    throw new Exception("Không có nguyên liệu này!");

                db.NguyenLieus.Remove(nlXoa);
                db.SaveChanges();
                HienThi();
                XoaTrang();
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi xóa nguyên liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
