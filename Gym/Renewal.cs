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
    public partial class Renewal : Form
    {
        public Renewal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pembayaran bayar = new Pembayaran("");
            this.Hide();
            bayar.Show();
        }

        private void Renewal_Load(object sender, EventArgs e)
        {
            DateTime tanggal = DateTime.Today;
            label6.Text = tanggal.ToShortDateString();
        }
    }
}
