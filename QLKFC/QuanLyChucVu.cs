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
    public partial class QuanLyChucVu : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();

        public QuanLyChucVu()
        {
            InitializeComponent();
        }
        #region Hiển Thị
        public void HienThi()
        {
            try
            {
                var query = from cv in db.ChucVus
                            select new
                            {
                               cv.MaCv,
                               cv.TenCv,
                               cv.Id
                            };
                dgvChucVu.DataSource = query.ToList();
                dgvChucVu.Columns[0].HeaderText = "Mã chức vụ";
                dgvChucVu.Columns[1].HeaderText = "Tên chức vụ";
                dgvChucVu.Columns[2].HeaderText = "Id tài khoản";

                dgvChucVu.Columns[0].Width = 300;
                dgvChucVu.Columns[1].Width = 300;
                dgvChucVu.Columns[2].Width = 155;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaTrang()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            cbQuyen.Text = "";
        }

        private void QuanLyChucVu_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtMaCV.Text = dgvChucVu.Rows[index].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.Rows[index].Cells[1].Value.ToString();
            string id = dgvChucVu.Rows[index].Cells[2].Value.ToString();
            if (id == "1")
                cbQuyen.Text = "Quản lý";
            if (id == "2")
                cbQuyen.Text = "Nhân Viên";
        }

        #endregion

        #region Các nút
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenCV.Text == "")
                    throw new Exception("Hãy nhập tên chức vụ!");
                if (db.ChucVus.Where(cv => cv.TenCv == txtTenCV.Text).FirstOrDefault() != null)
                    throw new Exception("Chức vụ đã tồn tại");
                if (cbQuyen.Text == "")
                    throw new Exception("Hãy chọn quyền tài khoản của chức vụ!");

                ChucVu cvMoi = new ChucVu();
                cvMoi.TenCv = txtTenCV.Text;
                if (cbQuyen.Text == "Quản lý")
                    cvMoi.Id = 1;
                if (cbQuyen.Text == "Nhân Viên")
                    cvMoi.Id = 2;

                db.ChucVus.Add(cvMoi);
                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCV.Text == "")
                    throw new Exception("Chọn chức vụ muốn sửa");

                ChucVu cvSua = db.ChucVus.Where(cv => cv.MaCv == int.Parse(txtMaCV.Text)).FirstOrDefault();
                cvSua.TenCv = txtTenCV.Text;
                if (cbQuyen.Text == "Quản lý")
                    cvSua.Id = 1;
                if (cbQuyen.Text == "Nhân Viên")
                    cvSua.Id = 2;

                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Sửa thành công!");
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
                if (txtMaCV.Text == "")
                    throw new Exception("Chọn chức vụ muốn xóa");
                ChucVu cvXoa = db.ChucVus.Where(cv => cv.MaCv == int.Parse(txtMaCV.Text)).FirstOrDefault();

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa chức vụ này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    db.ChucVus.Remove(cvXoa);
                    db.SaveChanges();
                    HienThi();
                    XoaTrang();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenCV.Text == "")
                    throw new Exception("Hãy nhập tên chức vụ mà bạn muốn tìm");
                if (db.ChucVus.Where(cv => cv.TenCv == txtTenCV.Text).FirstOrDefault() == null)
                    throw new Exception("Chức vụ không tồn tại");
                var query1 = from cv in db.ChucVus
                             where cv.TenCv == txtTenCV.Text
                             select new
                             {
                                 cv.MaCv,
                                 cv.TenCv,
                                 cv.Id
                             };
                dgvChucVu.DataSource = query1.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
