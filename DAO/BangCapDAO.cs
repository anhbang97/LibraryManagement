using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class BangCapDAO
    {
        #region Singleton
        private static BangCapDAO ins;
        public static BangCapDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new BangCapDAO();
                return BangCapDAO.ins;
            }
            private set
            {
                BangCapDAO.ins = value;
            }
        }
        private BangCapDAO()
        {

        }
        #endregion

        public DataTable GetDanhSachBC()
        {
            string sql = "SELECT * FROM dbo.BANGCAP";
            return DataProvider.Ins.ExecuteQuery(sql);
        }
    }
}
