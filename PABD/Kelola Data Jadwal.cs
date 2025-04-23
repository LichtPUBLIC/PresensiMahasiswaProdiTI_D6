using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABD
{
    public partial class Kelola_Data_Jadwal : Form
    {
        private string connectionString = "Data Source=MSI\\DAFFAALYANDRA;Initial Catalog=PresensiMahasiswaProdiTI;Integrated Security=True;";

        public Kelola_Data_Jadwal()
        {
            InitializeComponent();
            Load += Kelola_Data_Jadwal_Load;
        }

        private void Kelola_Data_Jadwal_Load(object sender, EventArgs e)
        {
            LoadData();

            cmbHari.Items.Clear();
            cmbHari.Items.AddRange(new string[] { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu" });
            cmbHari.SelectedIndex = 0; // Pilih default, misal Senin
        }


        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_jadwal AS [ID Jadwal], kode_mk AS [Kode MK], hari AS [Hari], jam_mulai AS [Jam Mulai], jam_selesai AS [Jam Selesai] FROM JadwalKuliah";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtIdJadwal.Clear();
            txtKodeMK.Clear();
            cmbHari.SelectedIndex = 0;
            dtpMulai.Value = DateTime.Now;
            dtpSelesai.Value = DateTime.Now;
            txtIdJadwal.Focus();
        }


        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string hari = cmbHari.SelectedItem.ToString();
                    string query = "INSERT INTO JadwalKuliah (id_jadwal, kode_mk, hari, jam_mulai, jam_selesai) VALUES (@id, @kode, @hari, @mulai, @selesai)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtIdJadwal.Text.Trim());
                    cmd.Parameters.AddWithValue("@kode", txtKodeMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@hari", hari);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.TimeOfDay);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan.");
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string hari = cmbHari.SelectedItem.ToString();
                    string query = "UPDATE JadwalKuliah SET kode_mk=@kode, hari=@hari, jam_mulai=@mulai, jam_selesai=@selesai WHERE id_jadwal=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtIdJadwal.Text.Trim());
                    cmd.Parameters.AddWithValue("@kode", txtKodeMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@hari", hari);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.TimeOfDay);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah.");
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
            if (dgvJadwal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            string idJadwal = dgvJadwal.SelectedRows[0].Cells["ID Jadwal"].Value.ToString();
            DialogResult result = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM JadwalKuliah WHERE id_jadwal = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idJadwal);
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

        private void dgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvJadwal.Rows[e.RowIndex];
                txtIdJadwal.Text = row.Cells["ID Jadwal"].Value.ToString();
                txtKodeMK.Text = row.Cells["Kode MK"].Value.ToString();
                cmbHari.SelectedItem = row.Cells["Hari"].Value.ToString();
                dtpMulai.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells["Jam Mulai"].Value.ToString()));
                dtpSelesai.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells["Jam Selesai"].Value.ToString()));
            }
        }

        private void dtpHari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
