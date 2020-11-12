using Library_management.DAO;
using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.BUS
{
    public class BangCapBUS
    {
        #region Singleton
        private static BangCapBUS ins;
        public static BangCapBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new BangCapBUS();
                return BangCapBUS.ins;
            }
            private set
            {
                BangCapBUS.ins = value;
            }
        }
        private BangCapBUS()
        {

        }
        #endregion
        public List<BangCap> GetDanhSachBC()
        {
            DataTable result = BangCapDAO.Ins.GetDanhSachBC();
            List<BangCap> list = new List<BangCap>();
            foreach (DataRow item in result.Rows)
            {
                BangCap bangCap = new BangCap();
                bangCap.MaBC = item["MaBC"].ToString().Trim();
                bangCap.TenBC = item["TenBC"].ToString().Trim();
               
                list.Add(bangCap);
            }

            return list;
        }
    }
}
