using System;

namespace Generics
{
    class MyObject<T>
    {
        private T obj;

        public MyObject(T obj)
        {
            this.obj = obj;
        }

        public void PrintObjectType()
        {
            Console.WriteLine("Тип объекта: " + typeof(T));
        }
    }

    class MyObjects<T, V, E>
    {
        T obj1;
        V obj2;
        E obj3;

        public MyObjects(T obj1, V obj2, E obj3)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.obj3 = obj3;
        }

        public void PrintObjectType()
        {
            Console.WriteLine("\nТип объекта 1: " + typeof(T)+
                              "\nТип объекта 2: " + typeof(V) +
                              "\nТип объекта 3: " + typeof(E));
        }
    }

    class Program1
    {
        static void Main()
        {
            MyObject<int> obj1 = new MyObject<int>(25);
            obj1.PrintObjectType();

            MyObjects<string, byte, decimal> obj2 = new MyObjects<string, byte, decimal>("Alex", 26, 12.333m);
            obj2.PrintObjectType();

            Console.ReadLine();
        }
    }
}
