using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=DESKTOP-AGMBOPH\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True";

        public Form4()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title, Author) VALUES (@t, @a)", conn);
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@a", txtAuthor.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Kitap eklendi.");
                this.Close();
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
