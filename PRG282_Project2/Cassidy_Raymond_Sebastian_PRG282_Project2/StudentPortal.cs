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


namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2
{
    public partial class StudentPortal : Form
    {
        DataHandler handler = new DataHandler();

        public StudentPortal()
        {
            InitializeComponent();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void alterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.searchData(int.Parse(textBox1.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
