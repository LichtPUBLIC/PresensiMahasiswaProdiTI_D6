using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABD
{
    public partial class kelola_Data_Mahasiswa : Form
    {
        private string connectionString = "Data Source=MSI\\DAFFAALYANDRA;Initial Catalog=PresensiMahasiswaProdiTI;Integrated Security=True;";

        public kelola_Data_Mahasiswa()
        {
            InitializeComponent();
            this.Load += kelola_Data_Mahasiswa_Load; // pastikan event Load dihubungkan
        }

        private void kelola_Data_Mahasiswa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtAngkatan.Clear();
            txtSemester.Clear();
            txtNIM.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT nim AS [NIM], nama_mhs AS [Nama], kelas AS [Kelas], angkatan AS [Angkatan], semester AS [Semester] FROM Mahasiswa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMahasiswa.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            if (txtNIM.Text == "" || txtNama.Text == "" || txtKelas.Text == "" || txtAngkatan.Text == "" || txtSemester.Text == "")
            {
                MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Mahasiswa (nim, nama_mhs, kelas, angkatan, semester) VALUES (@nim, @nama, @kelas, @angkatan, @semester)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nim", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", txtKelas.Text.Trim());
                    cmd.Parameters.AddWithValue("@angkatan", int.Parse(txtAngkatan.Text.Trim()));
                    cmd.Parameters.AddWithValue("@semester", int.Parse(txtSemester.Text.Trim()));
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

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (dgvMahasiswa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            string nim = dgvMahasiswa.SelectedRows[0].Cells["NIM"].Value.ToString();
            DialogResult result = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Mahasiswa WHERE nim = @nim";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nim", nim);
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

        private void btnUbah_Click_1(object sender, EventArgs e)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Mahasiswa SET nama_mhs = @nama, kelas = @kelas, angkatan = @angkatan, semester = @semester WHERE nim = @nim";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nim", txtNIM.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", txtKelas.Text.Trim());
                    cmd.Parameters.AddWithValue("@angkatan", int.Parse(txtAngkatan.Text.Trim()));
                    cmd.Parameters.AddWithValue("@semester", int.Parse(txtSemester.Text.Trim()));
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

        private void dgvMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMahasiswa.Rows[e.RowIndex];
                txtNIM.Text = row.Cells["NIM"].Value.ToString();
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtKelas.Text = row.Cells["Kelas"].Value.ToString();
                txtAngkatan.Text = row.Cells["Angkatan"].Value.ToString();
                txtSemester.Text = row.Cells["Semester"].Value.ToString();
            }
        }
    }
}
