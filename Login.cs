using Library_management.BUS;
using Library_management.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uTF8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(uTF8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        private void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUserName.Text;
            string passwork = Encrypt(tbxPassword.Text);

            bool result = AccountBUS.Ins.Login(username, passwork);
            if (result)
            {
                var nhanvien = AccountBUS.Ins.GetNhanVienByAccount(username,passwork);
                this.Hide();
                Form1 fr = new Form1(nhanvien);
                fr.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. vui lòng kiểm tra lại");
            }
        }
    }
}
