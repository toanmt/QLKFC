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
                dgvChucVu.Rows.Clear();
                var query = from cv in db.ChucVus
                            select new
                            {
                               cv.MaCv,
                               cv.TenCv,
                               //cv.Id
                            };
                foreach (var item in query)
                {
                    //dgvChucVu.Rows.Add(item.MaCv, item.TenCv, item.Id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvChucVu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Lỗi chọn thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Các nút

        private void btnThem_Click_1(object sender, EventArgs e)
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
                    //cvMoi.Id = 1;
                if (cbQuyen.Text == "Nhân Viên")
                    //cvMoi.Id = 2;

                db.ChucVus.Add(cvMoi);
                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi thêm chức vụ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCV.Text == "")
                    throw new Exception("Chọn chức vụ muốn sửa");

                ChucVu cvSua = db.ChucVus.Where(cv => cv.MaCv == int.Parse(txtMaCV.Text)).FirstOrDefault();
                cvSua.TenCv = txtTenCV.Text;
                if (cbQuyen.Text == "Quản lý")
                    //cvSua.Id = 1;
                if (cbQuyen.Text == "Nhân Viên")
                    //cvSua.Id = 2;

                db.SaveChanges();
                HienThi();
                XoaTrang();

                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi sửa thông tin chức vụ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Show("Lỗi xóa chức vụ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtTenCV.Text == "")
                    throw new Exception("Hãy nhập tên chức vụ mà bạn muốn tìm");
                if (db.ChucVus.Where(cv => cv.TenCv == txtTenCV.Text).FirstOrDefault() == null)
                    throw new Exception("Chức vụ không tồn tại");
                dgvChucVu.Rows.Clear();
                var query1 = from cv in db.ChucVus
                             where cv.TenCv == txtTenCV.Text
                             select new
                             {
                                 cv.MaCv,
                                 cv.TenCv,
                                 //cv.Id
                             };
                foreach (var item in query1)
                {
                    //dgvChucVu.Rows.Add(item.MaCv, item.TenCv, item.Id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi tìm chức vụ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region bắt lỗi
        private void txtTenCV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaCV.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenCV, "Bạn cần phải nhập tên chức vụ");
                txtTenCV.Focus();
            }
        }

        private void cbQuyen_Validating(object sender, CancelEventArgs e)
        {
            if(cbQuyen.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(cbQuyen, "Bạn hãy chọn quyền tài khoản của chức vụ");
                cbQuyen.Focus();
            }
        }

        private void txtTenCV_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenCV, "");
        }

        private void cbQuyen_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbQuyen, "");
        }

        #endregion

        
    }
}
