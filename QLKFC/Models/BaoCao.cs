using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models2
{
    public partial class BaoCao
    {
        public int MaBc { get; set; }
        public string TenNv { get; set; }
        public DateTime? NgayLap { get; set; }
        public string Loai { get; set; }
        public string StoreId { get; set; }
        public string Mota { get; set; }
    }
}
