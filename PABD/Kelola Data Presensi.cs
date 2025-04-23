using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABD
{
    public partial class Kelola_Data_Presensi : Form
    {
        private string connectionString = "Data Source=MSI\\DAFFAALYANDRA;Initial Catalog=PresensiMahasiswaProdiTI;Integrated Security=True;";

        public Kelola_Data_Presensi()
        {
            InitializeComponent();
            Load += Kelola_Data_Presensi_Load;
        }

        private void Kelola_Data_Presensi_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Hadir", "Tidak Hadir", "Izin", "Sakit" });
            cmbStatus.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_presensi AS [ID Presensi], tanggal AS [Tanggal], status AS [Status], nim AS [NIM], id_jadwal AS [ID Jadwal] FROM Presensi";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPresensi.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtIdPresensi.Clear();
            txtNIM.Clear();
            txtIDJadwal.Clear();
            cmbStatus.SelectedIndex = 0;
            dtpTanggal.Value = DateTime.Now;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Presensi (tanggal, status, nim, id_jadwal) VALUES (@tanggal, @status, @nim, @id_jadwal)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value.Date);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@nim", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_jadwal", txtIDJadwal.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data presensi berhasil ditambahkan.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Presensi (tanggal, status, nim, id_jadwal) VALUES (@tanggal, @status, @nim, @id_jadwal)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value.Date);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@nim", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_jadwal", txtIDJadwal.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data presensi berhasil ditambahkan.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPresensi.Text))
            {
                MessageBox.Show("Pilih data yang akan diedit.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Presensi SET tanggal = @tanggal, status = @status, nim = @nim, id_jadwal = @id_jadwal WHERE id_presensi = @id_presensi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value.Date);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@nim", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_jadwal", txtIDJadwal.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_presensi", txtIdPresensi.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diperbarui.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPresensi.Text))
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Presensi WHERE id_presensi = @id_presensi";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_presensi", txtIdPresensi.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadData();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnRefres_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // atau this.Close();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
