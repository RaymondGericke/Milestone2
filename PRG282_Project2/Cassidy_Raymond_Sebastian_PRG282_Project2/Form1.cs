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
            FileHandler handler = new FileHandler();
            handler.Login();

            //Opens second form
            var StudentPortal = new StudentPortal();
            StudentPortal.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username, password;
            Console.WriteLine("Please enter a username: ");
            username = Console.ReadLine();
            //Validation code for incase username exists already
            Console.WriteLine("Please enter a password: ");
            password = Console.ReadLine();
            
            //Save user to file
        }
    }
}
