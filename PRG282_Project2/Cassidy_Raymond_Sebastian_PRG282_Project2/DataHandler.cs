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

        /*
        public bool Register(Student person)
        {
            try
            {
                SqlConnection cons = new SqlConnection();
                cons.Open();
                string query = $"INSERT INTO Students VALUES {person.ID}, '{person.Name}', '{person.Surname}', '{person.Image}', {person.Birth},'{person.Gender}', '{person.Phone}','{person.Address}','{person.Modcodes}'";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/
        
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
        public bool UpdateUser(int ID, string name, string surname, string image, string date, string phone, string adress, string code, string gender)
        {
            try
            {
                SqlConnection cons = new SqlConnection(conn);
                cons.Open();
                string query = $"UPDATE Students SET Name = '{name}', Surname = '{surname}', image = '{image}, date = '{date}', phone = '{phone}', adress = '{adress}', code = '{code}', gender = '{gender}' WHERE ID={ID}";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int ID)
        {
            try
            {
                SqlConnection cons = new SqlConnection(conn);
                cons.Open();
                string query = $"DELETE * FROM Milestone2 WHERE StudentNumber={ID}";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   
    }
}
