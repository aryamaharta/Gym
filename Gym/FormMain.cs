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
    public partial class FormMain : Form
    {
        String admin, id;
        public FormMain(String admin, String id)
        {
            this.admin = admin;
            this.id = id;
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            toolStripStatusLabel1.Text = "admin : " + admin + "(" + id + ")";
            statusStrip1.Refresh();
        }

        private void registrasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrasi formRegistrasi = new Registrasi();
            formRegistrasi.Show();
        }

        private void perpanjanganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renewal formRenewal = new Renewal();
            formRenewal.Show();
        }

        private void pemasukanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPemasukan reportPemasukan = new ReportPemasukan();
            reportPemasukan.Show();
        }

        private void absensiMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAbsensi reportAbsensi = new ReportAbsensi();
            reportAbsensi.Show();
        }

        private void editMasterPaketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterPaket masterPaket = new MasterPaket();
            masterPaket.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Keluar dari aplikasi?", "Keluar", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else 
            {
                
            }
        }

        private void absensiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbsen absen = new FormAbsen();
            absen.Show();
        }

    }
}
