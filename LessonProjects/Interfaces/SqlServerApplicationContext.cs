using System.Collections.Generic;

namespace Interfaces
{
    // SQL Server DB access logic
    public class SqlServerApplicationContext
    {
        public List<Customer> Customers { get; set; }

        public void SaveChanges()
        {
        }
    }
}
