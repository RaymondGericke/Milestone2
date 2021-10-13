using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // and Sebastian_Marnewick
{
    public partial class StudentCreate : Form
    {
        DataHandler handler = new DataHandler();

        string GENDER;

        public string folderPath { get; private set; }

        public StudentCreate()
        {
            InitializeComponent();
        }

        private void StudentCreate_Load(object sender, EventArgs e)
        {
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                GENDER = "Male";
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    GENDER = "Female";
                }
            }
            //string DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //string ModCodes = comboBox1.Text;

            
            //Raymond Version of StudentCreate
            //int StudentNummber, string Name, string Surname, string StudentIMG, DateTime DOB, string GENDER, string PhoneNo, string Address, string ModCodes
            handler.insertData(int.Parse(textBox1.Text), //ID
                               textBox2.Text, //Name
                               textBox3.Text, //Surname
                               textBox4.Text, //IMG ID
                               dateTimePicker1.Value,  //DOB
                               GENDER, //Gender
                               textBox5.Text, //Phone No
                               textBox6.Text, //Address
                               comboBox1.Text);
            MessageBox.Show("Data Inserted Successfully");

            //Cassidy Version of Student Create
            /*
            int StNum = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string Surname = textBox3.Text;
            string IMG = textBox4.Text;
            DateTime DOB = dateTimePicker1.Value.Date;
            string gender = GENDER;
            string phone = textBox5.Text;
            string address = textBox6.Text;
            string Modcodes = comboBox1.Text;

            Student register = new Student(StNum, name, Surname, IMG, DOB, gender, phone, address, Modcodes);

             if (handler.Register(register))
            {
                MessageBox.Show("Student Registered!");
            }
            else
            {
                MessageBox.Show("Student could not be registered");
            }
            */

        }
        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int ID = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string surname = textBox3.Text;
            string image = textBox4.Text;
            string Date = dateTimePicker1.Value.ToString();
            string phone = textBox5.Text;
            string adress = textBox6.Text;
            string code = comboBox1.SelectedIndex.ToString();
            string gender = "N/A";

            if (radioButton1.Checked = true)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked = true)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Please select ONE gender!");
                flag = false;
            }

            if (flag == true)
            {
                if (handler.UpdateUser(ID, name, surname, image, Date, phone, adress, code, gender))
                {
                    MessageBox.Show("Data Updated!");
                }
                else
                {
                    MessageBox.Show("Error 404!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            //file explorer attempt 2
            string filePath = @"/C:\Users\raymo\OneDrive\Desktop\PRG282\Milestone2Git\Milestone2\PRG282_Project2\Cassidy_Raymond_Sebastian_PRG282_Project2\bin\Debug\Bobby.png";
            if (!File.Exists(filePath))
            {
                return;
            }
            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);

            //file explorer attempt 2
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
            */
            //file explorer attempt 3
            //Working example
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // @"/C:\Users\raymo\OneDrive\Desktop\PRG282\Milestone2Git\Milestone2\PRG282_Project2\Cassidy_Raymond_Sebastian_PRG282_Project2\bin\Debug\Bobby.png"
            }
            if (folderPath == Path.GetDirectoryName(folderBrowser.FileName))
            {
                textBox4.Text = folderBrowser.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox1.Text);

            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (handler.DeleteUser(ID) == true)
                {
                    MessageBox.Show("User Deleted!");
                }
                else
                {
                    MessageBox.Show("Error 404!");
                }
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Delete Action Stopped!");
            }
        }
    }
}
