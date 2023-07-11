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
    public partial class Form3 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form3()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Pelanggan (Id_Pelanggan, Nm_Pelanggan, nohp_Pelanggan, almt_Pelanggan) " +
            "VALUES (@Id_Pelanggan, @Nm_Pelanggan, @nohp_Pelanggan, @almt_Pelanggan)";


            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Pelanggan", textBox1.Text);
            command.Parameters.AddWithValue("@Nm_Pelanggan", textBox4.Text);
            command.Parameters.AddWithValue("@nohp_Pelanggan", textBox3.Text);
            command.Parameters.AddWithValue("@almt_Pelanggan", textBox2.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table pelanggan created successfully.");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Pelanggan SET Nm_Pelanggan = @Nm_Pelanggan, nohp_Pelanggan = @nohp_Pelanggan, almt_Pelanggan = @almt_Pelanggan WHERE Id_Pelanggan = @Id_Pelanggan";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nm_Pelanggan", textBox4.Text);
            command.Parameters.AddWithValue("@nohp_Pelanggan", textBox3.Text);
            command.Parameters.AddWithValue("@almt_Pelanggan", textBox2.Text);
            command.Parameters.AddWithValue("@Id_Pelanggan", textBox1.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data pelanggan updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Pelanggan WHERE Id_Pelanggan = @Id_Pelanggan";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Pelanggan", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Pelanggan WHERE Id_Pelanggan = @Id_Pelanggan";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_Pelanggan", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Pelanggan deleted successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }
    }
}
