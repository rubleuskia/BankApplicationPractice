using System;

namespace Generics4
{
    // more restrictions
    interface IUserInfo
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    class AllInfoUser : IUserInfo
    {
        private int counter;

        public AllInfoUser()
        {
        }

        public AllInfoUser(string family, string uName, int uAge)
        {
            Family = family;
            Name = uName;
            Age = uAge;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Family { get; set; }

        public override string ToString()
        {
            return $"Информация о пользователе: \n{Name} {Family} {Age}\n";
        }
    }

    class Info<T> where T : new()
    {
        T[] _userList;
        int _i;

        T _obj1 = new T();
        T _obj2 = new T();
        T _obj3 = new T();
        T _obj4 = new T();

        public void Create()
        {
            var x = new T();
            _i = 0;
        }

        public void Add(T obj)
        {
            // obj.Age
            if (_i == 3) return;
            _userList[_i] = obj;
            _i++;
            return;
        }

        public void ReWrite()
        {
            foreach (T t in _userList)
                Console.WriteLine(t.ToString());
        }

        public T Get(int index) => _userList[index];
    }

    class Program
    {
        static void Main()
        {
            Info<AllInfoUser> database1 = new Info<AllInfoUser>();
            database1.Add(new AllInfoUser(uName: "Alex", family: "Erohin", uAge: 26));
            database1.Add(new AllInfoUser(uName: "Alexey", family: "Volkov", uAge: 28));
            database1.Add(new AllInfoUser(uName: "Dmitryi", family: "Medvedev", uAge: 50));

            AllInfoUser user = database1.Get(1);
            database1.ReWrite();

            Console.ReadLine();
        }
    }
}
