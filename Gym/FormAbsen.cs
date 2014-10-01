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
    public partial class FormAbsen : Form
    {
        DatabaseModel db_model;
        DataTable dataTable;
        public FormAbsen()
        {
            //label1.Visible = false;
            //label2.Visible = false;
            db_model = new DatabaseModel();
            dataTable = new DataTable();
            InitializeComponent();
        }

        private void FormAbsen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label1.Visible = true;
                label2.Visible = true;
                String id = textBox1.Text.ToString();
                DateTime waktu = DateTime.Now;
                dataTable = db_model.loginMember(waktu.ToString("yyyy-MM-dd"), id);
                if (dataTable.Rows[0][7].ToString() == "tidak")
                {
                    label1.Text = "Anda tidak diijinkan masuk!";
                    label2.Text = "Periksa kembali masa berlaku keanggotaan atau masa cuti anda";
                }
                else if (dataTable.Rows[0][7].ToString() == "masuk")
                {
                    label1.Text = "Selamat datang kembali " + dataTable.Rows[0][1].ToString();
                    label2.Text = "";
                }
            }
        }
    }
}
