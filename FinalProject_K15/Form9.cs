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
    public partial class Form9 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        public Form9()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-OO0RTBGO\\SOFIMIRANDA;Initial Catalog=FinalProject;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Supply (Id_supplier,kd_barang,nm_toko,almt_toko,Jmlh_barang) " +
            "VALUES (@Id_supplier, @kd_barang, @nm_toko, @almt_toko, @Jmlh_barang)";


            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@nm_toko", textBox4.Text);
            command.Parameters.AddWithValue("@almt_toko", textBox3.Text);
            command.Parameters.AddWithValue("@Jmlh_barang", textBox2.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Table Pembelian created successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Supply SET kd_barang = @kd_barang, nm_toko = @nm_toko, almt_toko = @almt_toko,Jmlh_barang= @Jmlh_barang WHERE Id_supplier = @Id_supplier";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id_supplier", textBox5.Text);
            command.Parameters.AddWithValue("@kd_barang", textBox1.Text);
            command.Parameters.AddWithValue("@nm_toko", textBox4.Text);
            command.Parameters.AddWithValue("@almt_toko", textBox3.Text);
            command.Parameters.AddWithValue("@Jmlh_barang", textBox2.Text);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Pembelian updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Supply WHERE Id_supplier = @Id_supplier";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id_supplier = @Id_supplier", button2.Text);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(btndelete.Text);
            string query = "DELETE FROM Supply WHERE Id_supplier = @Id_supplier";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id_supplier = @Id_supplier", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Pembelian deleted successfully.");
        }
    }
    
}
