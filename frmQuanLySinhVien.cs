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
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        DbQLSVNhomDataContext db = new DbQLSVNhomDataContext();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidLop(Form1.MaNV, cbbMaLop.SelectedValue.ToString()))
                {
                    MessageBox.Show("Mã lớp không trùng khớp");
                    return;
                }
                SINHVIEN sv = new SINHVIEN
                {
                    MASV = txtMaSV.Text,
                    HOTEN = txtHoTen.Text,
                    NGAYSINH = dtpNgaySinh.Value,
                    DIACHI = txtDiaChi.Text,
                    MALOP = cbbMaLop.SelectedValue.ToString(),
                    TENDN = txtTenDangNhap.Text,
                    MATKHAU = SHA1_Cryptography.SHA1Hashing(txtMatKhau.Text)
                };
                db.SINHVIENs.InsertOnSubmit(sv);
                db.SubmitChanges();
                fillSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            cbbMaLop.DataSource = db.LOPs;
            cbbMaLop.DisplayMember = "TENLOP";
            cbbMaLop.ValueMember = "MALOP";
            fillSinhVien();
        }

        private void fillSinhVien()
        {
            dataGridView1.DataSource = db.SINHVIENs.Where(p => p.MALOP == cbbMaLop.SelectedValue.ToString());
        }

        private void cbbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidLop(Form1.MaNV, cbbMaLop.SelectedValue.ToString()))
                {
                    MessageBox.Show("Mã lớp không trùng khớp");
                    return;
                }
                SINHVIEN sv = db.SINHVIENs.FirstOrDefault(p => p.MASV == txtMaSV.Text);
                db.SINHVIENs.DeleteOnSubmit(sv);
                db.SubmitChanges();
                fillSinhVien();
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
                if (!IsValidLop(Form1.MaNV, cbbMaLop.SelectedValue.ToString()))
                {
                    MessageBox.Show("Mã lớp không trùng khớp");
                    return;
                }
                SINHVIEN sv = db.SINHVIENs.FirstOrDefault(p => p.MASV == txtMaSV.Text);
                sv.HOTEN = txtHoTen.Text;
                sv.NGAYSINH = dtpNgaySinh.Value;
                sv.DIACHI = txtDiaChi.Text;
                sv.TENDN = txtTenDangNhap.Text;
                sv.MATKHAU = SHA1_Cryptography.SHA1Hashing(txtMatKhau.Text);
                db.SubmitChanges();
                fillSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValidLop(string manv, string malop)
        {
            LOP lop = db.LOPs.FirstOrDefault(p => p.MANV == manv);
            if (lop.MALOP == malop) return true;
            return false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
