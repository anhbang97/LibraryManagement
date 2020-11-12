using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    class AccountDAO
    {
        #region Singleton
        private static AccountDAO ins;
        public static AccountDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new AccountDAO();
                return AccountDAO.ins;
            }
            private set
            {
                AccountDAO.ins = value;
            }
        }
        private AccountDAO()
        {

        }
        #endregion

        public bool Login(string userName, string passWord)
        {
            string query = "EXECUTE dbo.USP_Login @Username , @Password";

            DataTable result = DataProvider.Ins.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }
        public NhanVien GetNhanVienByAccount(string userName, string passWord)
        {
            string query = string.Format("SELECT * FROM dbo.ACCOUNT JOIN dbo.NHANVIEN ON NHANVIEN.MaNV = ACCOUNT.IdNV WHERE Username = '{0}' AND Passwork = '{1}'",userName,passWord);
            
            DataTable result = DataProvider.Ins.ExecuteQuery(query);

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
                return nhanVien;
            }
            return null;
        }
    }
}
