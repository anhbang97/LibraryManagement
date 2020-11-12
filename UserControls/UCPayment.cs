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
    public partial class UCPayment : UserControl
    {
        BindingSource phieuMuonSachBinding = new BindingSource();
        BindingSource phieuThuTienBinding = new BindingSource();
        List<PhieuMuonSach> listMuonSach;
        List<PhieuThuTien> listPhieuThuTien;
        List<Sach> listSach;
        List<DocGia> listDocGia;
        List<DocGia> listDocGiaPTT;
        List<NhanVien> listNhanVien;
        public UCPayment()
        {
            InitializeComponent();
            KhoiTao();
            // add binding 
            BindingDataPhieuMuonSach();
            BindingDataPhieuThuTien();
        }
        private void KhoiTao()
        {
            LoadDanhSachPhieuMuonSach();
            LoadDanhSachPhieuThuTien();
            // đỏ giá trị vào combobox
            LoadDanhSachNhanVien();
            LoadDanhSachDocGia();
            LoadDanhSachSach();


            dtgvPhieuMuonSach.DataSource = phieuMuonSachBinding;
            dtgvPhieuThuTien.DataSource = phieuThuTienBinding;

        }
        /// <summary>
        /// load danh sách nhân viên add vào cbxMaNV
        /// </summary>
        private void LoadDanhSachNhanVien()
        {
            listNhanVien = new List<NhanVien>();
            listNhanVien = NhanVienBUS.Ins.GetDanhSachNV();
            cbxMaNV.DataSource = listNhanVien;
            cbxMaNV.DisplayMember = "MaNV";
        }
        /// <summary>
        /// load danh sách nhân viên add vào cbxMaDocGia,cbxMaDocGiaPTT
        /// </summary>
        private void LoadDanhSachDocGia()
        {
            listDocGia = new List<DocGia>();
            listDocGiaPTT = new List<DocGia>();
            listDocGia = DocGiaBUS.Ins.GetDanhSachDG();
            listDocGiaPTT = DocGiaBUS.Ins.GetDanhSachDG();
            
            // cbxMaDocGia
            cbxMaDocGia.DataSource = listDocGia;            
            cbxMaDocGia.DisplayMember = "MaDocGia";

            cbxTenDocGia.DataSource = listDocGia;
            cbxTenDocGia.DisplayMember = "HoTenDocGia";

            //cbxMaDocGiaPTT
            cbxMaDocGiaPTT.DataSource = listDocGiaPTT;
            cbxMaDocGiaPTT.DisplayMember = "MaDocGia";

        } 
        private void LoadDanhSachSach()
        {
            listSach = new List<Sach>();
            listSach = SachBUS.Ins.GetDanhSachSach();
            cbxSach.DataSource = listSach;
            cbxSach.DisplayMember = "TenSach";

        }
        private void BindingDataPhieuMuonSach()
        {
            tbxMaPhieuMuon.DataBindings.Add(new Binding("Text", dtgvPhieuMuonSach.DataSource, "MaPMS", true, DataSourceUpdateMode.Never));
            dtpkNgayMuon.DataBindings.Add(new Binding("Text", dtgvPhieuMuonSach.DataSource, "Ngaymuon", true, DataSourceUpdateMode.Never));                   
        }
        private void BindingDataPhieuThuTien()
        {
            tbxPTT.DataBindings.Add(new Binding("Text", dtgvPhieuThuTien.DataSource, "MaPTT", true, DataSourceUpdateMode.Never));
            tbxTienNo.DataBindings.Add(new Binding("Text", dtgvPhieuThuTien.DataSource, "Sotienno", true, DataSourceUpdateMode.Never));
            tbxTienThu.DataBindings.Add(new Binding("Text", dtgvPhieuThuTien.DataSource, "Sotienthu", true, DataSourceUpdateMode.Never));
        }
        private void LoadDanhSachPhieuMuonSach()
        {
            listMuonSach = new List<PhieuMuonSach>();

            listMuonSach = PhieuMuonSachBUS.Ins.GetDanhSachPhieuMuonSach();

            phieuMuonSachBinding.DataSource = listMuonSach;
        }
        private void LoadDanhSachPhieuThuTien()
        {
            listPhieuThuTien = new List<PhieuThuTien>();

            listPhieuThuTien = PhieuThuTienBUS.Ins.GetDanhSachPhieuThuTien();

            phieuThuTienBinding.DataSource = listPhieuThuTien;
        }

        private void AddPhieuMuonSach(string MaSach, string MaPMS, string MaDocGia, string Ngaymuon)
        {
            // kiêm tra mã Phiếu đã tồn tại hay chưa
            var isValidMaPMS = listMuonSach.Where(p => p.MaPMS == MaPMS).Count();
            if (isValidMaPMS > 0)
            {
                MessageBox.Show("Thêm vào Thất bại, mã phiếu mượn sách đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            var result = PhieuMuonSachBUS.Ins.InsertPhieuMuonSach( MaSach,  MaPMS,  MaDocGia,  Ngaymuon);
            if (result)
            {
                MessageBox.Show("Thêm vào thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuMuonSach();
            }
            else
                MessageBox.Show("Thâm vào Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }
        private void EditPhieuMuonSach(string MaSach, string MaPMS, string MaDocGia, string Ngaymuon)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaPMS = listMuonSach.Where(p => p.MaPMS == MaPMS).Count();
            if (isValidMaPMS < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã phiếu mượn sách", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            var result = PhieuMuonSachBUS.Ins.UpdatePhieuMuonSach(MaSach, MaPMS, MaDocGia, Ngaymuon);
            if (result)
            {
                MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuMuonSach();
            }
            else
                MessageBox.Show("Chỉnh sửa Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }
        private void DeletePhieuMuonSach(string MaPMS)
        {
            // kiêm tra mã phiếu mượn đã tồn tại hay không
            var isValidMaNV = listMuonSach.Where(p => p.MaPMS == MaPMS).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã phiếu mượn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = PhieuMuonSachBUS.Ins.DeletePhieuMuonSach(MaPMS);
            if (result)
            {
                MessageBox.Show("Xóa phiếu mượn sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuMuonSach();
            }
            else
                MessageBox.Show("Xóa phiếu mượn sách thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void AddPhieuThuTien(string MaPTT, float Sotienno, float Sotienthu, string MaDocGia, string MaNV)
        {
            // kiêm tra mã Phiếu đã tồn tại hay chưa
            var isValidMaPMS = listPhieuThuTien.Where(p => p.MaPTT == MaPTT).Count();
            if (isValidMaPMS > 0)
            {
                MessageBox.Show("Thêm vào Thất bại, Mã phiếu thu tiền đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra thêm sotienno sotienthu phải là số hay không ? 


            // thêm vào 
            var result = PhieuThuTienBUS.Ins.InsertPhieuThuTien( MaPTT,  Sotienno,  Sotienthu,  MaDocGia,  MaNV);
            if (result)
            {
                MessageBox.Show("Thêm vào thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuThuTien();
            }
            else
                MessageBox.Show("Thâm vào Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }
        private void EditPhieuThuTien(string MaPTT, float Sotienno, float Sotienthu, string MaDocGia, string MaNV)
        {
            // kiêm tra mã nhân viên đã tồn tại hay chưa
            var isValidMaPMS = listPhieuThuTien.Where(p => p.MaPTT == MaPTT).Count();
            if (isValidMaPMS < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã phiếu mượn sách", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra thêm sotienno sotienthu phải là số hay không ? 


            // chỉnh sửa
            var result = PhieuThuTienBUS.Ins.UpdatePhieuThuTien( MaPTT,  Sotienno,  Sotienthu,  MaDocGia,  MaNV);
            if (result)
            {
                MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuThuTien();
            }
            else
                MessageBox.Show("Chỉnh sửa Thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }
        private void DeletePhieuThuTien(string MaPTT)
        {
            // kiêm tra mã phiếu mượn đã tồn tại hay không
            var isValidMaNV = listPhieuThuTien.Where(p => p.MaPTT == MaPTT).Count();
            if (isValidMaNV < 0)
            {
                MessageBox.Show("Không thể tìm thấy mã phiếu mượn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = PhieuThuTienBUS.Ins.DeletePhieuThuTien(MaPTT);
            if (result)
            {
                MessageBox.Show("Xóa phiếu thu tiền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhieuThuTien();
            }
            else
                MessageBox.Show("Xóa thu tiền thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaSach = (cbxSach.SelectedItem as Sach).MaSach;
            string MaPMS = tbxMaPhieuMuon.Text;
            string MaDocGia = (cbxMaDocGia.SelectedItem as DocGia).MaDocGia;
            string Ngaymuon = DateTime.Now.ToString("yyyy - MM - dd");

            string mess = "Bạn có chắc muốn thêm phiếu mượn sách này không ? ";
            if (MessageBox.Show(mess, "Thêm phiếu mượn sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddPhieuMuonSach(MaSach, MaPMS, MaDocGia, Ngaymuon);
                
            }
        }

        private void tbxMaPhieuMuon_TextChanged(object sender, EventArgs e)
        {
            if (dtgvPhieuMuonSach.SelectedCells.Count > 0)
            {
                string maSach = dtgvPhieuMuonSach.SelectedCells[0].OwningRow.Cells["MaSach"].Value.ToString();
                string maDocGia = dtgvPhieuMuonSach.SelectedCells[0].OwningRow.Cells["MaDocGia"].Value.ToString();

                var itemSach = listSach.Find(p=>p.MaSach == maSach);
                var itemDocGia = listDocGia.Find(p=>p.MaDocGia == maDocGia);

                cbxSach.SelectedItem = itemSach;
                cbxMaDocGia.SelectedItem = itemDocGia;
                int indexSach = 0;
                int indexDocGia = 0;

                foreach (var item in listSach)
                {
                    if (itemSach.MaSach == item.MaSach)
                    {
                        break;
                    }
                    else
                    {
                        indexSach++;
                    }
                    
                }
                foreach (var item in listDocGia)
                {
                    if (item.MaDocGia == itemDocGia.MaDocGia)
                    {
                        break;
                    }
                    else
                    {
                        indexDocGia++;
                    }

                }

                cbxSach.SelectedIndex = indexSach;
                cbxMaDocGia.SelectedIndex = indexDocGia;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaSach = (cbxSach.SelectedItem as Sach).MaSach;
            string MaPMS = tbxMaPhieuMuon.Text;
            string MaDocGia = (cbxMaDocGia.SelectedItem as DocGia).MaDocGia;
            string Ngaymuon = DateTime.Now.ToString("yyyy - MM - dd");

            string mess = "Bạn có chắc muốn sửa phiếu mượn sách này không ? ";
            if (MessageBox.Show(mess, "Sửa phiếu mượn sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditPhieuMuonSach(MaSach, MaPMS, MaDocGia, Ngaymuon);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MaPMS = tbxMaPhieuMuon.Text.Trim();
            string mess = "Bạn có muốn xóa phiếu mượn sách có mã phiếu mượn sách là ( " + MaPMS + " ) không ? ";
            if (MessageBox.Show(mess, "Xóa phiếu mượn sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeletePhieuMuonSach(MaPMS);
            }
        }

        private void tbxPTT_TextChanged(object sender, EventArgs e)
        {
            if (dtgvPhieuThuTien.SelectedCells.Count > 0)
            {
                string maNV = dtgvPhieuThuTien.SelectedCells[0].OwningRow.Cells["MaNV"].Value.ToString();
                string maDocGia = dtgvPhieuThuTien.SelectedCells[0].OwningRow.Cells["MaDocGia"].Value.ToString();

                var itemNV = listNhanVien.Find(p => p.MaNV == maNV);
                var itemDocGia = listDocGiaPTT.Find(p => p.MaDocGia == maDocGia);

                cbxMaNV.SelectedItem = itemNV;
                cbxMaDocGiaPTT.SelectedItem = itemDocGia;
                int indexNV = 0;
                int indexDocGia = 0;

                foreach (var item in listNhanVien)
                {
                    if (itemNV.MaNV == item.MaNV)
                    {
                        break;
                    }
                    else
                    {
                        indexNV++;
                    }

                }
                foreach (var item in listDocGiaPTT)
                {
                    if (item.MaDocGia == itemDocGia.MaDocGia)
                    {
                        break;
                    }
                    else
                    {
                        indexDocGia++;
                    }

                }

                cbxMaNV.SelectedIndex = indexNV;
                cbxMaDocGiaPTT.SelectedIndex = indexDocGia;
            }
        }

        private void btnAddPTT_Click(object sender, EventArgs e)
        {
            string MaPTT = tbxPTT.Text.Trim();
            float Sotienno = (float)Convert.ToDouble(tbxTienNo.Text);
            float Sotienthu = (float)Convert.ToDouble(tbxTienThu.Text);
            string MaDocGia = (cbxMaDocGiaPTT.SelectedItem as DocGia).MaDocGia;
            string MaNV = (cbxMaNV.SelectedItem as NhanVien).MaNV;
            

            string mess = "Bạn có chắc muốn thêm phiếu thu tiền này không ? ";
            if (MessageBox.Show(mess, "Thêm thu tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddPhieuThuTien( MaPTT,  Sotienno,  Sotienthu,  MaDocGia,  MaNV);

            }
        }

        private void btnSuaPTT_Click(object sender, EventArgs e)
        {
            string MaPTT = tbxPTT.Text.Trim();
            float Sotienno = (float)Convert.ToDouble(tbxTienNo.Text);
            float Sotienthu = (float)Convert.ToDouble(tbxTienThu.Text);
            string MaDocGia = (cbxMaDocGiaPTT.SelectedItem as DocGia).MaDocGia;
            string MaNV = (cbxMaNV.SelectedItem as NhanVien).MaNV;

            string mess = "Bạn có chắc muốn sửa phiếu thu tiền này không ? ";
            if (MessageBox.Show(mess, "Sửa thu tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditPhieuThuTien(MaPTT, Sotienno, Sotienthu, MaDocGia, MaNV);
            }
        }

        private void btnXoaPTT_Click(object sender, EventArgs e)
        {
            string MaPTT = tbxPTT.Text.Trim();
            string mess = "Bạn có muốn xóa phiếu thu tiền này không ? ";
            if (MessageBox.Show(mess, "Xóa phiếu thu tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeletePhieuThuTien(MaPTT);
            }
        }
    }
}
