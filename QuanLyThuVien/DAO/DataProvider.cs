using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyThuVien.DAO
{
    public class DataProvider
    {
        private static string connectionString =
            "server=localhost;user=root;password=;database=quanlythuvien;SslMode=none;";

        // Kết nối MySQL
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Hàm SELECT trả về DataTable
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable data = new DataTable();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {   
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(data);
            }

            return data;
        }


        // Hàm INSERT / UPDATE / DELETE
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int result = 0;

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                result = command.ExecuteNonQuery();
            }

            return result; // Trả về số dòng bị ảnh hưởng
        }

        // Hàm lấy giá trị đơn (LAST_INSERT_ID, COUNT, SUM, etc.)
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                result = command.ExecuteScalar();
            }

            return result;
        }
    }
}
