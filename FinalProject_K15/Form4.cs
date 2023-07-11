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

namespace FinalProject_K15
{
    public partial class Form4 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form4()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Handphone (kd_barang,nm_barang,hrg_jual,hrg_beli,active) " +
            "VALUES (@kd_barang,@nm_barang,@hrg_jual,@hrg_beli,@active)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@nm_barang", textBox4.Text);
            command.Parameters.AddWithValue("@hrg_jual", textBox3.Text);
            command.Parameters.AddWithValue("@hrg_beli", textBox5.Text);
            command.Parameters.AddWithValue("@active", textBox2.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table barang created successfully.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Handphone SET nm_barang = @nm_barang,hrg_jual = @hrg_jual, hrg_beli = @hrg_beli, active = @active WHERE kd_barang = @kd_barang";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@nm_barang", textBox4.Text);
            command.Parameters.AddWithValue("@hrg_jual", textBox3.Text);
            command.Parameters.AddWithValue("@hrg_beli", textBox5.Text);
            command.Parameters.AddWithValue("@active", textBox2.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Barang updated successfully.");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Handphone WHERE kd_barang = @kd_barang";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kd_barang", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Barang deleted successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Handphone WHERE kd_barang = @kd_barang";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kd_barang", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
