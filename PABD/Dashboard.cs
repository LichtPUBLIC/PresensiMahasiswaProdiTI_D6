using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PABD
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Form load logic (kosongkan dulu jika belum perlu)
        }

        private void btnDataMahasiswa_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            kelola_Data_Mahasiswa form = new kelola_Data_Mahasiswa();
            form.Show();
        }



        private void btnDataMatakuliah_Click(object sender, EventArgs e)
        {
            this.Hide();    
            kelola_Data_Matakuliah form = new kelola_Data_Matakuliah();
            form.Show();
        }

        private void btnDataJadwal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kelola_Data_Jadwal form = new Kelola_Data_Jadwal();
            form.Show();
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kelola_Data_Presensi form = new Kelola_Data_Presensi();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kelola_Data_Dosen form = new Kelola_Data_Dosen();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // sembunyikan dashboard
                Login login = new Login();
                login.Show();
            }
        }

    }
}
