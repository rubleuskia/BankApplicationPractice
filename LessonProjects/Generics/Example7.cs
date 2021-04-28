using System;

namespace Generics7
{
    public delegate void MyDelegate(object arg);
    delegate T MyDel<T> (T obj1, T obj2);

    class MySum
    {
        public static int SumInt(int a, int b)
        {
            return a + b;
        }

        public static string SumStr(string s1, string s2)
        {
            return s1 + " " + s2;
        }

        public static char SumCh(char a, char b)
        {
            return (char)(a + b);
        }
    }

    class Program
    {
        static void Main()
        {
            MyDel<int> del1 = MySum.SumInt;
            Console.WriteLine("6 + 7 = " + del1(6,7));

            MyDel<string> del2 = MySum.SumStr;
            Console.WriteLine("\"Отличная\" + \"погода\" = " + del2("Отличная","погода"));

            MyDel<char> del3 = MySum.SumCh;
            Console.WriteLine("'a' + 'c' = " + del3('a','c'));

            Console.ReadLine();
        }
    }
}