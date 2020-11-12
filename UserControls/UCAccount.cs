using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_management.DTO;
using Library_management.BUS;

namespace Library_management.UserControls
{
    public partial class UCAccount : UserControl
    {
        List<NhanVien> listNhanVien;
        public UCAccount()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
        }
        private void LoadDanhSachNhanVien()
        {
            listNhanVien = new List<NhanVien>();
            listNhanVien = NhanVienBUS.Ins.GetDanhSachNV();
            cbxMaNV.DataSource = listNhanVien;
            cbxMaNV.DisplayMember = "MaNV";
        }
      
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
