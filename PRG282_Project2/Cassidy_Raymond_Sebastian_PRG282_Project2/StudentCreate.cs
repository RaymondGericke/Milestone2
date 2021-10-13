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

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // and Sebastian_Marnewick
{
    public partial class StudentCreate : Form
    {
        DataHandler handler = new DataHandler();

        string GENDER;
        public StudentCreate()
        {
            InitializeComponent();
        }

        private void StudentCreate_Load(object sender, EventArgs e)
        {
            string id, name, surname, image, birth, gender, phone, address, modcodes;
            id = handler.ID();
            name = handler.Name();
            surname = handler.Surname();
            image = handler.Image();
            birth = handler.Birth();
            gender = handler.Gender();
            phone = handler.Phone();
            address = handler.Address();
            modcodes = handler.Modcodes();

            
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
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"/C:\Users\raymo\OneDrive\Desktop\PRG282\Milestone2Git\Milestone2\PRG282_Project2\Cassidy_Raymond_Sebastian_PRG282_Project2\bin\Debug\Bobby.png";
            if (!File.Exists(filePath))
            {
                return;
            }
            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
    }
}
