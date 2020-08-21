using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSecurity_Lab04_Public
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbQLSVNhomDataContext db = new DbQLSVNhomDataContext();
        public static string MaNV;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ISingleResult<SP_SEL_PUBLIC_ENCRYPT_NHANVIENResult>  nv = db.SP_SEL_PUBLIC_ENCRYPT_NHANVIEN(txtTenDangNhap.Text, SHA1_Cryptography.SHA1Hashing(txtMatKhau.Text));
            if (nv.FirstOrDefault() == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng."); return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công");
                //get the MANV, again
                NHANVIEN first = db.NHANVIENs.FirstOrDefault(p => p.TENDN == txtTenDangNhap.Text);
                MaNV = first.MANV;
                //load manager form
                frmManager f = new frmManager();
                f.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaNV = string.Empty;
        }
    }
}
