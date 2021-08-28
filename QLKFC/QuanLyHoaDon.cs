using OfficeOpenXml;
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
        int Pagenumber = 1;     // Trang bắt đầu
        int check = 0;          //Kiểm tra xem đang thống kê hay không
        int NumberItem = 0;     //Lấy số hóa đơn của 1 quyery
        int Quyen=0;            //Kiểm tra quyền của tài khoản
        string TenNV = "";
        public QuanLyHoaDon(int Quyen,String TenNV)
        {
            InitializeComponent();
            dtpick1.Value = DateTime.Now.Date;
            dtpick2.Value = DateTime.Now.Date;
            dgvHDBH.EnableHeadersVisualStyles = false;
            dgvHDBH.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;

            this.Quyen = Quyen;
            this.TenNV = TenNV;
            load(Pagenumber, Program.ItemNumber);

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
        //Load thống kê
        public void load2(int Pagenumber, int ItemNumber)
        {
            if (this.Quyen == 1)
            {
                var query = from h in db.HoaDons.Where(x=>x.NgayThang.Value.Date>=dtpick1.Value&& x.NgayThang.Value.Date <= dtpick2.Value).Skip((Pagenumber - 1) * Program.SkipItem).Take(ItemNumber).OrderByDescending(x => x.NgayThang)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                dgvHDBH.DataSource = query.ToList();
            }
            else
            {
                var query = from h in db.HoaDons.Where(x => x.NgayThang.Value.Date.Equals(DateTime.Now.Date)).Skip((Pagenumber - 1) * Program.SkipItem).Take(ItemNumber)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                dgvHDBH.DataSource = query.ToList();
            }
                dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHDBH.Columns[1].HeaderText = "Nhân viên";
                dgvHDBH.Columns[2].HeaderText = "Store ID";
                dgvHDBH.Columns[3].HeaderText = "Pos";
                dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
                btnTrangHienTai.Text = Pagenumber.ToString();

        }

        //Load all hóa đơn
        public void load(int Pagenumber, int ItemNumber)
        { 
            if (this.Quyen == 1)
            {
                var query = from h in db.HoaDons.Skip((Pagenumber - 1) * Program.SkipItem).Take(ItemNumber).OrderByDescending(x => x.NgayThang)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                dgvHDBH.DataSource = query.ToList();
            }
            else
            {
                var query = from h in db.HoaDons.Where(x => x.NgayThang.Value.Date.Equals(DateTime.Now.Date)).Skip((Pagenumber - 1) * Program.SkipItem).Take(ItemNumber).OrderByDescending(x => x.NgayThang)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                dgvHDBH.DataSource = query.ToList();
            }    
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
                load2(Pagenumber, Program.ItemNumber);
                check = 1;
        }
        private void btnDau_Click(object sender, EventArgs e)
        {

            Pagenumber = 1;
            if (check == 0)
                load(Pagenumber, Program.ItemNumber);
            else
                load2(Pagenumber, Program.ItemNumber);
        }

        #region Nút phân trang
        private void btnTrangtrc_Click(object sender, EventArgs e)
        {
            if (Pagenumber - 1 > 0)
            {
                Pagenumber--;
                if (check == 0)
                    load(Pagenumber, Program.ItemNumber);

                else
                    load2(Pagenumber, Program.ItemNumber);

            }
        }

        private void btnTrangsau_Click(object sender, EventArgs e)
        {
            if (Quyen == 1)
            {
                if (check == 0)
                    NumberItem = db.HoaDons.Count();
                else
                    NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date >= dtpick1.Value && x.NgayThang.Value.Date <= dtpick2.Value).Count();
            }
            else
                NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date.Equals(DateTime.Now.Date)).Count();

            if (Pagenumber - 1 < NumberItem / Program.SkipItem)
            {
                if (NumberItem % Program.SkipItem == 0)
                    Pagenumber = NumberItem / Program.SkipItem;
                else
                {
                    Pagenumber++;
                }
                if (check == 0)
                    load(Pagenumber, Program.ItemNumber);
                else
                    load2(Pagenumber, Program.ItemNumber);
            }



        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                if (Quyen == 1)
                    NumberItem = db.HoaDons.Count();
                else
                    NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date.Equals(DateTime.Now.Date)).Count();

                if (NumberItem % Program.SkipItem != 0)
                    Pagenumber = NumberItem / Program.SkipItem + 1;
                else Pagenumber = NumberItem / Program.SkipItem;

                load(Pagenumber, Program.ItemNumber);
            }
            else
            {
                int NumberItem = db.HoaDons.Where(x => x.NgayThang.Value.Date >= dtpick1.Value && x.NgayThang.Value.Date <= dtpick2.Value).Count();
                if (NumberItem % Program.SkipItem == 1)
                    Pagenumber = NumberItem / Program.SkipItem + 1;
                else Pagenumber = NumberItem / Program.SkipItem;
                if (Pagenumber == 0)
                    Pagenumber = 1;
                load2(Pagenumber, Program.ItemNumber);
            }

        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Pagenumber = 1;
            load(Pagenumber, Program.ItemNumber);
            check = 0;
        } 
        #endregion
        #endregion

        //Tìm kiếm theo mã hóa đơn +Tên nhân viên
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Equals(""))
            { return;
            }    
            else if (this.Quyen == 1)
            {
                var query = from h in db.HoaDons
                            where h.MaHd.ToString().Contains(txtTimKiem.Text)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                if (query.ToList().Count == 0)
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
                dgvHDBH.DataSource = query.ToList(); 
            }
            else
            {
                var query = from h in db.HoaDons.Where(x=>x.NgayThang.Value.Date == DateTime.Now.Date)
                            where h.MaHd.ToString().Contains(txtTimKiem.Text)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                if (query.ToList().Count == 0)
                    query = from h in db.HoaDons.Where(x => x.NgayThang.Value.Date == DateTime.Now.Date)
                            where h.TenNv.Contains(txtTimKiem.Text)
                            select new
                            {
                                h.MaHd,
                                h.TenNv,
                                h.StoreId,
                                h.Pos,
                                h.NgayThang,
                            };
                dgvHDBH.DataSource = query.ToList();
            }    

                dgvHDBH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHDBH.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHDBH.Columns[1].HeaderText = "Nhân viên";
                dgvHDBH.Columns[2].HeaderText = "Store ID";
                dgvHDBH.Columns[3].HeaderText = "Pos";
                dgvHDBH.Columns[4].HeaderText = "Ngày Tháng";
        } 
   }
}
