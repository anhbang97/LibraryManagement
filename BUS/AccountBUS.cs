using Library_management.DAO;
using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.BUS
{
    public class AccountBUS
    {
        #region Singleton
        private static AccountBUS ins;
        public static AccountBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new AccountBUS();
                return AccountBUS.ins;
            }
            private set
            {
                AccountBUS.ins = value;
            }
        }
        private AccountBUS()
        {

        }
        #endregion

        public bool Login(string userName, string passWord)
        {
            return AccountDAO.Ins.Login(userName,passWord);
        }

        public NhanVien GetNhanVienByAccount(string userName, string passWord)
        {
            return AccountDAO.Ins.GetNhanVienByAccount(userName, passWord);
        }
    }
}
