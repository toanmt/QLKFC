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
            //lblTenNhanVien.Text = query.MaNvNavigation.TenNv;
            lblPos.Text = query.Pos;
            lblStoreID.Text = query.StoreId;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
