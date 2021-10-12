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
    public partial class ModuleInfo : Form
    {
        public ModuleInfo()
        {
            InitializeComponent();
        }
        DataHandler handler = new DataHandler();
        

        private void button1_Click(object sender, EventArgs e)
        {
            string ModCode = textBox1.Text;
            string ModName = textBox2.Text;
            string ModuleDesc = textBox3.Text;
            string RescourseLinks = richTextBox1.Text;

            handler.insertModule(
                ModCode,
                ModName,
                ModuleDesc,
                RescourseLinks) ;
            MessageBox.Show("Data Inserted Successfully");
        }
    }
}
