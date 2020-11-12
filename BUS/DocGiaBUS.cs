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
    public class DocGiaBUS
    {
        #region Singleton
        private static DocGiaBUS ins;
        public static DocGiaBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new DocGiaBUS();
                return DocGiaBUS.ins;
            }
            private set
            {
                DocGiaBUS.ins = value;
            }
        }
        private DocGiaBUS()
        {

        }
        #endregion
        public List<DocGia> GetDanhSachDG()
        {
            DataTable result = DocGiaDAO.Ins.GetDanhSachDG();
            List<DocGia> list = new List<DocGia>();
            foreach (DataRow item in result.Rows)
            {
                DocGia docgia = new DocGia();
                docgia.MaDocGia = item["MaDocGia"].ToString().Trim();
                docgia.HoTenDocGia = item["HoTenDocGia"].ToString().Trim();
                docgia.Diachi = item["Diachi"].ToString().Trim();
                docgia.NgaySinh = (DateTime)item["NgaySinh"];
                docgia.Email = item["Email"].ToString().Trim();
                docgia.Ngaylapthe = (DateTime)item["Ngaylapthe"];
                docgia.Ngayhethan = (DateTime)item["Ngayhethan"];
                docgia.TienNo = float.Parse(item["TienNo"].ToString());

                list.Add(docgia);
            }

            return list;
        }

        public bool InsertDocGia(string MaDocGia, string HoTenDocGia, string Diachi, string NgaySinh, string Email, string Ngaylapthe, string Ngayhethan, float Tienno)
        {
            return DocGiaDAO.Ins.InsertDocGia(MaDocGia, HoTenDocGia, Diachi, NgaySinh, Email, Ngaylapthe, Ngayhethan, Tienno);
        }
        public bool UpdateDocGia(string MaDocGia, string HoTenDocGia, string Diachi, string NgaySinh, string Email, string Ngaylapthe, string Ngayhethan, float Tienno)
        {
            return DocGiaDAO.Ins.UpdateDocGia(MaDocGia, HoTenDocGia, Diachi, NgaySinh, Email, Ngaylapthe, Ngayhethan, Tienno);

        }
        public bool DeleteDocGia(string MaDocGia)
        {
            return DocGiaDAO.Ins.DeleteDocGia(MaDocGia);
        }
    }
}
