using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_K15
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 nextForm = new Form4();
            nextForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 nextForm = new Form5();
            nextForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 nextForm = new Form3();
            nextForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 nextForm = new Form6();
            nextForm.Show();
        }
    }
}
