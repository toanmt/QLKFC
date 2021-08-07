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
        public Dashboard()
        {
            InitializeComponent();
            hideSubMenu();
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

        private void ptbTrangChu_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        #region Hiển thị form chức năng
        private void btnOrder_Click(object sender, EventArgs e)
        {
            using (KiemTraNVOrder ktra = new KiemTraNVOrder())
            {
                if (ktra.ShowDialog() == DialogResult.OK)
                {
                    openForm(new Order(ktra.storeid, ktra.pos, ktra.tennv));
                    hideSubMenu();
                }
            }
        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyThucDon());
            hideSubMenu();
        }

        private void btnQLLoaiSanPham_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyLoaiSanPham());
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
            openForm(new QuanLyTaiKhoan());
            hideSubMenu();
        }

        private void btnHDKho_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyHoaDonKho());
            hideSubMenu();
        }

        private void btnHDBanHang_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyHoaDon());
            hideSubMenu();
        }

        
        #endregion


        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            this.Close();
        }

        private void btnNhapNL_Click(object sender, EventArgs e)
        {
            openForm(new NhapNguyenLieu());
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            openForm(new QuanLyKho());
            hideSubMenu();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new QuanLyNhapXuat());
        }
    }
}
