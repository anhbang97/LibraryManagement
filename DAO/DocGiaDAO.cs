using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class DocGiaDAO
    {
        #region Singleton
        private static DocGiaDAO ins;
        public static DocGiaDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new DocGiaDAO();
                return DocGiaDAO.ins;
            }
            private set
            {
                DocGiaDAO.ins = value;
            }
        }
        private DocGiaDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachDG()
        {
            string sql = "SELECT * FROM dbo.DOCGIA";
            return DataProvider.Ins.ExecuteQuery(sql);
        }

        public bool InsertDocGia(string MaDocGia, string HoTenDocGia,string Diachi,string NgaySinh,string Email,string Ngaylapthe,string Ngayhethan,float Tienno)
        {
            string sql = string.Format("INSERT dbo.DOCGIA(MaDocGia,HoTenDocGia,Diachi,NgaySinh,Email,Ngaylapthe,Ngayhethan,Tienno)VALUES('{0}',N'{1}','{2}',{3},N'{4}',{5},{6},{7})", MaDocGia, HoTenDocGia, Diachi, NgaySinh, Email, Ngaylapthe, Ngayhethan, Tienno);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool UpdateDocGia(string MaDocGia, string HoTenDocGia, string Diachi, string NgaySinh, string Email, string Ngaylapthe, string Ngayhethan, float Tienno)
        {
            string sql = string.Format("UPDATE dbo.DOCGIA SET HoTenDocGia = N'{0}',Diachi = N'{1}',NgaySinh = {2},Email = N'{3}',Ngaylapthe = {4},Ngayhethan = {5},Tienno = {6}  WHERE MaDocGia = '{7}'", HoTenDocGia, Diachi, NgaySinh, Email, Ngaylapthe, Ngayhethan, Tienno, MaDocGia);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool DeleteDocGia(string MaDocGia)
        {
            string sql = "DELETE dbo.DOCGIA WHERE MaDocGia = '" + MaDocGia + "'";

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
