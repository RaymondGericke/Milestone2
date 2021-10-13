using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // and Sebastian_Marnewick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            //Executes login procedures
            string Username, Password;
            bool Valid;
            Username = textBox1.Text;
            Password = textBox2.Text;
            FileHandler handler = new FileHandler();

            bool Access = handler.LoginUser(Username, Password);
            if (Access == true)
            {
                MessageBox.Show(Username + " has been logged in!");
                var StudentPortal = new StudentPortal();
                StudentPortal.Show();
            }
            else
            {
                MessageBox.Show("Username and Password does not match!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            //Opens second form

            //hides LOGIN form for the love of cheese
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Username, Password;
            Username = textBox1.Text;
            Password = textBox2.Text;
            FileHandler handler = new FileHandler();
            label5.Text = handler.AddUser(Username, Password);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
