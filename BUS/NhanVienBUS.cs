using Library_management.DAO;
using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.BUS
{
    // Nam trong project BUS.
    public class NhanVienBUS
    {
        #region Singleton
        private static NhanVienBUS ins;
        public static NhanVienBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new NhanVienBUS();
                return NhanVienBUS.ins;
            }
            private set
            {
                NhanVienBUS.ins = value;
            }
        }
        private NhanVienBUS()
        {

        }
        #endregion
        public List<NhanVien> GetDanhSachNV()
        {
            DataTable result = NhanVienDAO.Ins.GetDanhSachNV();
            List<NhanVien> list = new List<NhanVien>();
            foreach (DataRow item in result.Rows)
            {
                NhanVien nhanVien = new NhanVien() 
                { 
                    MaNV = item["MaNV"].ToString().Trim(),
                    Diachi = item["Diachi"].ToString().Trim(),
                    Dienthoai = item["Dienthoai"].ToString().Trim(),
                    HoTenNV = item["HoTenNV"].ToString().Trim(),
                    MaBC = item["MaBC"].ToString().Trim(),
                    Ngaysinh = (DateTime)item["Ngaysinh"]

                };
                list.Add(nhanVien);
            }

            return list;  
        }

        public bool InsertNhanVien(string MaNV, string HotenNV, string Ngaysinh, string Diachi, string Dienthoai, string MaBC)
        {
            return NhanVienDAO.Ins.InsertNhanVien( MaNV,  HotenNV,  Ngaysinh,  Diachi,  Dienthoai,  MaBC);
        }
        public bool UpdateNhanVien(string MaNV, string HotenNV, string Ngaysinh, string Diachi, string Dienthoai, string MaBC)
        {
            return NhanVienDAO.Ins.UpdateNhanVien( MaNV,  HotenNV,  Ngaysinh,  Diachi,  Dienthoai,  MaBC);

        }
        public bool DeleteNhanVien(string MaNV)
        {
            return NhanVienDAO.Ins.DeleteNhanVien(MaNV);
        }
    }
}
