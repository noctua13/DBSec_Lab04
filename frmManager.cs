using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSecurity_Lab04_Public
{
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1.MaNV = string.Empty;
            this.Close();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            txtMaNVLogin.Text = Form1.MaNV;
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien f = new frmQuanLyNhanVien();
            f.Show();
        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {
            frmQuanLyLopHoc f = new frmQuanLyLopHoc();
            f.Show();
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien f = new frmQuanLySinhVien();
            f.Show();
        }

        private void btnQLDiem_Click(object sender, EventArgs e)
        {
            frmQLDiem f = new frmQLDiem();
            f.Show();
        }
    }
}
