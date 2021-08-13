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

        public void HienThi()
        {
            try
            {
                var query = from nl in db.NguyenLieus
                            select new
                            {
                                nl.MaNl,
                                nl.TenNl,
                                nl.DonGia
                            };
                dgvNguyenLieu.DataSource = query.ToList();
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu");
            }

            dgvNguyenLieu.Columns[0].HeaderText = "Mã nguyên liệu";
            dgvNguyenLieu.Columns[1].HeaderText = "Tên nguyên liệu";
            dgvNguyenLieu.Columns[2].HeaderText = "Đơn giá";

            dgvNguyenLieu.Columns[0].Width = 200;
            dgvNguyenLieu.Columns[1].Width = 400;
            dgvNguyenLieu.Columns[2].Width = 200;
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
            int index = e.RowIndex;
            txtMaNL.Text = dgvNguyenLieu.Rows[index].Cells[0].Value.ToString();
            txtTenNL.Text = dgvNguyenLieu.Rows[index].Cells[1].Value.ToString();
            txtDonGia.Text = dgvNguyenLieu.Rows[index].Cells[2].Value.ToString();
        }

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
                HienThi();
                XoaTrang();

                MessageBox.Show("Đã thêm nguyên liệu mới");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                var query1 = from nl in db.NguyenLieus
                             where nl.TenNl == txtTim.Text
                             select new
                             {
                                 nl.MaNl,
                                 nl.TenNl,
                                 nl.DonGia
                             };
                dgvNguyenLieu.DataSource = query1.ToList();
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
                NguyenLieu nlXoa = db.NguyenLieus.Where(nl => nl.MaNl == int.Parse(txtMaNL.Text)).FirstOrDefault();
                if (nlXoa == null)
                    throw new Exception("Không có nguyên liệu này!");

                db.NguyenLieus.Remove(nlXoa);
                db.SaveChanges();
                HienThi();
                XoaTrang();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
