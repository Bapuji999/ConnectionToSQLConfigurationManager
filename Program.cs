using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DataConnection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DemoData"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string SelectCommand = "select * from Product";
                //string InsertCommand = "INSERT INTO Product SELECT Name = 'Paragon', Price = 500";
                //using (SqlCommand cmd = new SqlCommand(InsertCommand, conn))
                //{
                //    int count = cmd.ExecuteNonQuery();
                //    Console.WriteLine("Number of rows affected " + count);
                //}
                using (SqlCommand cmd = new SqlCommand(SelectCommand, conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            Console.WriteLine("{0} {1} ",rdr.GetInt32(0), rdr.GetString(1));
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}