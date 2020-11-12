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
    public class PhieuThuTienBUS
    {
        #region Singleton
        private static PhieuThuTienBUS ins;
        public static PhieuThuTienBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new PhieuThuTienBUS();
                return PhieuThuTienBUS.ins;
            }
            private set
            {
                PhieuThuTienBUS.ins = value;
            }
        }
        private PhieuThuTienBUS()
        {

        }
        #endregion
        public List<PhieuThuTien> GetDanhSachPhieuThuTien()
        {
            DataTable result = PhieuThuTienDAO.Ins.GetDanhSachPhieuThuTien();
            List<PhieuThuTien> list = new List<PhieuThuTien>();
            foreach (DataRow item in result.Rows)
            {
                PhieuThuTien phieuThuTien = new PhieuThuTien();
                phieuThuTien.MaDocGia = item["MaDocGia"].ToString().Trim();
                phieuThuTien.MaNV = item["MaNV"].ToString().Trim();
                phieuThuTien.MaPTT = item["MaPTT"].ToString().Trim();
                phieuThuTien.Sotienno = float.Parse(item["Sotienno"].ToString());
                phieuThuTien.Sotienthu = float.Parse(item["Sotienthu"].ToString());

                list.Add(phieuThuTien);
            }

            return list;
        }
        public bool InsertPhieuThuTien(string MaPTT, float Sotienno, float Sotienthu, string MaDocGia, string MaNV)
        {
            return PhieuThuTienDAO.Ins.InsertPhieuThuTien( MaPTT,  Sotienno,  Sotienthu,  MaDocGia,  MaNV);
        }
        public bool UpdatePhieuThuTien(string MaPTT, float Sotienno, float Sotienthu, string MaDocGia, string MaNV)
        {
            return PhieuThuTienDAO.Ins.UpdatePhieuThuTien( MaPTT,  Sotienno,  Sotienthu,  MaDocGia,  MaNV);

        }
        public bool DeletePhieuThuTien(string MaPTT)
        {
            return PhieuThuTienDAO.Ins.DeletePhieuThuTien(MaPTT);
        }
    }
}
