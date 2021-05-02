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
            CheckValidTypeAccount(parameters.Type);

            CreateAccount(parameters, () => parameters.Type == AccountType.Deposit
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }

        public void Withdraw(decimal amount, int id)
        {
            var account = GetAccountById(id);
            account.Withdraw(amount);
        }

        public void Put(decimal amount, int id)
        {
            var account = GetAccountById(id);
            account.Put(amount);
        }

        public void Close(int id)
        {
            var account = GetAccountById(id);
            account.Close();
        }

        public void IncrementDays()
        {
            _accounts.ForEach(x => x.IncrementDays());
        }

        private void CreateAccount(OpenAccountParameters parameters, Func<T> creator)
        {
            var account = creator();
            account.Created += parameters.AccountCreated;
            account.WithdrawMoney += parameters.WithdrawMoney;
            account.PutMoney += parameters.PutMoney;
            account.AccountClosed += parameters.AccountClosed;
            account.Open();
            _accounts.Add(account);
        }

        private Account GetAccountById(int id)
        {
            var account = _accounts.Where(x => x.Id == id).SingleOrDefault();

            if (account == null)
            {
                throw new InvalidOperationException("Account with the entered id does not exist");
            }

            return account;
        }

        private void CheckValidTypeAccount(AccountType inputType)
        {
            if ((typeof(T) == typeof(DepositAccount) && inputType != AccountType.Deposit) ||
               (typeof(T) == typeof(OnDemandAccount) && inputType != AccountType.OnDemand))
            {
                throw new InvalidOperationException($"Invalid account type: {inputType}");
            }
        }
    }
}