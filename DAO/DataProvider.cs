using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        //private string connectionString = "Server=TOAN-THANG;Database=RapPhim;User Id=sa;Password=123;";
        private string connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapChieuPhim;Integrated Security=True";
        //Data Source=TOAN-THANG;Initial Catalog=QL_ShopDienThoai;Integrated Security=True
        //private string connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapPhim;Persist Security Info=True;User ID=sa";
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }
        public DataProvider(string username, string password)
        {
            this.connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapChieuPhim;User Id=" + username + ";Password=" + password + ";";
            //this.connectionString = "Server=TOAN-THANG;Database=RapPhim;User Id=" + username + ";Password=" + password + ";";
            //this.connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapPhim;Persist Security Info=True;User ID=" + username + ";Password=" + password + ";";
        }
        public DataProvider()
        {
            this.connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapChieuPhim;Integrated Security=True";
            //this.connectionString = "Server=TOAN-THANG;Database=RapPhim;User Id=sa;Password=123;";
            //this.connectionString = "Data Source=TOAN-THANG;Initial Catalog=RapPhim;Persist Security Info=True;User ID=sa";
        }
        public DataTable executeQuery(string sql, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    if (parameter != null)
                    {
                        string[] listPara = sql.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i + 1]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
                return data;
            }
            catch (SqlException ex)
            {
                //throw new ArgumentException(ex.Message);
                return null;
            }
        }
        public void executeNonQuery(string sql, object[] parameter = null)
        {
            //int affectedRows = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    if (parameter != null)
                    {
                        string[] listPara = sql.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    command.ExecuteNonQuery();
                    //affectedRows = command.ExecuteNonQuery();
                    connection.Close();
                }
                //return affectedRows;
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
                //return 0;
            }
        }
        public void executeProcedure(string sql, object[] parameter = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameter != null)
                    {
                        for (int i = 0; i < parameter.Length - 1; i += 2)
                        {
                            command.Parameters.AddWithValue(parameter[i].ToString(), parameter[i + 1]);
                        }
                    }
                    command.ExecuteNonQuery();
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
