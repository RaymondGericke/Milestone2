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
using System.IO;


namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2
{
    public partial class StudentPortal : Form
    {
        DataHandler handler = new DataHandler();

        string id, name, surname, image, birth, Gender, phone, address, Modcodes;

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
            //Deleting a student with appropriate message
            if (handler.Delete(int.Parse(id)))
            {
                MessageBox.Show($"Deleted details of student number: {int.Parse(id)}");
            }
        }

        private void alterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opening Create student form to update data fully
            var StudentCreate = new StudentCreate();
            StudentCreate.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //On change event for more efficiently searching for students
            dataGridView1.DataSource = handler.searchData(int.Parse(textBox1.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                //Assigning values to variables from selected row in datagridview
                id = row.Cells["StudentNumber"].Value.ToString();
                name = row.Cells["sName"].Value.ToString();
                surname = row.Cells["Surname"].Value.ToString();
                image = row.Cells["StudentIMG"].Value.ToString();
                birth = row.Cells["DOB"].Value.ToString();
                Gender = row.Cells["GENDER"].Value.ToString();
                phone = row.Cells["PhoneNo"].Value.ToString();
                address = row.Cells["Address"].Value.ToString();
                Modcodes = row.Cells["StudentIMG"].Value.ToString();

            }
        }
        public void DataGrid(string id, string name, string surname, string image, string birth, string Gender, string phone, string address, string Modcodes;)
        { 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.displayStudents();
        }

        private void StudentPortal_Load(object sender, EventArgs e)
        {
            
        }
    }
}
