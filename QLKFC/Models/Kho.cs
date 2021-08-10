using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class Kho
    {
        public int MaNl { get; set; }
        public int? SoLuong { get; set; }

        public virtual NguyenLieu MaNlNavigation { get; set; }
    }
}
