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
    public partial class Form10 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form10()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Penjualan(Id_Toko, kd_barang, Jmlh_barang, Id_penjualan, hrg_jual)" +
            "VALUES (@Id_Toko, @kd_barang, @Jmlh_barang, @Id_penjualan, @hrg_jual)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Toko", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@Id_penjualan", textBox4.Text);
            command.Parameters.AddWithValue("@Jmlh_barang", textBox3.Text);
            command.Parameters.AddWithValue("@hrg_jual", textBox2.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table Penjualan created successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Penjualan SET Id_Toko = @Id_Toko, kd_barang = @kd_barang, Jmlh_barang = @Jmlh_barang, hrg_jual = @hrg_jual WHERE Id_penjualan = @Id_penjualan";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Toko", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@Id_penjualan", textBox4.Text);
            command.Parameters.AddWithValue("@Jmlh_barang", textBox3.Text);
            command.Parameters.AddWithValue("@hrg_jual", textBox2.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Penjualan updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Penjualan WHERE Id_penjualan = @Id_penjualan";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id_penjualan = @Id_penjualan", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Penjualan WHERE Id_penjualan = @Id_penjualan";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id_penjualan = @Id_penjualan", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Penjualan deleted successfully.");
        }
    }
}
