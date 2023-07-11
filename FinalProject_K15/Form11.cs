using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Windows.Input;
using System.Collections;
using System.Net.NetworkInformation;

namespace FinalProject_K15
{
    public partial class Form11 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form11()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO  Pembayaran(Id_Pelanggan, kd_barang, id_pembayaran, Tgl_Bayar, nm_barang, total_hrg, jenis_pembayaran)" +
            "VALUES (@Id_Pelanggan, @kd_barang, @id_pembayaran, @Tgl_Bayar, @nm_barang, @total_hrg, @jenis_pembayaran)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Pelanggan", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@id_pembayaran", textBox4.Text);
            command.Parameters.AddWithValue("@Tgl_Bayar", textBox3.Text);
            command.Parameters.AddWithValue("@nm_barang", textBox2.Text);
            command.Parameters.AddWithValue("@total_hrg", textBox6.Text);
            command.Parameters.AddWithValue("@jenis_pembayaran", textBox7.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table Pembayaran created successfully.");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Pembayaran SET Id_Pelanggan = @Id_Pelanggan, kd_barang = @kd_barang, Tgl_Bayar = @Tgl_Bayar, nm_barang = @nm_barang, total_hrg = @total_hrg, jenis_pembayaran = @jenis_pembayaran WHERE id_pembayaran= @id_pembayaran";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Pelanggan", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@id_pembayaran", textBox4.Text);
            command.Parameters.AddWithValue("@Tgl_Bayar", textBox3.Text);
            command.Parameters.AddWithValue("@nm_barang", textBox2.Text);
            command.Parameters.AddWithValue("@total_hrg", textBox6.Text);
            command.Parameters.AddWithValue("@jenis_pembayaran", textBox7.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Pembayaran updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Pembayaran WHERE id_pembayaran= @id_pembayaran";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id_pembayaran= @id_pembayaran", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Pembayaran WHERE id_pembayaran= @id_pembayaran";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id_pembayaran= @id_pembayaran", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Pembayaran deleted successfully.");
        }
    }
}
