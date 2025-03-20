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
                    