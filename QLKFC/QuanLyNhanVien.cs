using OfficeOpenXml;
using QLKFC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKFC
{
    public partial class QuanLyNhanVien : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        string soCMND = "";

        public void HienThi()
        {
            try
            {
                dgvNhanVien.Rows.Clear();
                var query = from nv in db.NhanViens
                            select new
                            {
                                nv.SoCmt,
                                nv.TenNv,
                                nv.GioiTinh,
                                nv.NgaySinh,
                                nv.DiaChi,
                                nv.SoDienThoai,
                                nv.Email,
                                nv.NgayBatDau,
                                cv = nv.MaCvNavigation.TenCv
                            };
                foreach (var item in query)
                {
                    dgvNhanVien.Rows.Add(item.SoCmt, item.TenNv, item.GioiTinh, item.NgaySinh, item.DiaChi, item.SoDienThoai, item.Email, item.NgayBatDau, item.cv);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (QuanLyNhanVien_Them frm = new QuanLyNhanVien_Them()){
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    HienThi();
                }
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var p = new ExcelPackage())
                {
                    var ws = p.Workbook.Worksheets.Add("Nhân Viên");

                    for (int i = 0; i < dgvNhanVien.ColumnCount; i++)
                    {
                        ws.Cells[1, i + 1].Value = dgvNhanVien.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvNhanVien.RowCount; i++)
                    {
                        for (int j = 0; j < dgvNhanVien.ColumnCount; j++)
                        {
                            ws.Cells[i + 2, j + 1].Value = dgvNhanVien.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    ws.Cells["1:1"].Style.Font.Bold = true;
                    ws.Cells.Style.Font.Name = "Arial";

                    p.SaveAs(new FileInfo(@"\Nhân viên.xlsx"));
                }
                MessageBox.Show("Thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xuất file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if(index > -1)
                    soCMND = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy chọn nhân viên trong bảng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (soCMND == "")
                    throw new Exception("Bạn phải chọn nhân viên muốn xóa");
                NhanVien nvXoa = db.NhanViens.Where(nv => nv.SoCmt == soCMND).FirstOrDefault();
                if (nvXoa == null)
                    throw new Exception("Nhân viên không tồn tại");
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TaiKhoan tkXoa = db.TaiKhoans.Where(tk => tk.Id == nvXoa.Id).FirstOrDefault();
                    db.TaiKhoans.Remove(tkXoa);
                    db.SaveChanges();
                    db.NhanViens.Remove(nvXoa);
                    db.SaveChanges();
                    HienThi();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xóa nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (soCMND == "")
                    throw new Exception("Hãy chọn nhân viên muốn sửa");
                using (QuanLyNhanVien_Sua frm = new QuanLyNhanVien_Sua(soCMND))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        HienThi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text == "")
                    throw new Exception("Bạn hãy nhập Số CMND của nhân viên cần tìm");
                dgvNhanVien.Rows.Clear();
                var query1 = from nv in db.NhanViens
                             where nv.SoCmt == txtTim.Text
                             select new
                             {
                                 nv.SoCmt,
                                 nv.TenNv,
                                 nv.GioiTinh,
                                 nv.NgaySinh,
                                 nv.DiaChi,
                                 nv.SoDienThoai,
                                 nv.Email,
                                 nv.NgayBatDau,
                                 cv = nv.MaCvNavigation.TenCv
                             };
                foreach (var item in query1)
                {
                    dgvNhanVien.Rows.Add(item.SoCmt, item.TenNv, item.GioiTinh, item.NgaySinh, item.DiaChi, item.SoDienThoai, item.Email, item.NgayBatDau, item.cv);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi tìm nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (soCMND == "")
                    throw new Exception("Hãy chọn nhân viên muốn xem chi tiết");
                QuanLyNhanVien_ChiTiet frm = new QuanLyNhanVien_ChiTiet(soCMND);
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
