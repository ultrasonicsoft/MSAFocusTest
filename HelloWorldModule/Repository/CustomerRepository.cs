using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSAFocusModule.Model;

namespace MSAFocusModule.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private SqlConnection sqlConnection;
        private readonly string connectionString = @"Data Source =.\SQLExpress;Initial Catalog = MSAFocusDB; User Id = sa; password=123;";

        public IList<DbCustomer> GetAllCustomers()
        {
            IList<DbCustomer> allDbCustomers = new List<DbCustomer>();
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
                            allDbCustomers.Add(new DbCustomer { CustomerId = reader.GetInt32(0), CustomerName = reader.GetString(1),
                                State = reader.GetString(2), Country = reader.GetString(3)});
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return allDbCustomers;
        } 
    }
}
