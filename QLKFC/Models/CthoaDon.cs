using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models2
{
    public partial class CthoaDon
    {
        public int? MaHd { get; set; }
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
