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
        //Load dữ liệu
        public void load()
        {
            if(dgvBaoCao.Rows.Count >0)
            dgvBaoCao.Rows.Clear();
            var query = db.BaoCaos.Select(x => x);
            foreach (var item in query.ToList())
            {
                String[] bc = { item.MaBc.ToString(), item.TenNv.ToString(), item.NgayLap.ToString(), item.Loai.ToString(), "044", item.Mota.ToString() };
                dgvBaoCao.Rows.Add(bc);
            }
        }
        
        //Lọc dữ liệu
        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            var query = db.BaoCaos.Select(x => x);
            if (cbLocDuLieu.Text == "Nhập hàng")
                query= db.BaoCaos.Where(x => x.Loai.Equals("Nhập hàng"));
            else if (cbLocDuLieu.Text == "Xuất hàng")
                query = db.BaoCaos.Where(x => x.Loai.Equals("Xuất hàng"));
            else if (cbLocDuLieu.Text == "Hủy hàng")
                query = db.BaoCaos.Where(x => x.Loai.Equals("Hủy hàng"));
            else if(cbLocDuLieu.Text == "Nhập hàng-Thiếu")
                query = db.BaoCaos.Where(x => x.Loai.Equals("Nhập hàng-Thiếu"));
            dgvBaoCao.Rows.Clear();
            foreach (var item in query.ToList())
            {
                String[] bc = { item.MaBc.ToString(), item.TenNv.ToString(), item.NgayLap.ToString(), item.Loai.ToString(), "044", item.Mota.ToString() };
                dgvBaoCao.Rows.Add(bc);
            }
        }

        //Hiển thị toàn bộ báo cáo
        private void btnHienThiToanBo_Click(object sender, EventArgs e)
        {
            load();
        }

        #region Tương tác vs bảng + xuất báo cáo
        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (index == -1)
                MessageBox.Show("Chưa chọn báo cáo");

            else
                printPRDialog.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //Lấy thông tin báo cáo
            var queryBc = db.BaoCaos.Where(x => x.MaBc == int.Parse(dgvBaoCao.Rows[index].Cells[0].Value.ToString())).SingleOrDefault();
            //Lấy logo
            Bitmap bmp = Properties.Resources.kfc__1_;
            Image newImage = bmp;
            //Vẽ logo
            e.Graphics.DrawImage(newImage, 25, 25, int.Parse(newImage.Width.ToString()), int.Parse(newImage.Height.ToString()));

            e.Graphics.DrawString("CN Cty LD TNHH KFC VietNam", new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(220, 25));

            e.Graphics.DrawString("292 Bà Triệu , Hai Bà Trưng , Hà Nội", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(250, 85));

            e.Graphics.DrawString("Báo cáo " + queryBc.Loai, new Font("Times New Roman", 50, FontStyle.Regular), Brushes.Black, new Point(180, 245));

            e.Graphics.DrawString("Người lập :" + queryBc.TenNv, new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(25, 345));

            e.Graphics.DrawString(queryBc.NgayLap.ToString(), new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(425, 353));

            if (queryBc.Loai == "Nhập hàng")
                e.Graphics.DrawString("Nhập hàng thành công : " + queryBc.Mota, new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(35, 400));
            else if (queryBc.Loai == "Nhập hàng")
                e.Graphics.DrawString("Lý do : Trung tâm giao thiếu hàng \n " + queryBc.Mota, new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(35, 400));
            else if (queryBc.Loai == "Hủy hàng")
                e.Graphics.DrawString("Lý do : " + queryBc.Mota, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(35, 400));
            else
                e.Graphics.DrawString(queryBc.Mota, new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(35, 400));

            e.Graphics.DrawString("Nhân viên", new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(35, 825));
            e.Graphics.DrawString("(Ký rõ họ tên)", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(35, 870));


            e.Graphics.DrawString("Người lập", new Font("Times New Roman", 30, FontStyle.Regular), Brushes.Black, new Point(550, 825));
            e.Graphics.DrawString("(Ký rõ họ tên)", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(550, 870));






        }

        private void dgvBaoCao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        } 
        #endregion

        //Tìm kiếm hóa đơn theo mã báo cáo > mô tả.
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
           if (txtTimKiem.Text == "")
                load();
            else
            {
                if (dgvBaoCao.Rows.Count > 0)
                    dgvBaoCao.Rows.Clear();
                var query = db.BaoCaos.Where(x => x.MaBc.ToString().Contains(txtTimKiem.Text));
                if (query.ToList().Count == 0)
                    query = db.BaoCaos.Where(x => x.Mota.Contains(txtTimKiem.Text));
                foreach (var item in query.ToList())
                {
                    String[] bc = { item.MaBc.ToString(), item.TenNv.ToString(), item.NgayLap.ToString(), item.Loai.ToString(), "044", item.Mota.ToString() };
                    dgvBaoCao.Rows.Add(bc);
                }
            }
        }
    }
}
