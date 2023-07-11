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
    public partial class Form5 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form5()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
            string query = @"INSERT INTO Supplier(Id_supplier,Nm_supplier,alamat,telp_supplier)" +
            "VALUES (@Id_supplier,@Nm_supplier,@alamat,@telp_supplier)";


            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", textBox1.Text);
            command.Parameters.AddWithValue("@Nm_supplier", textBox4.Text);
            command.Parameters.AddWithValue("@alamat", textBox2.Text);
            command.Parameters.AddWithValue("@telp_supplier", textBox3.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table supplier created successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Supplier SET Nm_supplier = @Nm_supplier, alamat = @alamat, telp_supplier = @telp_supplier WHERE Id_supplier = @Id_supplier";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", textBox1.Text);
            command.Parameters.AddWithValue("@Nm_supplier", textBox4.Text);
            command.Parameters.AddWithValue("@alamat", textBox2.Text);
            command.Parameters.AddWithValue("@telp_supplier", textBox3.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Supplier updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Supplier WHERE Id_supplier = @Id_supplier";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Supplier WHERE Id_supplier = @Id_supplier";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Supplier deleted successfully.");
        }
    }
}
