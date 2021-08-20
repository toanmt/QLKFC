using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models

{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int MaCv { get; set; }
        public string TenCv { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
