using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DTO
{
    public class DocGia
    {
		public string MaDocGia { get; set; }
		public string HoTenDocGia { get; set; }
		public DateTime NgaySinh { get; set; }


		// ? đặt sau datetime là cho phép null
		public DateTime? Ngaylapthe { get; set; }
		public DateTime? Ngayhethan { get; set; }
		public string Diachi { get; set; }
		public string Email { get; set; }
		public float TienNo { get; set; }

	

	}
}
