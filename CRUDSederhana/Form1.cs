using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUDSederhana
{
    public partial class Form1 : Form
    {
       
        private string connectionString = "Data Source=LAPTOP-M2UCAR4E\\SHIDQUL;Initial Catalog=OrganisasiMahasisma;Integrated Security=True";


        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        
        private void ClearForm()
        {
            txtNIM.Clear(); // Mengosongkan TextBox NIM
            txtNama.Clear(); // Mengosongkan TextBox Nama
            txtEmail.Clear(); // Mengosongkan TextBox Email
            txtTelepon.Clear(); // Mengosongkan TextBox Telepon
            txtAlamat.Clear(); // Mengosongkan TextBox Alamat

            txtNIM.Focus(); // Fokus kembali ke TextBox NIM
        }

        // Fungsi untuk menampilkan data di DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // Membuka koneksi ke database
                    string query = "SELECT NIM AS [NIM], Nama, Email, Telepon, Alamat FROM Mahasiswa"; // Query untuk mengambil data
                    SqlDataAdapter da = new SqlDataAdapter(query, conn); // Menggunakan SqlDataAdapter untuk mengisi DataTable
                    DataTable dt = new DataTable(); // Membuat DataTable untuk menyimpan data
                    da.Fill(dt); // Mengisi DataTable dengan data dari database
                    dgvMahasiswa.AutoGenerateColumns = true; // Mengatur kolom DataGridView agar dihasilkan otomatis
                    dgvMahasiswa.DataSource = dt; // Menghubungkan DataGridView dengan DataTable
                    ClearForm(); // Mengosongkan form setelah data dimuat
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Masalah", MessageBoxButtons.OK, MessageBoxIcon.Error); // Menampilkan pesan error
                }
            }
        }

        // Fungsi untuk menambahkan data (CREATE)
        private void BtnTambah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Validasi input
                    if (txtNIM.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtTelepon.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open(); // Membuka koneksi ke database
                    string query = "INSERT INTO Mahasisma (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)"; // Query untuk menambahkan data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Menambahkan parameter ke query
                        cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery(); // Menjalankan query
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information); // Pesan sukses
                            LoadData(); // Memuat ulang data
                            ClearForm(); // Mengosongkan form
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan!", "Masalah", MessageBoxButtons.OK, MessageBoxIcon.Error); // Pesan error
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Masalah", MessageBoxButtons.OK, MessageBoxIcon.Error); // Menampilkan pesan error
                }
            }
        }

        // Fungsi untuk menghapus data (DELETE)
        private void BtnHapus(object sender, EventArgs e)
        {
            if (dgvMahasiswa.SelectedRows.Count > 0) // Memeriksa apakah ada baris yang dipilih
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Konfirmasi penghapusan
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string nim = dgvMahasiswa.SelectedRows[0].Cells["NIM"].Value.ToString(); // Mengambil NIM dari baris yang dipilih
                            conn.Open(); // Membuka koneksi ke database
                            string query = "DELETE FROM Mahasisma WHERE NIM = @NIM"; // Query untuk menghapus data
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@NIM", nim); // Menambahkan parameter ke query
                                int rowsAffected = cmd.ExecuteNonQuery(); // Menjalankan query
                                if (rowsAffected > 0)
                                {
                                    