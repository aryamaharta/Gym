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
    public partial class Form1 : Form
    {
        DatabaseModel db_model;
        String username, passwd, status;
        DataTable dataTable;
        public Form1()
        {
            db_model = new DatabaseModel();
            dataTable = new DataTable();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text.ToString();
            passwd = textBox2.Text.ToString();
            status = db_model.login(username, passwd);
            if (status.Equals("1"))
            {
                dataTable = db_model.getDataWhere("master_staf", "username", username);
                MessageBox.Show("Selamat datang admin "+ dataTable.Rows[0][1].ToString());
                FormMain main = new FormMain(dataTable.Rows[0][1].ToString(), dataTable.Rows[0][0].ToString());
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
