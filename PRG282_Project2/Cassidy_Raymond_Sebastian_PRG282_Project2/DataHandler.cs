using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace Cassidy_Potgieter_Raymond_Gericke_PRG282_Project2 // Sebastian_Marnewick
{
    class DataHandler
    {
        string conn = "Server=(local); Initial Catalog=Milestone2; Integrated Security=SSPI";

        public void insertData(string StudentNummber, string Name, string Surname, byte[] StudentIMG, DateTime DOB, string GENDER, string PhoneNo, string Address, string ModCodes)
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
        public void updateData(string StudentNummber, string Name, string Surname, byte[] StudentIMG, DateTime DOB, string GENDER, string PhoneNo, string Address, string ModCodes)
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

        public void deleteData(string StudentNummber)
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

        public DataTable searchData(string StudentNummber)
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
    }
}
