using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_Project
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUltil data = new DataUltil();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSV();
        }

        public void LoadSV()
        {
            dgvSinhVien.DataSource = data.getAllStudent();
            dgvSinhVien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dgvSinhVien.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dgvSinhVien.Columns[i].Width;

                // Remove AutoSizing:
                dgvSinhVien.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dgvSinhVien.Columns[i].Width = colw;
            }
            lblTong.Text=   dgvSinhVien.Rows.Count + "";

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            LoadSV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.sid = txtSid.Text;
            st.name = txtName.Text;
            st.age = txtAge.Text;
            st.addr = txtAddress.Text;
            data.Add(st);
            Clear();
            LoadSV();

        }
        public void Clear()
        {
            txtName.Clear();
            txtSid.Clear();
            txtAge.Clear();
            txtAddress.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dgvSinhVien.CurrentRow.DataBoundItem;
            txtSid.Text = s.sid;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtAddress.Text = s.addr;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.sid = txtSid.Text;
            st.name = txtName.Text;
            st.age = txtAge.Text;
            st.addr = txtAddress.Text;
           bool b= data.Update(st);
            if (!b)
            {
                MessageBox.Show("Không tìm thấy bản ghi!");
            }
            Clear();
            LoadSV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn xoá bản ghi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes)
            {
                bool b = data.Delete(txtSid.Text);
                if (!b)
                {
                    MessageBox.Show("Không tìm thấy bản ghi!");
                }
                Clear();
                LoadSV();
            }
          
        }

        private void btnFindById_Click(object sender, EventArgs e)
        {
            List<Student> lst = data.FindById(txtSid.Text);
            dgvSinhVien.DataSource = lst;
            dgvSinhVien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dgvSinhVien.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dgvSinhVien.Columns[i].Width;

                // Remove AutoSizing:
                dgvSinhVien.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dgvSinhVien.Columns[i].Width = colw;
            }
            lblTong.Text = dgvSinhVien.Rows.Count + "";

        }

        private void btnFindByCity_Click(object sender, EventArgs e)
        {
            List<Student> lst = data.FindByCity(txtAddress.Text);
            dgvSinhVien.DataSource = lst;
            dgvSinhVien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSinhVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dgvSinhVien.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dgvSinhVien.Columns[i].Width;

                // Remove AutoSizing:
                dgvSinhVien.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dgvSinhVien.Columns[i].Width = colw;
            }
            lblTong.Text = dgvSinhVien.Rows.Count + "";
        }
    }
}
