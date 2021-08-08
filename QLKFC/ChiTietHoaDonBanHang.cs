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
    public partial class ChiTietHoaDonBanHang : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        
        public ChiTietHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDonBanHang_Load(object sender, EventArgs e)
        {
            int tongtien = 0;
            int check = (int)this.Tag;
            var query = db.HoaDons.Where(x => x.MaHd == check).SingleOrDefault();
            var nvtg = db.NhanViens.Where(x => x.TenNv == query.TenNv).SingleOrDefault();

            //Gán các lable
            lblTenNhanVien.Text = nvtg.TenNv;
            lblPos.Text = query.Pos;
            lblStoreID.Text = query.StoreId;
            lblNgayThang.Text = query.NgayThang.ToString();
            lblMaHoaDon.Text = query.MaHd.ToString();

            //Hiển thị danh sách sp
            var query2 = from s in db.CthoaDons
                         where s.MaHd == check
                         select new
                         {
                             s.SoLuong,
                             s.MaSpNavigation.TenSp,
                             s.MaSpNavigation.DonGia
                         };
            foreach (var item in query2.ToList())
            {
                string tt = (string.Format("{0:#,##0}", (int)item.SoLuong * (int)item.DonGia));
                tongtien += (int)item.SoLuong*(int)item.DonGia;
                string[] row = { item.SoLuong.ToString(), item.TenSp.ToString(), tt};
                dgvChiTietHoaDonBanHang.Rows.Add(row);
            }
            lblTongTien.Text = String.Format("{0:#,##0}", tongtien);
            this.Text = "Hóa đơn : " + check;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
