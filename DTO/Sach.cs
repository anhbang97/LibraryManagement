using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DTO
{
    public class Sach
    {
		public string MaSach { get; set; }
		public string TenSach { get; set; }
		public string TacGia { get; set; }
		public DateTime Namxuatban { get; set; }
		public string Nhaxuatban { get; set; }
		public float Trigia { get; set; }
		public DateTime? Ngaynhap { get; set; }
	}
}
