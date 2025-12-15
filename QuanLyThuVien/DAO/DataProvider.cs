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
            "server=localhost;user=root;password=Quocdai@210;database=quanlythuvien;SslMode=none;";
            

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
        public static bool ExecuteTransaction(List<Tuple<string, Dictionary<string, object>>> commands)
        {
            MySqlConnection conn = null;
            MySqlTransaction tran = null;

            try
            {
                conn = GetConnection(); // Giả định bạn có hàm GetConnection()
                conn.Open();
                tran = conn.BeginTransaction();

                foreach (var cmdTuple in commands)
                {
                    string query = cmdTuple.Item1;
                    Dictionary<string, object> parameters = cmdTuple.Item2;

                    using (MySqlCommand command = new MySqlCommand(query, conn, tran)) // SỬ DỤNG TRAN VÀ CONN
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        // Cố gắng thực thi lệnh. Nếu có lỗi SQL, nó sẽ ném ra Exception
                        if (command.ExecuteNonQuery() <= 0 && query.Trim().ToUpper().StartsWith("INSERT"))
                        {
                            // Nếu là INSERT mà không có dòng nào bị ảnh hưởng -> Thất bại
                            throw new Exception("Lỗi khi thêm dữ liệu chi tiết phiếu nhập.");
                        }
                        // Đối với DELETE, 0 dòng ảnh hưởng vẫn có thể là thành công (nếu không có gì để xóa)
                    }
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                Console.WriteLine("Lỗi Giao dịch (Rollback): " + ex.Message);
                // Có thể thêm logging chi tiết hơn ở đây
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
