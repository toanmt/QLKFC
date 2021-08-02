using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class HoaDon
    {
        public int MaHd { get; set; }
        public string StoreId { get; set; }
        public string Pos { get; set; }
        public string NhanVien { get; set; }
        public DateTime? NgayThang { get; set; }
    }
}
