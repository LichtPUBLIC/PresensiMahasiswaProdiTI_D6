using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABD
{
    public partial class kelola_Data_Matakuliah : Form
    {
        private string connectionString = "Data Source=MSI\\DAFFAALYANDRA;Initial Catalog=PresensiMahasiswaProdiTI;Integrated Security=True;";

        public kelola_Data_Matakuliah()
        {
            InitializeComponent();
            this.Load += kelola_Data_MataKuliah_Load;
        }

        private void kelola_Data_MataKuliah_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearForm()
        {
            txtKodeMK.Clear();
            txtNamaMK.Clear();
            txtIDDosen.Clear();
            txtKodeMK.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT kode_mk AS [Kode MK], nama_mk AS [Nama Mata Kuliah], id_dosen AS [ID Dosen] FROM MataKuliah";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMataKuliah.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            if (txtKodeMK.Text == "" || txtNamaMK.Text == "" || txtIDDosen.Text == "")
            {
                MessageBox.Show("Harap isi semua data!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO MataKuliah (kode_mk, nama_mk, id_dosen) VALUES (@kode_mk, @nama_mk, @id_dosen)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kode_mk", txtKodeMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama_mk", txtNamaMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_dosen", txtIDDosen.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil ditambahkan!");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE MataKuliah SET nama_mk = @nama_mk, id_dosen = @id_dosen WHERE kode_mk = @kode_mk";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kode_mk", txtKodeMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama_mk", txtNamaMK.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_dosen", txtIDDosen.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diubah!");
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
            if (dgvMataKuliah.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            string kodeMK = dgvMataKuliah.SelectedRows[0].Cells["Kode MK"].Value.ToString();
            DialogResult result = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM MataKuliah WHERE kode_mk = @kode_mk";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@kode_mk", kodeMK);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil dihapus!");
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMataKuliah.Rows[e.RowIndex];
                txtKodeMK.Text = row.Cells["Kode MK"].Value.ToString();
                txtNamaMK.Text = row.Cells["Nama Mata Kuliah"].Value.ToString();
                txtIDDosen.Text = row.Cells["ID Dosen"].Value.ToString();
            }
        }

        private void kelola_Data_Matakuliah_Load_1(object sender, EventArgs e)
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
