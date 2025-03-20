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
      