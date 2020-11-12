using Library_management.DTO;
using Library_management.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management
{
    public partial class Form1 : Form
    {
        public Form1(NhanVien nhanvien)
        {
            InitializeComponent();
            lbEmplAccount.Text = nhanvien.HoTenNV;
        }

        // sự kiện chung của các button ở menu 
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnEmployee":
                    // thanh slide duy chuyên xuống bên dưới mỗi button được click
                    SlidePanel.Location = new Point(0,btn.Location.Y + btn.Height);
                    // xóa usercontrol mặc định đc add vào
                    pnContainer.Controls.Clear();
                    // tạp usercontrol mới và add vào
                    UCEmployee ucEmp = new UCEmployee();
                    ucEmp.Dock = DockStyle.Fill;
                    pnContainer.Controls.Add(ucEmp);
                    break;
                case "btnReader":
                    SlidePanel.Location = new Point(0, btn.Location.Y + btn.Height);
                    pnContainer.Controls.Clear();
                    UCReader ucReader = new UCReader();
                    ucReader.Dock = DockStyle.Fill;
                    pnContainer.Controls.Add(ucReader);
                    break;
                case "btnBook":
                    SlidePanel.Location = new Point(0, btn.Location.Y + btn.Height);
                    pnContainer.Controls.Clear();
                    UCBook ucBook = new UCBook();
                    ucBook.Dock = DockStyle.Fill;
                    pnContainer.Controls.Add(ucBook);
                    break;
                case "btnPayment":
                    SlidePanel.Location = new Point(0, btn.Location.Y + btn.Height);
                    pnContainer.Controls.Clear();
                    UCPayment ucPayment = new UCPayment();
                    ucPayment.Dock = DockStyle.Fill;
                    pnContainer.Controls.Add(ucPayment);
                    break;
                case "btnAccount":
                    SlidePanel.Location = new Point(0, btn.Location.Y + btn.Height);
                    pnContainer.Controls.Clear();
                    UCAccount ucAccount = new UCAccount();
                    ucAccount.Dock = DockStyle.Fill;
                    pnContainer.Controls.Add(ucAccount);
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // thêm user control mặc định
            UCEmployee ucEmp = new UCEmployee();
            ucEmp.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(ucEmp);
        }
    }
}
