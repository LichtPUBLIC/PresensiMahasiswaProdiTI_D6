namespace PABD
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDataMahasiswa = new System.Windows.Forms.Button();
            this.btnDataMatakuliah = new System.Windows.Forms.Button();
            this.btnDataJadwal = new System.Windows.Forms.Button();
            this.btnPresensi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDataMahasiswa
            // 
            this.btnDataMahasiswa.BackColor = System.Drawing.SystemColors.Info;
            this.btnDataMahasiswa.Location = new System.Drawing.Point(311, 130);
            this.btnDataMahasiswa.Name = "btnDataMahasiswa";
            this.btnDataMahasiswa.Size = new System.Drawing.Size(192, 37);
            this.btnDataMahasiswa.TabIndex = 4;
            this.btnDataMahasiswa.Text = "Data Mahasiswa";
            this.btnDataMahasiswa.UseVisualStyleBackColor = false;
            this.btnDataMahasiswa.Click += new System.EventHandler(this.btnDataMahasiswa_Click);
            // 
            // btnDataMatakuliah
            // 
            this.btnDataMatakuliah.BackColor = System.Drawing.SystemColors.Info;
            this.btnDataMatakuliah.Location = new System.Drawing.Point(311, 216);
            this.btnDataMatakuliah.Name = "btnDataMatakuliah";
            this.btnDataMatakuliah.Size = new System.Drawing.Size(192, 35);
            this.btnDataMatakuliah.TabIndex = 5;
            this.btnDataMatakuliah.Text = "Data Matakuliah";
            this.btnDataMatakuliah.UseVisualStyleBackColor = false;
            this.btnDataMatakuliah.Click += new System.EventHandler(this.btnDataMatakuliah_Click);
            // 
            // btnDataJadwal
            // 
            this.btnDataJadwal.BackColor = System.Drawing.SystemColors.Info;
            this.btnDataJadwal.Location = new System.Drawing.Point(311, 296);
            this.btnDataJadwal.Name = "btnDataJadwal";
            this.btnDataJadwal.Size = new System.Drawing.Size(192, 33);
            this.btnDataJadwal.TabIndex = 6;
            this.btnDataJadwal.Text = "Data Jadwal";
            this.btnDataJadwal.UseVisualStyleBackColor = false;
            this.btnDataJadwal.Click += new System.EventHandler(this.btnDataJadwal_Click);
            // 
            // btnPresensi
            // 
            this.btnPresensi.BackColor = System.Drawing.SystemColors.Info;
            this.btnPresensi.Location = new System.Drawing.Point(311, 257);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(192, 33);
            this.btnPresensi.TabIndex = 7;
            this.btnPresensi.Text = "Presensi";
            this.btnPresensi.UseVisualStyleBackColor = false;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(311, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Data Dosen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "PILIH KATEGORI";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Info;
            this.btnLogout.Location = new System.Drawing.Point(311, 335);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(192, 33);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPresensi);
            this.Controls.Add(this.btnDataJadwal);
            this.Controls.Add(this.btnDataMatakuliah);
            this.Controls.Add(this.btnDataMahasiswa);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDataMahasiswa;
        private System.Windows.Forms.Button btnDataMatakuliah;
        private System.Windows.Forms.Button btnDataJadwal;
        private System.Windows.Forms.Button btnPresensi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
    }
}