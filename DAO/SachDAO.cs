using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class SachDAO
    {
        #region Singleton
        private static SachDAO ins;
        public static SachDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new SachDAO();
                return SachDAO.ins;
            }
            private set
            {
                SachDAO.ins = value;
            }
        }
        private SachDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachSach()
        {
            string sql = "SELECT * FROM dbo.SACH";
            return DataProvider.Ins.ExecuteQuery(sql);
        }

        public bool InsertSach(string MaSach,string TenSach,string TacGia,string Namxuatban, string Nhaxuatban,float Trigia,string Ngaynhap)
        {
            string sql = string.Format("INSERT INTO dbo.SACH(MaSach,TenSach,TacGia,Namxuatban,Nhaxuatban,Trigia,Ngaynhap)VALUES('{0}',N'{1}',N'{2}',{3},N'{4}',{5},{6})", MaSach, TenSach, TacGia, Namxuatban, Nhaxuatban, Trigia, Ngaynhap);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool UpdateSach(string MaSach, string TenSach, string TacGia, string Namxuatban, string Nhaxuatban, float Trigia, string Ngaynhap)
        {
            string sql = string.Format("UPDATE dbo.SACH SET TenSach = N'{0}',TacGia = N'{1}',Namxuatban = {2},Nhaxuatban = N'{3}',Trigia = {4},Ngaynhap = {5}  WHERE MaSach = '{6}'", TenSach, TacGia, Namxuatban, Nhaxuatban, Trigia, Ngaynhap, MaSach);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool DeleteSach(string MaSach)
        {
            string sql = "DELETE dbo.SACH WHERE MaSach = '" + MaSach + "'";

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
