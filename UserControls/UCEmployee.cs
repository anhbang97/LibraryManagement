using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_management.BUS;
using Library_management.DTO;
// Nam trong lớp giao diện với các chức năng xử  Button hay DataGridView.
namespace Library_management.UserControls
{
    public partial class UCEmployee : UserControl
    {
        BindingSource nhanVienBinding = new BindingSource();
        List<NhanVien> listNhanVien;
        List<BangCap> listBangCap;
        string title = "nhân viên";
        public UCEmployee()
        {
            InitializeComponent();

            KhoiTao();
            BindingData();
        }
        private void KhoiTao()
        {
            LoadDanhSachNhanVien();
            dtgvEmployee.DataSource = nhanVienBinding;

            LoadDanhSachBangCap();


           
        }
        /// <summary>
        /// đổ data bằng cấp từ sql vào combobox 
        /// </summary>
        private void LoadDanhSachBangCap()
        {
            listBangCap = new List<BangCap>();
            listBangCap = BangCapBUS.Ins.GetDanhSachBC();
            cbxBangCap.DataSource = listBangCap;
            // hiện tự giá trị muốn show lên cho người dùng của combobox
            cbxBangCap.DisplayMember = "TenBC";
        }
        /// <summary>
        /// Đổ data nhân viên từ sql vào datagridview
        /// </summary>
        private void LoadDanhSachNhanVien()
        {
            listNhanVien = new List<NhanVien>();

            listNhanVien = NhanVienBUS.Ins.GetDanhSachNV();

            nhanVienBinding.DataSource = listNhanVien;
        }
        /// <summary>
        /// binding nhân viên vào các ô textbox
        /// </summary>
        private void BindingData()
        {
            tbxMaNV.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "MaNV",true,DataSourceUpdateMode.Never));
            tbxHoTenNV.DataBindings.Add(new Binding("Text",dtgvEmployee.DataSource, "HoTenNV", true, DataSourceUpdateMode.Never));
            tbxSDT.DataBindings.Add(new Binding("Text",dtgvEmployee.DataSource, "Dienthoai", true, DataSourceUpdateMode.Never));
            tbxDiaChi.DataBindings.Add(new Binding("Text",dtgvEmployee.DataSource, "Diachi", true, DataSourceUpdateMode.Never));
            dtpkNSNV.DataBindings.Add(new Binding("Value",dtgvEmployee.DataSource, "Ngaysinh", true, DataSourceUpdateMode.Never));
        }

      
        private void AddNhanVien(string MaNV, string HotenNV, string Ngaysinh, string Diachi, string Dienthoai, string MaBC)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listNhanVien.Where(p => p.MaNV == MaNV).Count();
            if (isValidMaNV > 0)
            {
                MessageBox.Show("Thêm vào Thất bại, Mã " + title + " đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            int sdt;
            if (!int.TryParse(Dienthoai,out sdt))
            {
                MessageBox.Show("Thêm vào Thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var result = NhanVienBUS.Ins.InsertNhanVien(MaNV, HotenNV, Ngaysinh, Diachi, Dienthoai, MaBC);
                if (result)
                {
                    MessageBox.Show("Thêm vào thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
                else
                    MessageBox.Show("Thâm vào Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
         
        }
        private void EditNhanVien(string MaNV, string HotenNV, string Ngaysinh, string Diachi, string Dienthoai, string MaBC)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listNhanVien.Where(p => p.MaNV == MaNV).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title + "", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            int sdt;
            if (!int.TryParse(Dienthoai, out  sdt))
            {
                MessageBox.Show("Chỉnh sửa thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else
            {
                var result = NhanVienBUS.Ins.UpdateNhanVien(MaNV, HotenNV, Ngaysinh, Diachi, Dienthoai, MaBC);
                if (result)
                {
                    MessageBox.Show("Chỉnh sửa thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
                else
                    MessageBox.Show("Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void DeleteNhanVien(string MaNV)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listNhanVien.Where(p => p.MaNV == MaNV).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title + "", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return;
            }

            var result = NhanVienBUS.Ins.DeleteNhanVien(MaNV);
            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadDanhSachNhanVien();
            }
            else
                MessageBox.Show("Xóa nhân viên thất bại","Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaNV = tbxMaNV.Text.Trim();
            string HotenNV = tbxHoTenNV.Text.Trim();
            string Ngaysinh = dtpkNSNV.Value.ToString("yyyy - MM - dd");
            string Diachi = tbxDiaChi.Text.Trim();
            string Dienthoai = tbxSDT.Text.Trim();
            string MaBC = (cbxBangCap.SelectedItem as BangCap).MaBC;

            string mess = "Bạn có chắc muốn thêm " + title + " không ? ";
            if (MessageBox.Show(mess, "Thêm " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddNhanVien(MaNV, HotenNV, Ngaysinh, Diachi, Dienthoai, MaBC);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaNV = tbxMaNV.Text.Trim();
            string HotenNV = tbxHoTenNV.Text.Trim();
            string Ngaysinh = dtpkNSNV.Value.ToString("yyyy - MM - dd");
            string Diachi = tbxDiaChi.Text.Trim();
            string Dienthoai = tbxSDT.Text.Trim();
            string MaBC = (cbxBangCap.SelectedItem as BangCap).MaBC;

            string mess = "Bạn có muốn sửa " + title + " có mã " + title + " là ( " + MaNV + " ) không ? ";
            if (MessageBox.Show(mess, "Sửa " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditNhanVien(MaNV, HotenNV, Ngaysinh, Diachi, Dienthoai, MaBC);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MaNV = tbxMaNV.Text.Trim();
            string mess = "Bạn có muốn xóa " + title + " có mã " + title + " là ( " + MaNV + " ) không ? ";
            if (MessageBox.Show(mess, "Xóa " + title + "", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteNhanVien(MaNV);
            }    
           
        }

        private void tbxMaNV_TextChanged(object sender, EventArgs e)
        {
            if (dtgvEmployee.SelectedCells.Count > 0)
            {
                string maBC = dtgvEmployee.SelectedCells[0].OwningRow.Cells["MaBC"].Value.ToString();

                var item = listBangCap.Find(p => p.MaBC == maBC);

                cbxBangCap.SelectedItem = item;
            }
        }
    }
}
