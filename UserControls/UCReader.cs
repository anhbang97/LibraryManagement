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
    public partial class UCReader : UserControl
    {
        BindingSource docGiaBinding = new BindingSource();
        List<DocGia> listDocGia;
        string title = "đọc giả";
        public UCReader()
        {
            InitializeComponent();

            KhoiTao();
            BindingData();
        }
        private void KhoiTao()
        {
            LoadDanhSachDocGia();
            dtgvReader.DataSource = docGiaBinding;

        }

        /// <summary>
        /// Đổ data nhân viên từ sql vào datagridview
        /// </summary>
        private void LoadDanhSachDocGia()
        {
            listDocGia = new List<DocGia>();

            listDocGia = DocGiaBUS.Ins.GetDanhSachDG();

            docGiaBinding.DataSource = listDocGia;
        }
        /// <summary>
        /// binding nhân viên vào các ô textbox
        /// </summary>
        private void BindingData()
        {
            tbxMaDG.DataBindings.Add(new Binding("Text", dtgvReader.DataSource, "MaDocGia", true, DataSourceUpdateMode.Never));
            tbxDiaChi.DataBindings.Add(new Binding("Text", dtgvReader.DataSource, "Diachi", true, DataSourceUpdateMode.Never));
            tbxEmail.DataBindings.Add(new Binding("Text", dtgvReader.DataSource, "Email", true, DataSourceUpdateMode.Never));
            tbxTienNo.DataBindings.Add(new Binding("Text", dtgvReader.DataSource, "TienNo", true, DataSourceUpdateMode.Never));
            tbxTenDG.DataBindings.Add(new Binding("Text", dtgvReader.DataSource, "HoTenDocGia", true, DataSourceUpdateMode.Never));
            dtpkNgaySinh.DataBindings.Add(new Binding("Value", dtgvReader.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            dtpkNgayLapThe.DataBindings.Add(new Binding("Value", dtgvReader.DataSource, "Ngaylapthe", true, DataSourceUpdateMode.Never));
            dtpkNgayHetHan.DataBindings.Add(new Binding("Value", dtgvReader.DataSource, "Ngayhethan", true, DataSourceUpdateMode.Never));
        }

        private void AddDocGia(string MaDocGia, string HoTenDocGia, string Diachi, string NgaySinh, string Email, string Ngaylapthe, string Ngayhethan, float Tienno)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listDocGia.Where(p => p.MaDocGia == MaDocGia).Count();
            if (isValidMaNV > 0)
            {
                MessageBox.Show("Thêm vào Thất bại, Mã " + title + " đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            if (!float.TryParse(Tienno.ToString(), out float number))
            {
                MessageBox.Show("Thêm vào Thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var result = DocGiaBUS.Ins.InsertDocGia( MaDocGia,  HoTenDocGia,  Diachi,  NgaySinh,  Email,  Ngaylapthe,  Ngayhethan,  Tienno);

                if (result)
                {
                    MessageBox.Show("Thêm vào thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDocGia();
                }
                else
                    MessageBox.Show("Thâm vào Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        private void EditDocGia(string MaDocGia, string HoTenDocGia, string Diachi, string NgaySinh, string Email, string Ngaylapthe, string Ngayhethan, float Tienno)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listDocGia.Where(p => p.MaDocGia == MaDocGia).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title +"", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            // kiêm tra số điện thoại hợp lệ'
            if (!float.TryParse(Tienno.ToString(), out float number))
            {
                MessageBox.Show("Thêm vào Thất bại, Số điện thoại bạn nhâp không hợp lệ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else
            {
                var result = DocGiaBUS.Ins.UpdateDocGia( MaDocGia,  HoTenDocGia,  Diachi,  NgaySinh,  Email,  Ngaylapthe,  Ngayhethan,  Tienno);
                if (result)
                {
                    MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDocGia();
                }
                else
                    MessageBox.Show("Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void DeleteDocGia(string MaDocGia)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaNV = listDocGia.Where(p => p.MaDocGia == MaDocGia).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã " + title + "", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = DocGiaBUS.Ins.DeleteDocGia(MaDocGia);
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
            string MaDocGia = tbxMaDG.Text.Trim();
            string mess = "Bạn có muốn xóa "+ title + " có mã " + title + " là ( " + MaDocGia + " ) không ? ";
            if (MessageBox.Show(mess, "Xóa " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteDocGia(MaDocGia);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaDG = tbxMaDG.Text.Trim();
            string DiaChi = tbxDiaChi.Text.Trim();
            string Email = tbxEmail.Text.Trim();
            float TienNo = !string.IsNullOrEmpty(tbxTienNo.Text) ? float.Parse(tbxTienNo.Text) : 0;
            string TenDG = tbxTenDG.Text.Trim();
            string NgayLapThe = dtpkNgayLapThe.Value.ToString("yyyy - MM - dd");
            string NgaySinh = dtpkNgaySinh.Value.ToString("yyyy - MM - dd");
            string NgayHetHan = dtpkNgayHetHan.Value.ToString("yyyy - MM - dd");

            string mess = "Bạn có muốn sửa nhân viên có mã " + title + " là ( " + MaDG + " ) không ? ";
            if (MessageBox.Show(mess, "Sửa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditDocGia(MaDG, TenDG, DiaChi,  NgaySinh,  Email, NgayLapThe, NgayHetHan, TienNo);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaDG = tbxMaDG.Text.Trim();
            string DiaChi = tbxDiaChi.Text.Trim();
            string Email = tbxEmail.Text.Trim();
            float TienNo = !string.IsNullOrEmpty(tbxTienNo.Text) ? float.Parse(tbxTienNo.Text) : 0;
            string TenDG = tbxTenDG.Text.Trim();
            string NgayLapThe = dtpkNgayLapThe.Value.ToString("yyyy - MM - dd");
            string NgaySinh = dtpkNgaySinh.Value.ToString("yyyy - MM - dd");
            string NgayHetHan = dtpkNgayHetHan.Value.ToString("yyyy - MM - dd");

            string mess = "Bạn có chắc muốn thêm " + title + " không ? ";
            if (MessageBox.Show(mess, "Thêm " + title + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddDocGia(MaDG, TenDG, DiaChi, NgaySinh, Email, NgayLapThe, NgayHetHan, TienNo);
            }
        }
    }
}
