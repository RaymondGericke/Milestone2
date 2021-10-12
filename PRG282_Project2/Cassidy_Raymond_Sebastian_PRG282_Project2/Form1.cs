using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2
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
            Valid = handler.Login(Username, Password);

            if (Valid == true)
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
            label1.Text = handler.Register(Username, Password);
        }
    }
}
