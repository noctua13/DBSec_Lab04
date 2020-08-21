using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DBSecurity_Lab04_Public
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        DbQLSVNhomDataContext db = new DbQLSVNhomDataContext();

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Generate a keypair
                string pubkey = txtMaNV.Text;

                string pubkeypath = @"D:\RSAkeypairs\" + pubkey + @".rsapublickey";
                string prikeypath = @"D:\RSAkeypairs\" + pubkey + @".rsaprivatekey";
                RSA512_Cryptography.makeKey(pubkeypath, prikeypath);

                byte[] luong = RSA512_Cryptography.encryptText(pubkeypath, txtLuong.Text);
                byte[] matkhau = SHA1_Cryptography.SHA1Hashing(txtMatKhau.Text);
                db.SP_INS_PUBLIC_ENCRYPT_NHANVIEN(txtMaNV.Text, txtHoTen.Text, txtEmail.Text, luong, txtTenDangNhap.Text, matkhau, pubkey);
                MessageBox.Show("Thêm thành công");
                fillNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                db.NHANVIENs.DeleteOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công.");
                fillNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            fillNhanVien();
        }

        private void fillNhanVien()
        {
            dataGridView1.DataSource = db.NHANVIENs.Select(p => p);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                string pubkeypath = @"D:\RSAkeypairs\NV.publickey";
                nv.HOTEN = txtHoTen.Text;
                nv.EMAIL = txtEmail.Text;
                nv.LUONG = RSA512_Cryptography.encryptText(pubkeypath, txtLuong.Text);
                nv.TENDN = txtTenDangNhap.Text;
                nv.MATKHAU = SHA1_Cryptography.SHA1Hashing(txtMatKhau.Text);

                db.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                fillNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == txtMaNV.Text);
            string prikeypath = @"D:\RSAkeypairs\" + nv.PUBKEY + @".rsaprivatekey";
            string decryptedLuong = RSA512_Cryptography.decryptText(prikeypath, nv.LUONG.ToArray());
            MessageBox.Show("Giá trị cột lương: " + decryptedLuong);
        }
    }
}
