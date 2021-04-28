using System;

namespace Generics3
{
    // Generic type restrictions
    class UserInfo
    {
        public UserInfo(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }

    class AllInfoUser : UserInfo
    {
        public AllInfoUser(string family, string name, int age)
            : base(name, age)
        {
            Family = family;
        }

        public string Family { get; }

        public override string ToString()
        {
            return $"Информация о пользователе: \n{Name} {Family} {Age}\n";
        }
    }

    class Info<T> where T : UserInfo
    {
        T[] _userList;
        int _i;

        public Info()
        {
            _userList = new T[3];
            _i = 0;
        }

        public void Add(T obj)
        {
            if (_i == 3) return;
            _userList[_i] = obj;
            _i++;
            return;
        }

        public void ReWrite()
        {
            foreach (T t in _userList)
            {
                var x = t.Age;
                var y = t.Name;
                Console.WriteLine(t.ToString());
            }
        }
    }

    class Program2
    {
        static void Main()
        {
            Info<AllInfoUser> database1 = new Info<AllInfoUser>();
            database1.Add(new AllInfoUser(name: "Alex", family: "Erohin", age: 26));
            // database1.Add(new UserInfo(name: "Alexey", family: "Volkov", age: 28));
            // database1.Add(new UserInfo(name: "Dmitryi",  age: 50));

            database1.ReWrite();
            
            Info<UserInfo> database2 = new Info<UserInfo>();
            database2.Add(new AllInfoUser(name: "Alexey", family: "Volkov", age: 28));
            database2.Add(new UserInfo(name: "Dmitryi",  age: 50));

            Console.ReadLine();
        }
    }
}
