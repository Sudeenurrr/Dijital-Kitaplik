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
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=DESKTOP-AGMBOPH\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True";
        public Form2()
        {
            InitializeComponent();
            LoadBooks();
        }
        private void LoadBooks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBooks.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books WHERE Title LIKE @t", conn);
                da.SelectCommand.Parameters.AddWithValue("@t", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBooks.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    DialogResult dr = MessageBox.Show("Kitap bulunamadı. Eklemek ister misiniz?", "Yok", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        new Form4().ShowDialog();
                        LoadBooks();
                    }
                }
            }
        }

        private void btnBarrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["BookId"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IsBorrowed FROM Books WHERE BookId=@id", conn);
                cmd.Parameters.AddWithValue("@id", bookId);
                bool borrowed = Convert.ToBoolean(cmd.ExecuteScalar());

                if (borrowed)
                {
                    MessageBox.Show("Bu kitap zaten alınmış.");
                    return;
                }

                DateTime now = DateTime.Now;
                DateTime due = now.AddDays(7);
                SqlCommand update = new SqlCommand("UPDATE Books SET IsBorrowed=1, BorrowedDate=@b, ReturnDate=@r WHERE BookId=@id", conn);
                update.Parameters.AddWithValue("@b", now);
                update.Parameters.AddWithValue("@r", due);
                update.Parameters.AddWithValue("@id", bookId);
                update.ExecuteNonQuery();

                MessageBox.Show($"Teslim tarihi: {due.ToShortDateString()}");
                LoadBooks();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int bookId = (int)dataGridViewBooks.SelectedRows[0].Cells["BookId"].Value;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Books SET IsBorrowed=0, BorrowedDate=NULL, ReturnDate=NULL WHERE BookId=@id", conn);
                cmd.Parameters.AddWithValue("@id", bookId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Kitap teslim edildi.");
                LoadBooks();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["BookId"].Value);

            DialogResult result = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?", "Onayla", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookId = @id", conn);
                    cmd.Parameters.AddWithValue("@id", bookId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kitap silindi.");
                LoadBooks();
            }
        }

        private void btnSon_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form1 form1 = new Form1(); 
            form1.Show(); 
        }
    }
}
