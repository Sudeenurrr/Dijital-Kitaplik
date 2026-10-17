using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-AGMBOPH\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    new Form2().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı giriş.");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi girin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Users WHERE Username = @u AND Password = @p";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı veya bilgiler hatalı.");
                }
            }
        }
    }
}
