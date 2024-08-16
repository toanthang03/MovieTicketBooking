using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AuthDAO
    {
        private string username;
        private string password;

        private static AuthDAO instance;
        public static AuthDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthDAO();
                }
                return instance;
            }
        }

        public AuthDAO() { }

        public AuthDAO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void Login(string username, string password)
        {
            string connectionString = "Server=TOAN-THANG;Database=RapChieuPhim;User Id=" + username + ";Password=" + password + ";";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if(connection != null)
                {
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
