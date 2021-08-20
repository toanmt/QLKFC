using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKFC.Models;

namespace QLKFC
{
    public partial class KiemTraNVOrder : Form
    {
        public KiemTraNVOrder()
        {
            InitializeComponent();
            cmbPOS.Focus();
        }
        QLBHKFCContext db = new QLBHKFCContext();
        public string storeid { get; set; }
        public string pos { get; set; }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVao_Click(object sender, EventArgs e)
        {
            pos = cmbPOS.Text;
            storeid = txtStoreID.Text;
        }
    }
}
