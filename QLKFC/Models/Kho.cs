using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class Kho
    {
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
