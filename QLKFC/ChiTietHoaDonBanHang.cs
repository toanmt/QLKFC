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
            int check = (int)this.Tag;
            var query = db.HoaDons.Where(x => x.MaHd == check).SingleOrDefault();
            var nvtg = db.NhanViens.Where(x => x.TenNv == query.TenNv).SingleOrDefault();
            lblTenNhanVien.Text = nvtg.TenNv;
            lblPos.Text = query.Pos;
            lblStoreID.Text = query.StoreId;
            var query2 = from s in db.CthoaDons
                         where s.MaHd == check
                         select new
                         {
                             s.MaSp,
                             s.MaSpNavigation.TenSp,
                             s.MaSpNavigation.Mota,
                             s.SoLuong
                         };
            dgvChiTietHoaDonBanHang.DataSource = query2.ToList();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblStoreID_Click(object sender, EventArgs e)
        {

        }
    }
}
