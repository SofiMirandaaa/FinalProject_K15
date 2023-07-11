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
    public partial class Form6 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form6()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Toko WHERE id_Toko = @id_Toko";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_Toko", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Toko deleted successfully.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Toko SET almt_Toko = @almt_Toko,nm_toko = @nm_toko,tlp_Toko = @tlp_Toko WHERE id_Toko = @id_Toko";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_Toko", textBox1.Text);
            command.Parameters.AddWithValue("@almt_Toko", textBox5.Text);
            command.Parameters.AddWithValue("@nm_toko", textBox4.Text);
            command.Parameters.AddWithValue("@tlp_Toko", textBox3.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Toko updated successfully.");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Toko (id_Toko,almt_Toko,nm_toko,tlp_Toko) " +
           "VALUES (@id_Toko,@almt_Toko,@nm_toko,@tlp_Toko)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_Toko", textBox1.Text);
            command.Parameters.AddWithValue("@almt_Toko", textBox5.Text);
            command.Parameters.AddWithValue("@nm_toko", textBox4.Text);
            command.Parameters.AddWithValue("@tlp_Toko", textBox3.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table Toko created successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Toko WHERE id_Toko = @id_Toko";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_Toko", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
