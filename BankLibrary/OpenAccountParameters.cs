using System;

namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }
        
        public decimal Amount { get; set; }

        public Action<string> AccountCreated { get; set; }

        public Action<string> WithdrawMoney { get; set; }

        public Action<string> PutMoney { get; set; }

        public Action<string> AccountClosed { get; set; }
    }
}