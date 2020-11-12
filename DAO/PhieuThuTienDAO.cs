using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class PhieuThuTienDAO
    {
        #region Singleton
        private static PhieuThuTienDAO ins;
        public static PhieuThuTienDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new PhieuThuTienDAO();
                return PhieuThuTienDAO.ins;
            }
            private set
            {
                PhieuThuTienDAO.ins = value;
            }
        }
        private PhieuThuTienDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachPhieuThuTien()
        {
            string sql = "SELECT * FROM dbo.PHIEUTHUTIEN";
            return DataProvider.Ins.ExecuteQuery(sql);
        }

        public bool InsertPhieuThuTien(string MaPTT,float Sotienno,float Sotienthu,string MaDocGia,string MaNV)
        {
            string sql = string.Format("INSERT dbo.PHIEUTHUTIEN(MaPTT,Sotienno,Sotienthu,MaDocGia,MaNV)VALUES('{0}',{1},{2},'{3}','{4}')", MaPTT, Sotienno, Sotienthu, MaDocGia, MaNV);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool UpdatePhieuThuTien(string MaPTT, float Sotienno, float Sotienthu, string MaDocGia, string MaNV)
        {
            string sql = string.Format("UPDATE dbo.PHIEUTHUTIEN SET Sotienno = {0} ,Sotienthu = {1}, MaDocGia ='{2}' , MaNV = '{3}' WHERE MaPTT = '{4}'", Sotienno, Sotienthu, MaDocGia, MaNV,MaPTT);
            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool DeletePhieuThuTien(string MaPTT)
        {
            string sql = "DELETE dbo.PHIEUTHUTIEN WHERE MaPTT = '" + MaPTT + "'";
            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
