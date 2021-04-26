namespace Interfaces
{
    public class Book
    {

    }

    public class Program
    {
        public void Main(string[] args)
        {
            var dbType = args[0];
            IRepository<Customer> repository = CreateRepository<Customer>(dbType);

            IRepository<Customer> customerRepo = new SqlServerRepository<Customer>();
            IRepository<User> userRepo = new SqlServerRepository<User>();
            IRepository<Book> booksRepo = new PostgresRepository<Book>();
        }

        public IRepository<T> CreateRepository<T>(string dbType)
        {
            if (dbType == "sql-server")
            {
                return new SqlServerRepository<T>();
            }
            else
            {
                return new PostgresRepository<T>();
            }
        }
    }
}
