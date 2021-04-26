using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class SqlServerRepository<T> : IRepository<T>
    {
        private SqlServerApplicationContext context;

        public SqlServerRepository()
        {
            this.context = new SqlServerApplicationContext();
        }

        public T[] GetItems()
        {
            throw new NotImplementedException();
        }

        public T GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
