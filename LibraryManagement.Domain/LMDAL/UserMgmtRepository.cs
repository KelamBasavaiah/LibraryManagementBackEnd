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
        SqlCommand cmdAddUserDetails,cmdUpdateUserDetails;
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
        public bool updateUserDetails(int id,User userdetails)
        {
            bool updated = false;
            cmdUpdateUserDetails = new SqlCommand("ProcUpdateUserDetails", conn);
            cmdUpdateUserDetails.Parameters.AddWithValue("@Id", id);
            cmdUpdateUserDetails.Parameters.AddWithValue("@username", userdetails.username);
            cmdUpdateUserDetails.Parameters.AddWithValue("@password", userdetails.password);
            cmdUpdateUserDetails.Parameters.AddWithValue("@role", userdetails.role);
            cmdUpdateUserDetails.Parameters.AddWithValue("@isActive", userdetails.isActive);
            cmdUpdateUserDetails.Parameters.AddWithValue("@phoneNo", userdetails.phoneNo);
            cmdUpdateUserDetails.Parameters.AddWithValue("@mailid", userdetails.mailId);
            cmdUpdateUserDetails.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            if (cmdUpdateUserDetails.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            return updated;
        }
    }
}
