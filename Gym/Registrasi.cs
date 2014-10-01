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
    public partial class Registrasi : Form
    {
        DatabaseModel db_model;
        DataTable dataTable;
        public Registrasi()
        {
            InitializeComponent();
            db_model = new DatabaseModel();
            dataTable = new DataTable();
        }

        private void Registrasi_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            DateTime tanggal = DateTime.Today;
            string format = "yyyy-MM-dd";
            var mytime = tanggal.ToString(format);
            label6.Text = mytime;
            dataTable = db_model.getData("master_paket");
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "deskripsi_paket";
            comboBox1.ValueMember = "lama_waktu";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "flexible")
            {
                label18.Visible = true;
                label17.Visible = true;
                textBox5.Visible = true;
                dateTimePicker1.Format = DateTimePickerFormat.Short;
                dateTimePicker1.Visible = true;
                string format = "yyyy-MM-dd";
                label7.Text = dateTimePicker1.Value.ToString(format);
            }
            else
            {
                int index = comboBox1.SelectedIndex;
                int bulan = int.Parse(dataTable.Rows[index][2].ToString());
                DateTime selesai = DateTime.Today;
                string format = "yyyy-MM-dd";
                selesai = selesai.AddMonths(bulan);
                label7.Text = selesai.ToString(format);
                label18.Visible = false;
                label17.Visible = false;
                textBox5.Visible = false;
                dateTimePicker1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "insert into master_member (nama, alamat, pekerjaan, no_telp, tanggal_mulai, tanggal_selesai)" +
                           "values('"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+label6.Text.ToString()+"','"+label7.Text.ToString()+"')";
            Pembayaran bayar = new Pembayaran(query);
            this.Hide();
            bayar.Show();
        }
    }
}
