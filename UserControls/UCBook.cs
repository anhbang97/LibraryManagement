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
    public partial class UCBook : UserControl
    {
        BindingSource sachBinding = new BindingSource();
        List<Sach> listSach;
        string title = "sách";
        public UCBook()
        {
            InitializeComponent();
            KhoiTao();
            BindingData();
        }
        private void KhoiTao()
        {
            LoadDanhSachDocGia();
            dtgvBook.DataSource = sachBinding;

        }

        /// <summary>
        /// Đổ data nhân viên từ sql vào datagridview
        /// </summary>
        private void LoadDanhSachDocGia()
        {
            listSach = new List<Sach>();

            listSach = SachBUS.Ins.GetDanhSachSach();

            sachBinding.DataSource = listSach;
        }
        /// <summary>
        /// binding nhân viên vào các ô textbox
        /// </summary>
        private void BindingData()
        {
            tbxMaSach.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "MaSach", true, DataSourceUpdateMode.Never));
            tbxNhaXuatBan.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "Nhaxuatban", true, DataSourceUpdateMode.Never));
            tbxTacGia.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "TacGia", true, DataSourceUpdateMode.Never));
            tbxTenSach.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "TenSach", true, DataSourceUpdateMode.Never));
            tbxTriGia.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "Trigia", true, DataSourceUpdateMode.Never));
            dtpkNamXuatBan.DataBindings.Add(new Binding("Value", dtgvBook.DataSource, "Namxuatban", true, DataSourceUpdateMode.Never));
            dtpkNgayNhap.DataBindings.Add(new Binding("Value", dtgvBook.DataSource, "Ngaynhap", true, DataSourceUpdateMode.Never));
        }
        private void AddSach(string MaSach, string TenSach, string TacGia, string Namxuatban, string Nhaxuatban, float Trigia, string Ngaynhap)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listSach.Where(p => p.MaSach == MaSach).Count();
            if (isValidMaNV > 0)
            {
                MessageBox.Show("Thêm vào Thất bại, Mã " + title + " đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            if (!float.TryParse(Trigia.ToString(), out float number))
            {
                MessageBox.Show("Thêm vào Thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var result = SachBUS.Ins.InsertSach( MaSach,  TenSach,  TacGia,  Namxuatban,  Nhaxuatban,  Trigia,  Ngaynhap);

                if (result)
                {
                    MessageBox.Show("Thêm vào thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDocGia();
                }
                else
                    MessageBox.Show("Thâm vào Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        private void EditSach(string MaSach, string TenSach, string TacGia, string Namxuatban, string Nhaxuatban, float Trigia, string Ngaynhap)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listSach.Where(p => p.MaSach == MaSach).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title + "", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            if (!float.TryParse(Trigia.ToString(), out float number))
            {
                MessageBox.Show("Thêm vào Thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else
            {
                var result = SachBUS.Ins.UpdateSach( MaSach,  TenSach,  TacGia,  Namxuatban,  Nhaxuatban,  Trigia,  Ngaynhap);
                if (result)
                {
                    MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDocGia();
                }
                else
                    MessageBox.Show("Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void DeleteSach(string MaSach)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listSach.Where(p => p.MaSach == MaSach).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title + "", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = SachBUS.Ins.DeleteSach(MaSach);
            if (result)
            {
                MessageBox.Show("Xóa " + title + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDocGia();
            }
            else
                MessageBox.Show("Xóa " + title + " thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MaSach = tbxMaSach.Text.Trim();
            string mess = "Bạn có muốn xóa " + title + " có mã " + title + " là ( " + MaSach + " ) không ? ";
            if (MessageBox.Show(mess, "Xóa " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteSach(MaSach);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaSach = tbxMaSach.Text.Trim();
            string Nhaxuatban = tbxNhaXuatBan.Text.Trim();
            string TacGia = tbxTacGia.Text.Trim();
            float Trigia = !string.IsNullOrEmpty(tbxTriGia.Text) ? float.Parse(tbxTriGia.Text) : 0;
            string TenSach = tbxTenSach.Text.Trim();
            string Namxuatban = dtpkNamXuatBan.Value.ToString("yyyy - MM - dd");
            string Ngaynhap = dtpkNgayNhap.Value.ToString("yyyy - MM - dd");

            string mess = "Bạn có muốn sửa nhân viên có mã " + title + " là ( " + MaSach + " ) không ? ";
            if (MessageBox.Show(mess, "Sửa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditSach( MaSach,  TenSach,  TacGia,  Namxuatban,  Nhaxuatban,  Trigia,  Ngaynhap);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaSach = tbxMaSach.Text.Trim();
            string Nhaxuatban = tbxNhaXuatBan.Text.Trim();
            string TacGia = tbxTacGia.Text.Trim();
            float Trigia = !string.IsNullOrEmpty(tbxTriGia.Text) ? float.Parse(tbxTriGia.Text) : 0;
            string TenSach = tbxTenSach.Text.Trim();
            string Namxuatban = dtpkNamXuatBan.Value.ToString("yyyy - MM - dd");
            string Ngaynhap = dtpkNgayNhap.Value.ToString("yyyy - MM - dd");

            string mess = "Bạn có chắc muốn thêm " + title + " không ? ";
            if (MessageBox.Show(mess, "Thêm " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddSach(MaSach, TenSach, TacGia, Namxuatban, Nhaxuatban, Trigia, Ngaynhap);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // search 

            string keywork = tbxSearch.Text;
            sachBinding.DataSource = listSach.Where(p => p.TenSach.ToLower().Contains(keywork.ToLower())).ToList();
            dtgvBook.DataSource = sachBinding;
        }
    }
}
