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
    public partial class Dashboard : Form
    {

        int Quyen;
        string tenNV, sid, pid;
        public Dashboard()
       {
            InitializeComponent();
            hideSubMenu();
        }
        public Dashboard(int Quyen,string tenNV)
        {
            InitializeComponent();
            hideSubMenu();
            this.Quyen = Quyen;
            this.tenNV = tenNV;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblTenNV.Text = tenNV;
            label4.Text = tenNV;
            if (Quyen == 2)
            {
                btnSanPham.Visible = false;
                btnNhanVien.Visible = false;
                btnKho.Visible = false;
                btnNhapNL.Visible = false;
                btnBaoCao.Visible = false;
            }
            else if (Quyen == 3)
            {
                btnHoaDon.Visible = false;
                btnSanPham.Visible = false;
                btnNhanVien.Visible = false;
                btnOrder.Visible = false;
                btnNhapNL.Visible = false;
                btnBaoCao.Visible = false;
            }
        }

        #region Hiển thị chức năng
        private Form activeForm = null;
        private void openForm(Form formOpen)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = formOpen;
            formOpen.TopLevel = false;
            formOpen.Dock = DockStyle.Fill;
            panel_control.Controls.Add(formOpen);
            panel_control.Tag = formOpen;
            formOpen.BringToFront();
            formOpen.Show();
        }
        #endregion

        #region Cài đặt ẩn hiện submenu
        private void hideSubMenu()
        {
            panel_submenu_HD.Visible = false;
            panel_submenu_NS.Visible = false;
            panel_submenu_SP.Visible = false;
            panel_submenu_Kho.Visible = false;
        }
        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion

        #region Hiển thị menu con
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_submenu_SP);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_submenu_Kho);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_submenu_NS);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_submenu_HD);
        }
        #endregion

        #region Hiển thị form chức năng
        private void ptbTrangChu_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            hideSubMenu();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (sid == null)
                using (KiemTraNVOrder ktra = new ())
                {
                    if (ktra.ShowDialog() == DialogResult.OK)
                    {
                        sid = ktra.storeid;
                        pid = ktra.pos;
                        openForm(new Order(ktra.storeid, ktra.pos, tenNV));
                        hideSubMenu();
                    }
                }
            else
            {
                openForm(new Order(sid, pid, tenNV));
                hideSubMenu();
            }
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyMonAn());
            hideSubMenu();
        }

        private void btnQLLoaiSanPham_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyLoaiMonAn());
            hideSubMenu();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyNhanVien());
            hideSubMenu();
        }

        private void btnQLChucVu_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyChucVu());
            hideSubMenu();
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            //openForm(new QuanLyTaiKhoan());
            hideSubMenu();
        }

        private void btnHDKho_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyHoaDonKho(this.tenNV));
            hideSubMenu();
        }

        private void btnHDBanHang_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyHoaDon(this.Quyen, this.tenNV));
            hideSubMenu();
        }


        private void btnNhapNL_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new NhapNguyenLieu());
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyKho(this.tenNV));
            hideSubMenu();

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyBaoCao());
            hideSubMenu();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new QuanLyDonDatHang(this.tenNV));
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                DangNhap dn = new ();
                dn.ShowDialog();
                this.Close();
            }
        }
        #endregion
        
    }
}
