namespace BankLibrary
{
    public class Locker
    {
        private object _data;
        private string _keyword;
        private int _id;

        public Locker(int id, string keyword, object data)
        {
            _id = id;
            _keyword = keyword;
            _data = data;
        }
        
        public Locker(int id, string keyword)
        {
            _id = id;
            _keyword = keyword;
        }

        public int Id => _id;
        public object Data => _data;

        public bool Matches(int id, string keyword)
        {
            return (_id == id) && (_keyword.Equals(keyword));
        }

        public void RemoveData()
        {
            _data = null;
        }

        public override int GetHashCode()
        {
            return _id ^ _keyword.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Locker locker)
            {
                return _id == locker.Id && _keyword == locker._keyword;
            }

            return false;
        }
    }
}