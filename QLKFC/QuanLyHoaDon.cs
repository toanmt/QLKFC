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
    /// <summary>
    /// 
    /// </summary>
    public partial class QuanLyHoaDon : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index;
        int Pagenumber = 1;
        int ItemNumber = 10;
        int check = 0;
        public QuanLyHoaDon()
        {
            InitializeComponent();
            dtpick1.Value = DateTime.Now.Date;
            dtpick2.Value = DateTime.Now.Date;
            load(Pagenumber, ItemNumber);

        }
        //Lấy danh sách hóa đơn theo ngày đã chọn

        #region Xem chi tiết hóa đơn
        private void dgvHDBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = 0;
            index = e.RowIndex;
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                ChiTietHoaDonBanHang frm = new ChiTietHoaDonBanHang();
                frm.Tag = (int)dgvHDBH.Rows[index].Cells[0].Value;
                frm.Show();
            }
            else
                MessageBox.Show("Chưa chọn hóa đơn !");
        }
        #endregion

        #region Phân trang + load dữ liệu
        public void load2(int Pagenumber, int ItemNumber)
        {
            var query = from h in db.HoaDons.Skip((Pagenumber - 1) * 10).Take(ItemNumber).OrderByDescending(x => x.NgayThang)
                        where h.NgayThang.Value.Date >= dtpick1.Value && h.NgayThang.Value.Date <= dtpick2.Value
                        select new
                        {
                            h.MaHd,
                            h.TenNv,
                            h.StoreId,
                            h.Pos,
                            h.NgayThang,
                        };
            if (query.ToList().Count() > 0)
            {
                dgvHDBH.DataSource = query.ToList();
                dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHDBH.Columns[1].HeaderText = "Nhân viên";
                dgvHDBH.Columns[2].HeaderText = "Store ID";
                dgvHDBH.Columns[3].HeaderText = "Pos";
                dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
                btnTrangHienTai.Text = Pagenumber.ToString();
            }
            else
                MessageBox.Show("Không tìm thấy hóa đơn nào !!!");
        }
        public void load(int Pagenumber, int ItemNumber)
        {

            var query = from h in db.HoaDons.Skip((Pagenumber - 1) * 10).Take(ItemNumber).OrderByDescending(x => x.NgayThang)
                        select new
                        {
                            h.MaHd,
                            h.TenNv,
                            h.StoreId,
                            h.Pos,
                            h.NgayThang,
                        };
            dgvHDBH.DataSource = query.ToList();
            dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDBH.Columns[1].HeaderText = "Nhân viên";
            dgvHDBH.Columns[2].HeaderText = "Store ID";
            dgvHDBH.Columns[3].HeaderText = "Pos";
            dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
            btnTrangHienTai.Text = Pagenumber.ToString();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Pagenumber = 1;
            load2(Pagenumber, ItemNumber);
            check = 1;
        }
        private void btnDau_Click(object sender, EventArgs e)
        {

            Pagenumber = 1;
            if (check == 0)
                load(Pagenumber, ItemNumber);
            else
                load2(Pagenumber, ItemNumber);
        }

        private void btnTrangtrc_Click(object sender, EventArgs e)
        {
            if (Pagenumber - 1 > 0)
            {
                Pagenumber--;
                if (check == 0)
                    load(Pagenumber, ItemNumber);

                else
                    load2(Pagenumber, ItemNumber);

            }
        }

        private void btnTrangsau_Click(object sender, EventArgs e)
        {
            int NumberItem = 0;
            if (check == 0)
                NumberItem = db.HoaDons.Count();
            else
                NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date >= dtpick1.Value && x.NgayThang.Value.Date <= dtpick2.Value).Count();

            if (Pagenumber - 1 < NumberItem / 10)
            {
                if (NumberItem % 10 == 0)
                    Pagenumber = NumberItem / 10;
                else { 
                    Pagenumber++;
                if (check == 0)
                    load(Pagenumber, ItemNumber);
                else
                    load2(Pagenumber, ItemNumber);} 
                    
                
            }
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                int NumberItem = db.HoaDons.Count();
                if (NumberItem % 10 != 0)
                    Pagenumber = NumberItem / 10 + 1;
                else Pagenumber = NumberItem / 10;
                load(Pagenumber, ItemNumber);
            }
            else
            {
                int NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date >= dtpick1.Value && x.NgayThang.Value.Date <= dtpick2.Value).Count();
                if (NumberItem % 10 == 1)
                    Pagenumber = NumberItem / 10 + 1;
                else Pagenumber = NumberItem / 10;
                if (Pagenumber == 0)
                    Pagenumber = 1;
                load2(Pagenumber, ItemNumber);
            }

        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Pagenumber = 1;
            load(Pagenumber, ItemNumber);
            check = 0;
        }
        #endregion

        //Tìm kiếm theo mã hóa đơn +Tên nhân viên
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var query = from h in db.HoaDons
                        where h.MaHd.ToString().Contains(txtTimKiem.Text)
                        select new  {
                                        h.MaHd,
                                        h.TenNv,
                                        h.StoreId,
                                        h.Pos,
                                        h.NgayThang,
                                    };
            if(query.ToList().Count == 0)
                query = from h in db.HoaDons
                            where h.TenNv.Contains(txtTimKiem.Text)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
            if (query.ToList().Count == 0)
                MessageBox.Show("Không có hóa đơn nào !");
            else
            {
                dgvHDBH.DataSource = query.ToList();
                dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHDBH.Columns[1].HeaderText = "Nhân viên";
                dgvHDBH.Columns[2].HeaderText = "Store ID";
                dgvHDBH.Columns[3].HeaderText = "Pos";
                dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
            }
        }

        
    }
}
