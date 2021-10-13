using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2
{
    class Student
    {
        int id;
        DateTime birth;
        string name, surname, image, gender, phone, address, modcodes;
        public Student() { }

        public Student(int id, string name, string surname, string image, DateTime birth, string gender, string phone, string address, string modcodes)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.image = image;
            this.birth = birth;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.modcodes = modcodes;
        }
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Image { get => image; set => image = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Modcodes { get => modcodes; set => modcodes = value; }

    }
}
