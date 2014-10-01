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
    public partial class Pembayaran : Form
    {
        DatabaseModel db_model;
        String queryInsert;
        int pilihan = 0;
        public Pembayaran(String query)
        {
            db_model = new DatabaseModel();
            queryInsert = query;
            InitializeComponent();
            groupBox1.Visible = false;
            panel1.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.LightGray;
            groupBox1.Visible = false;
            pilihan = 1;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.White;
            panel1.BackColor = Color.LightGray;
            groupBox1.Visible = true;
            pilihan = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pilihan == 0)
            {
                MessageBox.Show("Pilih salah satu metode pembayaran");
            }
            else
            {
                db_model.addMember(queryInsert);
                this.Close();
            }
        }
    }
}
