using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // Sebastian_Marnewick
{
    class FileHandler
    {
        public void Login()
        {
            string loginFile = @"C:\Users\Cassidy\Desktop\PRG282_Project2\LoginDetails.txt";

            if (File.Exists(loginFile))
            {
                //Write login code
                //Write validation code
                Console.WriteLine("Lol k");
            }
            else Console.WriteLine("ERROR 404");
        }
    }
}
