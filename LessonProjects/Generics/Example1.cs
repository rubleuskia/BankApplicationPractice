
using System;

namespace Generics
{
    public class List<T> { }
    public class LinkedList<T> { }
    
    public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) ;
    public delegate TOutput Converter<TInput, TOutput>(TInput from);
    public class SortedList<TKey, TValue> { }

    public class Examples
    {
        public Examples()
        {
            var listOfString = new List<string>();
            var listOfIntegers = new List<int>();

            Converter<int, string> converter1 = ConvertToString;
            Converter<string, int> converter2 = ConvertToInt;

            var sortedList = new SortedList<string, string>();

            EventHandler<DayOfWeek> eventHandler1 = HandleEvent;
            EventHandler<string> eventHandler2 = HandleStringEvent;

        }

        public void HandleStringEvent(object sender, string dayOfWeek)
        {

        }
        public void HandleEvent(object sender, DayOfWeek dayOfWeek)
        {
            // logic
        }
        
        public string ConvertToString(int value)
        {
            return value.ToString();
        }
        
        public int ConvertToInt(string value)
        {
            return int.Parse(value);
        }
    }
}
