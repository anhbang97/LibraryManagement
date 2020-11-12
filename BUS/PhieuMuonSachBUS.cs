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
    public class PhieuMuonSachBUS
    {
        #region Singleton
        private static PhieuMuonSachBUS ins;
        public static PhieuMuonSachBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new PhieuMuonSachBUS();
                return PhieuMuonSachBUS.ins;
            }
            private set
            {
                PhieuMuonSachBUS.ins = value;
            }
        }
        private PhieuMuonSachBUS()
        {

        }
        #endregion
        public List<PhieuMuonSach> GetDanhSachPhieuMuonSach()
        {
            DataTable result = PhieuMuonSachDAO.Ins.GetDanhSachPhieuMuonSach();
            List<PhieuMuonSach> list = new List<PhieuMuonSach>();
            foreach (DataRow item in result.Rows)
            {
                PhieuMuonSach phieuMuonSach = new PhieuMuonSach();
                phieuMuonSach.MaDocGia = item["MaDocGia"].ToString().Trim();
                phieuMuonSach.MaPMS = item["MaPMS"].ToString().Trim();
                phieuMuonSach.MaSach = item["MaSach"].ToString().Trim();
                phieuMuonSach.Ngaymuon = (DateTime)item["Ngaymuon"];

                list.Add(phieuMuonSach);
            }

            return list;
        }
        public bool InsertPhieuMuonSach(string MaSach, string MaPMS, string MaDocGia, string Ngaymuon)
        {
            return PhieuMuonSachDAO.Ins.InsertPhieuMuonSach( MaSach,  MaPMS,  MaDocGia,  Ngaymuon);
        }
        public bool UpdatePhieuMuonSach(string MaSach, string MaPMS, string MaDocGia, string Ngaymuon)
        {
            return PhieuMuonSachDAO.Ins.UpdatePhieuMuonSach(MaSach, MaPMS, MaDocGia, Ngaymuon);

        }
        public bool DeletePhieuMuonSach(string MaPMS)
        {
            return PhieuMuonSachDAO.Ins.DeletePhieuMuonSach(MaPMS);
        }
    }
}
