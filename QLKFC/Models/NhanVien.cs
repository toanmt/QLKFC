using System;
using System.Collections.Generic;

#nullable disable

namespace QLKFC.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string SoCmt { get; set; }
        public int? MaCv { get; set; }
        public int? Id { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime? NgayBatDau { get; set; }

        public virtual TaiKhoan IdNavigation { get; set; }
        public virtual ChucVu MaCvNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
