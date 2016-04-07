using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldModule.Utils
{
    public class DBManager
    {
        private SqlConnection sqlConnection;
        private string connectionString = @"Data Source =.\SQLExpress;Initial Catalog = MSAFocusDB; User Id = sa; password=123;";
        public DBManager()
        {
            //sqlConnection.ConnectionString = connectionString;
        }

        public IList<Customer> GetAllCustomers()
        {
            IList<Customer> allCustomers = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    //
                    // The following code uses an SqlCommand based on the SqlConnection.
                    //
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allCustomers.Add(new Customer { Id = reader.GetInt32(0), Name = reader.GetString(1),
                                State = reader.GetString(2), Country = reader.GetString(3)});
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return allCustomers;
        } 
    }
}
