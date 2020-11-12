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
    public class SachBUS
    {
        #region Singleton
        private static SachBUS ins;
        public static SachBUS Ins
        {
            get
            {
                if (ins == null)
                    ins = new SachBUS();
                return SachBUS.ins;
            }
            private set
            {
                SachBUS.ins = value;
            }
        }
        private SachBUS()
        {

        }
        #endregion
        public List<Sach> GetDanhSachSach()
        {
            DataTable result = SachDAO.Ins.GetDanhSachSach();
            List<Sach> list = new List<Sach>();
            foreach (DataRow item in result.Rows)
            {
                Sach sach = new Sach();
                sach.MaSach = item["MaSach"].ToString().Trim();
                sach.TenSach = item["TenSach"].ToString().Trim();
                sach.TacGia = item["TacGia"].ToString().Trim();

                sach.Namxuatban = (DateTime)item["Namxuatban"];
                sach.Nhaxuatban = item["Nhaxuatban"].ToString();
                sach.Trigia = float.Parse(item["Trigia"].ToString());

                sach.Ngaynhap = (DateTime)item["Ngaynhap"];
               

                list.Add(sach);
            }

            return list;
        }

        public bool InsertSach(string MaSach, string TenSach, string TacGia, string Namxuatban, string Nhaxuatban, float Trigia, string Ngaynhap)
        {
            return SachDAO.Ins.InsertSach( MaSach,  TenSach,  TacGia,  Namxuatban,  Nhaxuatban,  Trigia,  Ngaynhap);
        }
        public bool UpdateSach(string MaSach, string TenSach, string TacGia, string Namxuatban, string Nhaxuatban, float Trigia, string Ngaynhap)
        {
            return SachDAO.Ins.UpdateSach(MaSach, TenSach, TacGia, Namxuatban, Nhaxuatban, Trigia, Ngaynhap);

        }
        public bool DeleteSach(string MaSach)
        {
            return SachDAO.Ins.DeleteSach(MaSach);
        }
    }
}
