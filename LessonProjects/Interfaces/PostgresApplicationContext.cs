using System.Collections.Generic;

namespace Interfaces
{
    // SQL Server DB access logic
    public class PostgresApplicationContext
    {
        public List<Customer> Customers { get; set; }

        public void SaveChanges()
        {
        }
    }
}
