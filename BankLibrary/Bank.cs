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
            CreateAccount(parameters, () => parameters.Type == AccountType.Deposit 
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }

        public void Withdraw(decimal amount, int id)
        {
            //TODO: check types compatibility
            var account = _accounts.Where(x => x.Id == id).First();
            

            if (account is DepositAccount depositAccount)
            {
                depositAccount.Withdraw(amount);
            }
            else
            {
                account.Withdraw(amount);
            } 
        }

        private void CreateAccount(OpenAccountParameters parameters, Func<T> creator)
        {
            var account = creator();
            account.Created += parameters.AccountCreated;
            account.WithdrawMoney += parameters.WithdrawMoney;
            account.Open();
            _accounts.Add(account);
        }
    }
}