using LibraryManagement.Domain.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

    public class userRepository : IUserRepository
{
        SqlConnection conn;
        SqlCommand cmduser;
        public userRepository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conBook"].ConnectionString);
            OpenConnection();
        }
        void OpenConnection()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Open();
        }
        public string getUser(string username)
        {
        string passowrd="";
        cmduser = new SqlCommand("getUser", conn);
        cmduser.Parameters.AddWithValue("@username", username);
        cmduser.CommandType = CommandType.StoredProcedure;
        OpenConnection();
        try
        {
            SqlDataReader dr = cmduser.ExecuteReader();
            while (dr.Read())
            {
                passowrd = Convert.ToString(dr[1]);
            }

        }
        catch (Exception)
        {

            passowrd = "";
        }
        conn.Close();
        return passowrd;
        }
    }