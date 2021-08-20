using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models

{
    public partial class CthoaDonKho
    {
        public int MaHdk { get; set; }
        public int MaNl { get; set; }
        public int? SoLuong { get; set; }
        public int? SoLuongDaNhap { get; set; }

        public virtual HoaDonKho MaHdkNavigation { get; set; }
        public virtual NguyenLieu MaNlNavigation { get; set; }
    }
}
