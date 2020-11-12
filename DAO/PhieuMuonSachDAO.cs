using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management.DAO
{
    public class PhieuMuonSachDAO
    {
        #region Singleton
        private static PhieuMuonSachDAO ins;
        public static PhieuMuonSachDAO Ins
        {
            get
            {
                if (ins == null)
                    ins = new PhieuMuonSachDAO();
                return PhieuMuonSachDAO.ins;
            }
            private set
            {
                PhieuMuonSachDAO.ins = value;
            }
        }
        private PhieuMuonSachDAO()
        {

        }
        #endregion
        public DataTable GetDanhSachPhieuMuonSach()
        {
            string sql = "SELECT * FROM dbo.view_PhieuMuon";
            return DataProvider.Ins.ExecuteQuery(sql);
        }
        /// <summary>
        // CREATE PROC USP_ThemPhieuMuon 
        // @MaSach CHAR(20),@MaPMS CHAR(20),@MaDocGia CHAR(20),@Ngaymuon DATE
        // AS
        // BEGIN
        //    INSERT INTO dbo.PHIEUMUONSACH(MaPMS, Ngaymuon, MaDocGia)
        //    VALUES(@MaPMS, @Ngaymuon, @MaDocGia)

        //    INSERT INTO dbo.CHITIETPHIEUMUON(MaSach, MaPMS, NgayTra)
        //    VALUES(@MaSach, @MaPMS, NULL)
        // END
        /// </summary>
        /// <param name="MaSach"></param>
        /// <param name="MaPMS"></param>
        /// <param name="MaDocGia"></param>
        /// <param name="Ngaymuon"></param>
        /// <returns></returns>
        public bool InsertPhieuMuonSach(string MaSach,string MaPMS, string MaDocGia, string Ngaymuon)
        {
            string sql = string.Format("EXEC dbo.USP_ThemPhieuMuon @MaSach = '{0}', @MaPMS = '{1}',@MaDocGia = '{2}',@Ngaymuon = '{3}'",MaSach,MaPMS,MaDocGia,Ngaymuon);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        /// <summary>
        //  CREATE PROC USP_SuaPhieuMuon
        //  @MaSach CHAR(20),@MaPMS CHAR(20),@MaDocGia CHAR(20),@Ngaymuon DATE
        //  AS
        //  BEGIN
        //      UPDATE dbo.PHIEUMUONSACH SET Ngaymuon = @Ngaymuon, MaDocGia = @MaDocGia WHERE MaPMS = @MaPMS
        //      UPDATE dbo.CHITIETPHIEUMUON SET MaSach = @MaSach WHERE MaPMS = @MaPMS
        //  END
        /// </summary>
        /// <param name="MaSach"></param>
        /// <param name="MaPMS"></param>
        /// <param name="MaDocGia"></param>
        /// <param name="Ngaymuon"></param>
        /// <returns></returns>
        public bool UpdatePhieuMuonSach(string MaSach, string MaPMS, string MaDocGia, string Ngaymuon)
        {
            string sql = string.Format("EXEC dbo.USP_SuaPhieuMuon @MaSach = '{0}', @MaPMS = '{1}',@MaDocGia = '{2}',@Ngaymuon = '{3}'", MaSach, MaPMS, MaDocGia, Ngaymuon);

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
        /// <summary>
        // CREATE PROC USP_XoaPhieuMuon
        //  @MaPMS CHAR(20)
        //  AS
        //  BEGIN
        //      DELETE dbo.CHITIETPHIEUMUON WHERE MaPMS = @MaPMS
        //     DELETE dbo.PHIEUMUONSACH WHERE MaPMS = @MaPMS
        //  END
        /// </summary>
        /// <param name="MaPMS"></param>
        /// <returns></returns>
        public bool DeletePhieuMuonSach(string MaPMS)
        {
            string sql = "EXEC dbo.USP_XoaPhieuMuon @MaPMS = '" + MaPMS + "'";

            int result = DataProvider.Ins.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
