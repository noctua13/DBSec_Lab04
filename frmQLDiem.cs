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
    public partial class frmQLDiem : Form
    {
        public frmQLDiem()
        {
            InitializeComponent();
        }

        DbQLSVNhomDataContext db = new DbQLSVNhomDataContext();

        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            fillDiem();
        }

        private bool IsValidLop(string manv, string masv)
        {
            LOP lop = db.LOPs.FirstOrDefault(p => p.MANV == manv);
            SINHVIEN sv = db.SINHVIENs.FirstOrDefault(p => p.MASV == masv);
            if (lop.MALOP == sv.MALOP) return true;
            return false;
        }

        private void fillDiem()
        {
            dataGridView1.DataSource = db.BANGDIEMs.Select(p => p);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidLop(Form1.MaNV, txtMaSV.Text))
                {
                    MessageBox.Show("Mã lớp không trùng khớp.");
                    return;
                }
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == Form1.MaNV);
                string pubkeypath = @"D:\RSAkeypairs\" + nv.PUBKEY + @".rsapublickey";
                byte[] diem = RSA512_Cryptography.encryptText(pubkeypath, txtDiem.Text);

                BANGDIEM bd = new BANGDIEM
                {
                    MASV = txtMaSV.Text,
                    MAHP = txtMaHP.Text,
                    DIEMTHI = diem
                };
                db.BANGDIEMs.InsertOnSubmit(bd);
                db.SubmitChanges();
                fillDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidLop(Form1.MaNV, txtMaSV.Text))
                {
                    MessageBox.Show("Mã lớp không trùng khớp.");
                    return;
                }
                BANGDIEM bd = db.BANGDIEMs.FirstOrDefault(p => p.MAHP == txtMaHP.Text && p.MASV == txtMaSV.Text);
                db.BANGDIEMs.DeleteOnSubmit(bd);
                db.SubmitChanges();
                fillDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidLop(Form1.MaNV, txtMaSV.Text))
                {
                    MessageBox.Show("Mã lớp không trùng khớp.");
                    return;
                }
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == Form1.MaNV);
                string pubkeypath = @"D:\RSAkeypairs\" + nv.PUBKEY + @".rsapublickey";
                byte[] diem = RSA512_Cryptography.encryptText(pubkeypath, txtDiem.Text);

                BANGDIEM bd = db.BANGDIEMs.FirstOrDefault(p => p.MAHP == txtMaHP.Text && p.MASV == txtMaSV.Text);
                bd.DIEMTHI = diem;
                db.SubmitChanges();
                fillDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!IsValidLop(Form1.MaNV, txtMaSV.Text))
            {
                MessageBox.Show("Mã lớp không trùng khớp.");
                return;
            }
            BANGDIEM bd = db.BANGDIEMs.FirstOrDefault(p => p.MAHP == txtMaHP.Text && p.MASV == txtMaSV.Text);
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(p => p.MANV == Form1.MaNV);
            string prikeypath = @"D:\RSAkeypairs\" + nv.PUBKEY + @".rsaprivatekey";
            string decryptedDiem = RSA512_Cryptography.decryptText(prikeypath, bd.DIEMTHI.ToArray());
            MessageBox.Show("Giá trị điểm:" + decryptedDiem);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
