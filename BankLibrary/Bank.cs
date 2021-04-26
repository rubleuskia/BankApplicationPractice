using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<Account> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            // TODO: check types compatibility
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit ? new DepositAccount(parameters.Amount) as T : new OnDemandAccount(parameters.Amount) as T);
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }

        public void Withdraw(Withdraw param)
        {
            CheakedID(param._id);
            var account = _accounts[param._id];
            account.ÑhangedStateSum += Message;
            account.Withdraw(param._amount);
            account.ÑhangedStateSum -= Message;
        }

        public void Put(Put param)
        {
            CheakedID(param._id);
            var account = _accounts[param._id];
            account.ÑhangedStateSum += Message ;
            account.Put(param._amount);
            account.ÑhangedStateSum -= Message;
        }

        public void CloseAccount(int id)
        {
            var account = _accounts[id];
            account.Close();
        }

       public void SkipDay()
        {
            if (_accounts == null)
            {
                throw new InvalidOperationException("An account with this number does not exist");

            }

            foreach (var account in _accounts)
            {
                account.IncrementDays();
               if( account.Type == AccountType.Deposit)
                {
                    account.AccrualOfPercent(1M); // 1%
                    Console.WriteLine(account._amount);
                }

            }    
        }

        private void CheakedID(int id)
        {
            if (id < 0 || id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");

            }

        }

        public void Message()
        {
            Console.WriteLine("operation completed successfully");
            Console.ReadKey();
        }

    }
}