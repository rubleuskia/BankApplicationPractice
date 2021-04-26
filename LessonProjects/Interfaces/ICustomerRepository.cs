namespace Interfaces
{
    public interface IRepository<T>
    {
        T[] GetItems();
        T GetById(int entityId);
        void Insert(T entity);
        void Delete(int entityId);
        void Update(T item);
        void Save();    
    }
}
