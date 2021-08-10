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
    public partial class ChiTietPhieuNhap : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();

        
        public ChiTietPhieuNhap()
        {
            InitializeComponent();
            
        }

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            
            int check = (int)this.Tag;
            var query = from k in db.CthoaDonKhos
                        where k.MaHdk == check
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            lblMaHd.Text = check.ToString();
            datatimepick.Value = db.HoaDons.Where(x => x.MaHd == check).SingleOrDefault().NgayThang.Value;
            foreach (var item in query)
            {
                var tongtien = item.DonGia.Value * item.SoLuong.Value;
                string[] row = { item.MaNl.ToString(), item.MaNl.ToString(), item.DonGia.ToString(), item.SoLuong.ToString(), tongtien.ToString() };
                dgvNhapHang.Rows.Add(row);
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            int check = (int)this.Tag;
            var query = db.CthoaDonKhos.Where(x => x.MaHdk == check);
            List<CthoaDonKho> listhdk = new List<CthoaDonKho>();
            listhdk = query.ToList();
            var queryKho = db.Khos.Select(x => x);
            foreach (var item in listhdk)
            {
                foreach (var itemKho in queryKho)
                {
                    if (item.MaNl == itemKho.MaNl)
                        itemKho.SoLuong += item.SoLuong;
                }
            }

            db.HoaDonKhos.Where(x => x.MaHdk == check).FirstOrDefault().TrangThai = "Hoàn Thành";
            db.SaveChanges();
            DialogResult dl = MessageBox.Show("Nhập hàng vào kho","Xác nhận đã giao hàng",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                this.Close();
                MessageBox.Show("Nhập hàng thành công. Kiểm tra kho hàng của bạn");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
