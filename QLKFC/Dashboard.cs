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
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        #region Hiển thị form chức năng
        private void btnOrder_Click(object sender, EventArgs e)
        {
            openForm(new Order());
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
            //openForm(new NhanVien());
            hideSubMenu();
        }

        private void btnQLChucVu_Click(object sender, EventArgs e)
        {
            //openForm(new ChucVu());
            hideSubMenu();
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            //openForm(new TaiKhoan());
            hideSubMenu();
        }

        private void btnHDKho_Click(object sender, EventArgs e)
        {
            //openForm(new HoaDonKho());
            hideSubMenu();
        }

        private void btnHDBanHang_Click(object sender, EventArgs e)
        {
            //openForm(new HoaDon());
            hideSubMenu();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            //openForm(new Kho());
        }
        #endregion

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
