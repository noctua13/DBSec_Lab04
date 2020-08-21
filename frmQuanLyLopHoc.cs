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
    public partial class frmQuanLyLopHoc : Form
    {
        public frmQuanLyLopHoc()
        {
            InitializeComponent();
        }

        DbQLSVNhomDataContext db = new DbQLSVNhomDataContext();

        private void fillLop()
        {
            dataGridView1.DataSource = db.LOPs.Select(p => p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LOP lop = new LOP
                {
                    MALOP = txtMaLop.Text,
                    MANV = txtMaNV.Text,
                    TENLOP = txtTenLop.Text
                };
                db.LOPs.InsertOnSubmit(lop);
                db.SubmitChanges();
                
                fillLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            fillLop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LOP lop = db.LOPs.FirstOrDefault(p => p.MALOP == txtMaLop.Text);
                db.LOPs.DeleteOnSubmit(lop);
                db.SubmitChanges();
                fillLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LOP lop = db.LOPs.FirstOrDefault(p => p.MALOP == txtMaLop.Text);
                lop.MANV = txtMaNV.Text;
                lop.TENLOP = txtTenLop.Text;
                db.SubmitChanges();
                fillLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
