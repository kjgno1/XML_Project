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

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            LoadSV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
