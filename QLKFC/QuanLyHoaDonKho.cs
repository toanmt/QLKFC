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
    public partial class QuanLyHoaDonKho : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        public QuanLyHoaDonKho()
        {
            InitializeComponent();
            load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.ShowDialog();
        }
        public void load()
        {
            var queryhd = from x in db.HoaDonKhos
                          select new
                          {
                              x.MaHdk,
                              x.NgayCc,
                              x.TrangThai,
                             
                          };
            dgvHoaDonKho.DataSource = queryhd.ToList();
            dgvHoaDonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonKho.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHoaDonKho.Columns[1].HeaderText = "Ngày Tạo";
            dgvHoaDonKho.Columns[2].HeaderText = "Trạng Thái";

             

        }



        private void dgvHoaDonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > -1)
            {
                int check = int.Parse(dgvHoaDonKho.Rows[index].Cells[0].Value.ToString());
                var querycthd = from k in db.CthoaDonKhos
                                where k.MaHdk == check
                                select new
                                {
                                    k.MaNlNavigation.TenNl,
                                    k.MaNlNavigation.DonGia,
                                    k.SoLuong,
                                    
                                };
                lblMaHoaDon.Text = check.ToString();
                dgvChiTietHoaDonKho.DataSource = querycthd.ToList();
                dgvChiTietHoaDonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvChiTietHoaDonKho.Columns[0].HeaderText = "Tên Nguyên liệu";
                dgvChiTietHoaDonKho.Columns[1].HeaderText = "Số lượng";
                dgvChiTietHoaDonKho.Columns[2].HeaderText = "Đơn giá";


            }
        }
    }
}
