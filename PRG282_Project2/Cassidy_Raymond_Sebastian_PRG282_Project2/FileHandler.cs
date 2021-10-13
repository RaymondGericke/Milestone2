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
        public string AddUser(string username, string password)
        {
            string FilePath = Directory.GetCurrentDirectory() + "/LoginDetails.txt";
            string[] ActiveUserList = File.ReadAllLines(FilePath);
            bool Valid = true;

            for (int i = 0; i < ActiveUserList.Length; i++)
            {
                string[] TextLines = ActiveUserList[i].Split('-');

                if (TextLines[0] == username)
                {
                    Valid = false;
                    break;
                }
                else
                {
                    Valid = true;
                }
            }
            if (Valid == true)
            {
                string NewUser = string.Empty;
                StreamWriter Writer = new StreamWriter(FilePath, true);
                NewUser += username + '-' + password + '-';
                Writer.WriteLine(NewUser);
                Writer.Close();
                return "Your user has been created successfully!";
            }
            else
            {
                return "Username already Exists!";
            }
        }
        public bool LoginUser(string username, string password)
        {
            string FilePath = Directory.GetCurrentDirectory() + "/LoginDetails.txt";
            string[] ActiveUserList = File.ReadAllLines(FilePath);
            bool Valid = false;

            for (int i = 0; i < ActiveUserList.Length; i++)
            {
                string[] TextLines = ActiveUserList[i].Split('-');

                if (TextLines[0] == username && TextLines[1] == password)
                {
                    Valid = true;
                    break;
                }
            }
            return Valid;
        }
    }
}
