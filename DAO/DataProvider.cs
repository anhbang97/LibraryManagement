using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Nam trong project DAO.
namespace Library_management.DAO
{
    public class DataProvider
    {   
        #region Singleton
        private static DataProvider ins;
        public static DataProvider Ins
        {
            get
            {
                if (ins == null)
                    ins = new DataProvider();
                return DataProvider.ins;
            }
            private set
            {
                DataProvider.ins = value;
            }
        }
        private DataProvider()
        {
            
        }
        #endregion
      
        // thay chuỗi này nếu chạy ở máy khác
        private string connectionStr = @"Data Source=;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        // trả ra Nguyên 1 Table
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
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

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        // trả về số lượng này nọ. trả ra số dòng thành công khi Inser,update,delete
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                try
                {

                    SqlCommand command = new SqlCommand(query, connection);


                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
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
                    data = command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (SqlException ex)
                {
                    throw ex;

                }
                return data;
            }
        }

        // trả về cái dòng đầu tiên VD như select count(*)
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
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
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
       
    }
}
