using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class MasterPaket : Form
    {
        DatabaseModel db_model;
        DataTable dataTable;
        int rowBefore, rowAktif;
        public MasterPaket()
        {
            InitializeComponent();
            db_model = new DatabaseModel();
            dataTable = new DataTable();
        }

        private void MasterPaket_Load(object sender, EventArgs e)
        {
            dataTable = db_model.getData("master_paket");
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != rowBefore)
                dataGridView1.ReadOnly = true;
            rowAktif = e.RowIndex;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[rowBefore].Cells[i].Style.BackColor = Color.Empty;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightGray;
            rowBefore = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            groupBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(numericUpDown1.Value.ToString()) == 0 || textBox1.Text.ToString().Equals("") || textBox2.Text.ToString().Equals(""))
            {
                MessageBox.Show("Harap isi semua field!");
            }
            else
            {
                db_model.insertPaket(textBox1.Text.ToString(), numericUpDown1.Value.ToString(), textBox2.Text.ToString());
                groupBox1.Visible = false;
                button4.Visible = false;
                textBox1.Clear();
                numericUpDown1.Value = 0;
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String idPaket = dataGridView1.Rows[rowAktif].Cells[0].Value.ToString();
            if (MessageBox.Show("Hapus paket dengan id "+ idPaket +"?", "Delete Paket", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db_model.deletePaket(idPaket);
                dataTable = db_model.getData("master_paket");
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
