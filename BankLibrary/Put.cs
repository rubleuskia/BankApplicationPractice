using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Put
    {
        public decimal _amount { get; set; }
        public int _id { get; set; }
      
        void Message(int _amount, int amount, string action)
        {
            Console.WriteLine($"current balance {_amount} you {action} {amount}");
        }
    }
}
