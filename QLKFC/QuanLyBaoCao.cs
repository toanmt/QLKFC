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
    public partial class QuanLyBaoCao : Form
    {
        QLBHKFCContext db = new QLBHKFCContext();
        int index = -1;
        public QuanLyBaoCao()
        {
            InitializeComponent();
            dgvBaoCao.EnableHeadersVisualStyles = false;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
           
            load();
        }
        public void load()
        {
            dgvBaoCao.Rows.Clear();
            var query = db.BaoCaos.Select(x => x);
            foreach (var item in query.ToList())
            {
                String[] bc = { item.MaBc.ToString(), item.TenNv.ToString(), item.NgayLap.ToString(), item.Loai.ToString(), "044", item.Mota.ToString() };
                dgvBaoCao.Rows.Add(bc);
            }
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            var query = db.BaoCaos.Select(x => x);
            if (cbLocDuLieu.Text == "Nhập hàng")
                query= db.BaoCaos.Where(x => x.Loai.Equals("Nhập hàng"));
            else if (cbLocDuLieu.Text == "Xuất hàng")
                query = db.BaoCaos.Where(x => x.Loai.Equals("Xuất hàng"));
            else if (cbLocDuLieu.Text == "Hủy hàng")
                query = db.BaoCaos.Where(x => x.Loai.Equals("Hủy hàng"));

            dgvBaoCao.Rows.Clear();
            foreach (var item in query.ToList())
            {
                String[] bc = { item.MaBc.ToString(), item.TenNv.ToString(), item.NgayLap.ToString(), item.Loai.ToString(), "044", item.Mota.ToString() };
                dgvBaoCao.Rows.Add(bc);
            }
        }

        private void btnHienThiToanBo_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (index == -1)
                MessageBox.Show("Chưa chọn báo cáo");
            
            else
                printPRDialog.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int vtri = 25;
            Bitmap bmp = Properties.Resources.kfc__1_;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage,25,25, int.Parse(newImage.Width.ToString()), int.Parse(newImage.Height.ToString()));
            vtri += 200;
            StringFormat formatCenter = new StringFormat(StringFormatFlags.NoClip);
            formatCenter.Alignment = StringAlignment.Center;
            e.Graphics.DrawString("Cửa hàng KFC", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(25, vtri));
            vtri += 200;
            e.Graphics.DrawString("Test", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(25, vtri));
            
        }

        private void dgvBaoCao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}
