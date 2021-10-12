using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 //and Sebastian_Marnewick
{
    class FileHandler
    {   
        public class User
        {
            public string UserName { get; set; }
            public string Password { get; set; }

            static string path = @"C:\Users\sebas\source\repos\Milestone2\PRG282_Project2\Cassidy_Raymond_Sebastian_PRG282_Project2\bin\Debug\LoginDetails.txt";
            public static void WriteUser(User obj)
            {
                BinaryWriter Writer = new BinaryWriter(File.Open(path, FileMode.Create));
                Writer.Write(obj.UserName);
                Writer.Write(obj.Password);
                Writer.Close();
            }
            public static void ReadUser(User obj)
            {
                BinaryReader Reader = new BinaryReader(File.Open(path, FileMode.Open));
                obj.UserName = Reader.ReadString();
                obj.Password = Reader.ReadString();
                Reader.Close();
            }
        }

        public bool Login(string Username, string Password)
        {            
            User Active = new User();
            User.ReadUser(Active);

            if (Username == Active.UserName && Password == Active.Password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string Register(string Username, string Password)
        {
            User Active = new User();

            Active.UserName = Username;
            Active.Password = Password;
            User.WriteUser(Active);

            string Text = "User Created!";
            return Text;
        }
    }
}
