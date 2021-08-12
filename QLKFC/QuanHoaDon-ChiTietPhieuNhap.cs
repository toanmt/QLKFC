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
        int Mahdk = 0;
        string TrangThai = "";
        public ChiTietPhieuNhap()
        {
            InitializeComponent();
            
        }
        //Load dữ liệu
        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            load();  
        }
        public void load()
        {
            lblNote.Hide();
            int check = (int)this.Tag;
            Mahdk = check;
            lblMaHd.Text = check.ToString();
            var getHDK = db.HoaDonKhos.Where(x => x.MaHdk == check).SingleOrDefault();
            datetimpick.Value = getHDK.NgayCc.Value;
            TrangThai = getHDK.TrangThai;
            cbTrangThai.Text = TrangThai;
            if (TrangThai.Trim().Equals("Hoàn Thành"))
            {
                btnCapNhap.Hide();
                btnHuyDonDatHang.Hide();
                btnNhapKho.Hide();
                cbTrangThai.Enabled = false;
                lblNote.Show();
                lblNote.Text = "Đơn hàng đã hoàn thành.Nhập kho thành công";
            }
            else if (TrangThai.Trim().Equals("Đã hủy"))
            {
                btnCapNhap.Hide();
                btnHuyDonDatHang.Hide();
                btnNhapKho.Hide();
                cbTrangThai.Enabled = false;
                lblNote.Show();
                lblNote.Text = "Đơn hàng đã bị hủy";
            }
            else if (TrangThai.Trim().Equals("Đang giao hàng"))
            {
                cbTrangThai.Enabled = false;
                btnCapNhap.Hide();
            }

            var query = from k in db.CthoaDonKhos
                        where k.MaHdk == check
                        select new
                        {
                            k.MaNlNavigation.MaNl,
                            k.MaNlNavigation.TenNl,
                            k.MaNlNavigation.DonGia,
                            k.SoLuong
                        };
            foreach (var item in query)
            {
                var tongtien = item.DonGia.Value * item.SoLuong.Value;
                string[] row = { item.MaNl.ToString(), item.MaNl.ToString(), string.Format("{0:#,##0}",int.Parse(item.DonGia.ToString())), item.SoLuong.ToString(), string.Format("{0:#,##0}", int.Parse(tongtien.ToString())) };
                dgvNhapHang.Rows.Add(row);
            }
        }
        //Nhập kho khi hoàn thành hóa đơn
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

        //Cập nhập trạng thái
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            db.HoaDonKhos.Where(x => x.MaHdk == Mahdk).SingleOrDefault().TrangThai = cbTrangThai.Text;
            db.SaveChanges();
            MessageBox.Show("Cập nhập trạng thái thành công !");
            dgvNhapHang.Rows.Clear();
            load();
        }

        //Hủy đơn hàng
        private void btnHuyDonDatHang_Click(object sender, EventArgs e)
        {
            if (TrangThai.Trim().Equals("Đang giao hàng"))
                MessageBox.Show("Đơn hàng đang được giao. Vui lòng liên hệ bếp trung tâm!");
            else
            {
                
                DialogResult dl =  MessageBox.Show("Bạn có muổn hủy đơn hàng hiện tại", "Hủy đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl == DialogResult.Yes)
                {
                    var check = db.HoaDonKhos.Where(x => x.MaHdk == Mahdk).SingleOrDefault();
                    check.TrangThai = "Đã hủy";
                    MessageBox.Show("Hủy đơn hàng thành công. Bếp trung tâm sẽ liên hệ với bạn!");
                    db.SaveChanges();
                    this.Close();
                }
            }    
        }
    }
}
