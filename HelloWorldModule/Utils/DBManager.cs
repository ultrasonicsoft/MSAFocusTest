using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HelloWorldModule.Utils
{
    public class DBManager
    {
        private SqlConnection sqlConnection;
        private string connectionString = @"Data Source =.\SQLExpress;Initial Catalog = MSAFocusDB; User Id = sa; password=123;";

        public IList<Customer> GetAllCustomers()
        {
            IList<Customer> allCustomers = new List<Customer>();
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var command = new SqlCommand("SELECT * FROM Customer", con))
                    using (var reader = command.ExecuteReader())
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
