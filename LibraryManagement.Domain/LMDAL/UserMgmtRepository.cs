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
        SqlCommand cmdAddUserDetails,cmdGetUserDetails,cmdGetAllUsers,cmdDelUsr;
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
        public async Task<bool> addUserDetails(User user)
        {
            bool result = false;
            cmdAddUserDetails = new SqlCommand("ProcInsertUserDetails", conn);
            cmdAddUserDetails.Parameters.AddWithValue("@Id", user.id);
            cmdAddUserDetails.Parameters.AddWithValue("@username", user.username);
            cmdAddUserDetails.Parameters.AddWithValue("@password", user.password);
            cmdAddUserDetails.Parameters.AddWithValue("@role", user.role);
            cmdAddUserDetails.Parameters.AddWithValue("@isActive", user.isActive);
            cmdAddUserDetails.Parameters.AddWithValue("@phoneno", user.phoneNo);
            cmdAddUserDetails.Parameters.AddWithValue("@mailid", user.mailId);
            cmdAddUserDetails.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            await Task.Run(() =>
            {
                if (cmdAddUserDetails.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
            });
            conn.Close();
            return result;
        }
        public async Task<User> GetUserDetails(int id)
        {
            User userdetails = new User();
            cmdGetUserDetails = new SqlCommand("ProcGetUserDetails", conn);
            cmdGetUserDetails.Parameters.AddWithValue("@Id", id);
            cmdGetUserDetails.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader sqlData = cmdGetUserDetails.ExecuteReader();
            await Task.Run(() =>
            {
                while (sqlData.Read())
                {
                    userdetails.id = Convert.ToInt32(sqlData[0]);
                    userdetails.username = sqlData[1].ToString();
                    userdetails.password = sqlData[2].ToString();
                    userdetails.role = Convert.ToInt32(sqlData[3]);
                    userdetails.isActive = Convert.ToInt32(sqlData[4]);
                    userdetails.phoneNo = Convert.ToInt64(sqlData[5]);
                    userdetails.mailId = sqlData[6].ToString();

                }
            });
            conn.Close();
            return userdetails;
        }
        public async Task<List<User>> getAllUserMgmtDetails()
        {
            List<User> users = new List<User>();
            cmdGetAllUsers = new SqlCommand("procGetAllUserDetails", conn);
            cmdGetAllUsers.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader drUsers = cmdGetAllUsers.ExecuteReader();
            User user = null;
            await Task.Run(() =>
            {
                while (drUsers.Read())
                {
                    user = new User();
                    user.userId = Convert.ToInt32(drUsers[0].ToString());
                    user.username = drUsers[1].ToString();
                    user.password = drUsers[2].ToString();
                    user.role = Convert.ToInt32(drUsers[3].ToString());
                    user.isActive = Convert.ToInt32(drUsers[4]);
                    user.phoneNo = Convert.ToInt64(drUsers[5].ToString());
                    user.mailId = drUsers[6].ToString();
                    users.Add(user);
                }
            });
            conn.Close();
            return users;
        }
        public async Task<bool> deleteUser(int userId)
        {
            bool deleted = false;
            cmdDelUsr = new SqlCommand("procDeleteUser",conn);
            cmdDelUsr.Parameters.AddWithValue("@userId", userId);
            cmdDelUsr.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            await Task.Run(() =>
            {
                if (cmdDelUsr.ExecuteNonQuery() > 0)
                {
                    deleted = true;
                }
            });
            conn.Close();
            return deleted;
        }
    }
}
