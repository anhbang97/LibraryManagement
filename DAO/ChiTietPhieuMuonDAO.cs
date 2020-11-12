using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class ChiTietPhieuMuonDAO
    {
        #region Singleton
        private static ChiTietPhieuMuonDAO ins;
        public static ChiTietPhieuMuonDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new ChiTietPhieuMuonDAO();
                return ChiTietPhieuMuonDAO.ins;
            }
            private set
            {
                ChiTietPhieuMuonDAO.ins = value;
            }
        }
        private ChiTietPhieuMuonDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachChiTietPhieuMuon()
        {
            string sql = "SELECT * FROM dbo.CHITIETPHIEUMUON";
            return DataProvider.Ins.ExecuteQuery(sql);
        }
    }
}
