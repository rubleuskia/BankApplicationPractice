using System;
using System.Collections.Generic;
using System.Linq;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        
        private readonly List<Account> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            // TODO: check types compatibility
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit
                ? new DepositAccount(parameters.Amount, parameters.Percentage) as T
                : new OnDemandAccount(parameters.Amount, parameters.Percentage) as T);
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }

        public void Put(decimal sum, int id)
        {
            var account = FindAccount(id);
            if (account == null)
                throw new Exception("Account didn't find");
            account.Put(sum);
        }

        public void Withdraw(decimal sum, int id)
        {
            var account = FindAccount(id);
            if (account == null)
                throw new Exception("Account didn't find");
            account.Withdraw(sum);
        }
        
        public void Close(int id)
        {
            var _accounts = FindAccount(id, out var index);
            if (_accounts == null)
                throw new Exception("Account didn't find");

            _accounts.Close();

            if (_accounts.Length <= 1)
                _accounts = null;
            else
            {
                
                var tempAccounts = new T[_accounts.Length - 1];
                for (int i = 0, j = 0; i < _accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = (T)this._accounts[i];
                }
            }
        }

        
        public void CalculatePercentage()
        {
            if (_accounts == null)
                return;
            foreach (var t in _accounts)
            {
                t.IncrementDays();
                t.Calculate();
            }
        }

        
        public T FindAccount(int id)
        {
            return _accounts.Where(t => t.Id == id).Cast<T>().FirstOrDefault();
        }
        
        public T FindAccount(int id, out int index)
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                if (_accounts[i].Id == id)
                {
                    index = i;
                    return (T)_accounts[i];
                }
            }
            index = -1;
            return null;
        }

        public void OpenAccount(AccountType parameters, decimal sum)
        {
            throw new NotImplementedException();
        }
    }
}