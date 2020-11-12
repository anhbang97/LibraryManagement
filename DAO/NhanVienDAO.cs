using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    // Nam trong project DAO.
    public class NhanVienDAO
    {
        #region Singleton
        private static NhanVienDAO ins;
        public static NhanVienDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new NhanVienDAO();
                return NhanVienDAO.ins;
            }
            private set
            {
                NhanVienDAO.ins = value;
            }
        }
        private NhanVienDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachNV()
        {
            string sql = "SELECT * FROM dbo.NHANVIEN";
            return DataProvider.Ins.ExecuteQuery(sql);
        }

        public bool InsertNhanVien(string MaNV,string HotenNV,string Ngaysinh,string Diachi, string Dienthoai, string MaBC)
        {
            string sql = string.Format("INSERT INTO dbo.NHANVIEN (MaNV,HoTenNV,Ngaysinh,Diachi,Dienthoai,MaBC) VALUES('{0}',N'{1}',{2},N'{3}','{4}','{5}')",  MaNV,  HotenNV,  Ngaysinh,  Diachi,  Dienthoai,  MaBC);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool UpdateNhanVien(string MaNV, string HotenNV, string Ngaysinh, string Diachi, string Dienthoai, string MaBC)
        {
            string sql = string.Format("UPDATE dbo.NHANVIEN SET HoTenNV = N'{0}',Ngaysinh = {1},Diachi = N'{2}',Dienthoai = N'{3}',MaBC = '{4}' WHERE MaNV = '{5}'", HotenNV, Ngaysinh, Diachi, Dienthoai, MaBC, MaNV);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool DeleteNhanVien(string MaNV)
        {
            string sql = "DELETE dbo.NHANVIEN WHERE MaNV = '" + MaNV +"'";

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
