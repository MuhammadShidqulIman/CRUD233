using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUDSederhana
{
    public partial class Form1 : Form
    {
        // String koneksi ke database SQL Server
        private string connectionString = "Data Source=LAPTOP-M2UCAR4E\\SHIDQUL;Initial Catalog=OrganisasiMahasisma;Integrated Security=True";
