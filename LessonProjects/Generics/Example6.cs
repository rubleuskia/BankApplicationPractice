using System;

namespace Generics6
{
    public class Example6
    {
        // generic methods
        class InfoObject
        {
            public static string InfoUser<T>(T user)
                where T : User
            {
                return user.Name.ToString();
            }
        }

        class User
        {
            public User(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        class UserPass : User
        {
            public UserPass(string name, int age, string pass)
                : base(name, age)
            {
                Password = pass;
            }

            public string Password { get; set; }

            public override string ToString()
            {
                return $@"Информация о пользователе:
**************************
Имя: {Name}
Возраст: {Age}
Пароль: {Password}";
            }
        }

        class Program
        {
            static void Main()
            {
                UserPass user1 = new UserPass(name: "Alex", age: 26, pass: "12345");
                User user2 = new User(name: "Alex", age: 26);

                string s1 = InfoObject.InfoUser(user1);
                string s2 = InfoObject.InfoUser(user2);
                Console.WriteLine(s1);
                Console.WriteLine(s2);
                Console.ReadLine();
            }
        } 
    }
}
