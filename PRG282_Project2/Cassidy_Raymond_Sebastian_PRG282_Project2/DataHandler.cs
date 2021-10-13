using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // Sebastian_Marnewick
{
    class DataHandler
    {
        string conn = "Server=(local); Initial Catalog=Milestone2; Integrated Security=SSPI";

        public void insertData(int StudentNummber, string Name, string Surname, string StudentIMG, DateTime DOB, string GENDER, string PhoneNo, string Address, string ModCodes)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentNumber", StudentNummber);
                cmd.Parameters.AddWithValue("@sName", Name );
                cmd.Parameters.AddWithValue("@Surname", Surname );
                cmd.Parameters.AddWithValue("@StudentIMG", StudentIMG);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@GENDER", GENDER);
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@ModCodes", ModCodes);


                connect.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void updateData(int StudentNummber, string Name, string Surname, string StudentIMG, DateTime DOB, string GENDER, string PhoneNo, string Address, string ModCodes)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentNumber", StudentNummber);
                cmd.Parameters.AddWithValue("@sName", Name);
                cmd.Parameters.AddWithValue("@Surname", Surname);
                cmd.Parameters.AddWithValue("@StudentIMG", StudentIMG);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@GENDER", GENDER);
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@ModCodes", ModCodes);

                connect.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteData(int StudentNummber)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@@StudentNumber", StudentNummber);

                connect.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable searchData(int StudentNummber)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spSearchStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentNumber", StudentNummber);

                connect.Open();
                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }

        public void insertModule(string ModCode, string ModName, string ModuleDesc, string RescourceLinks)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModCode", ModCode);
                cmd.Parameters.AddWithValue("@ModName", ModName);
                cmd.Parameters.AddWithValue("@ModuleDesc", ModuleDesc);
                cmd.Parameters.AddWithValue("@RecourceLinks", RescourceLinks);

                connect.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public DataTable displayStudents()
        {
            string query = @"SELECT * FROM Students";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        
        //Function to delete a student
        public bool Delete(int sID)
        {
            try
            {
                SqlConnection cons = new SqlConnection(conn);
                cons.Open();
                string query = $"DELETE FROM Students WHERE StudentNumber = '{sID}'";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Action could not be completed!" + ex.Message);
               
                return false;
                
            }

        }
        string id, name, surname, image, birth, gender, phone, address, modcodes;
        public void VariableStore(string id, string name, string surname, string image, string birth, string gender, string phone, string address, string modcodes)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.image = image;
            this.birth = image;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.modcodes = modcodes;
        }
        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Image { get => image; set => image = value; }
        public string Birth { get => birth; set => birth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Modcodes { get => modcodes; set => modcodes = value; }
       
    }
}
