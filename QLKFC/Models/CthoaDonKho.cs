using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class CthoaDonKho
    {
        public int? MaHdk { get; set; }
        public int? MaSp { get; set; }
        public string TinhTrang { get; set; }

        public virtual HoaDonKho MaHdkNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
