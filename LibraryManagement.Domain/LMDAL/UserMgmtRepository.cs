using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    public class UserMgmtRepository : IUserMgmtRepository
    {
        SqlConnection conn;
        SqlCommand cmdAddUserDetails,cmdGetUserDetails;
        public UserMgmtRepository()
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
        public bool addUserDetails(User user)
        {
            bool result = false;
            cmdAddUserDetails = new SqlCommand("ProcInsertUserDetails", conn);
            cmdAddUserDetails.Parameters.AddWithValue("@Id", user.userId);
            cmdAddUserDetails.Parameters.AddWithValue("@username", user.username);
            cmdAddUserDetails.Parameters.AddWithValue("@password", user.password);
            cmdAddUserDetails.Parameters.AddWithValue("@role", user.role);
            cmdAddUserDetails.Parameters.AddWithValue("@isActive", user.isActive);
            cmdAddUserDetails.Parameters.AddWithValue("@phoneNo", user.phoneNo);
            cmdAddUserDetails.Parameters.AddWithValue("@mailid", user.mailId);
            cmdAddUserDetails.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            if (cmdAddUserDetails.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }
        public User GetUserDetails(int id)
        {
            User userdetails = new User();
            cmdGetUserDetails = new SqlCommand("ProcGetUserDetails", conn);
            cmdGetUserDetails.Parameters.AddWithValue("@Id", id);
            cmdGetUserDetails.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader sqlData = cmdGetUserDetails.ExecuteReader();
            while (sqlData.Read())
            {
                userdetails.userId = Convert.ToInt32(sqlData[0]);
                userdetails.username = sqlData[1].ToString();
                userdetails.role = Convert.ToInt32(sqlData[2]);
                userdetails.isActive = Convert.ToInt32(sqlData[3]);
                userdetails.phoneNo = Convert.ToInt64(sqlData[4]);
                userdetails.mailId = sqlData[5].ToString();
                userdetails.password = sqlData[6].ToString();
            }
            conn.Close();
            return userdetails;
        }

    }
}
