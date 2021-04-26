namespace Generics5
{
    class Class1<T>
    {
    }

    class Class2_1<T> : Class1<T>
    { }

    class Class2_2<T, V> : Class1<T>
    { }

    class Class3<T, V, E, G> : Class2_2<T, V>
    { }
    
    class Class4 : Class2_2<int, string>
    { }

    class SomeClass
    { }

    class ObClass<T> : SomeClass
    { }

    class Program
    {
        static void Main()
        {}
    }
}
