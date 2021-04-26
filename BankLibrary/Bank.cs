using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<T> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            if ((parameters.Type == AccountType.Deposit && parameters.BankType == BankType.OnDemandAccount) || 
                (parameters.Type == AccountType.OnDemand && parameters.BankType == BankType.DepositAccount))
            {
                throw new InvalidOperationException("An account with this type can not create");
            }

            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit
                   ? new DepositAccount(parameters.Amount, parameters.Percentage) as T
                   : new OnDemandAccount(parameters.Amount,  parameters.Percentage) as T);
        }

        public void ClosedAccount(CloseAccountParameters parameters)
        {
            AssertValidId(parameters.Id);
            var account = _accounts[parameters.Id];
            AddAndDeleteCloseEvent(parameters, account);
            _accounts.Insert(parameters.Id, account);
        }

        public void PutAmount(PutAccountParameters parameters)
        {
            AssertValidId(parameters.Id);
            var account = _accounts[parameters.Id];
            AddAndDeletePutEvent(parameters, account);
            _accounts.Insert(parameters.Id, account);
        }

        public void WithdrawMoney(WithdrawAccountParameters parameters)
        {
            AssertValidId(parameters.Id);
            var account = _accounts[parameters.Id];
            AddAndDeleteWithdrawEvent(parameters, account);
            _accounts.Insert(parameters.Id, account);
        }

        public void IncrementDay()
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                _accounts[i].IncrementDays();
                _accounts[i].CalculatePercentage();
            }
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            AddAndDeleteCreateEvent(accountCreated, account);
            _accounts.Add(account);
        }

        private void AssertValidId(int id)
        {
            if (id < 0 || id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
        }

        private static void AddAndDeleteCreateEvent(AccountCreated accountCreated, T account)
        {
            account.Created += accountCreated;
            account.Open();
            account.Created -= accountCreated;
        }

        private static void AddAndDeleteCloseEvent(CloseAccountParameters parameters, Account account)
        {
            account.Closed += parameters.AccountClosed;
            account.Close();
            account.Closed -= parameters.AccountClosed;
        }

        private static void AddAndDeleteWithdrawEvent(WithdrawAccountParameters parameters, Account account)
        {
            account.Withdrawn += parameters.MoneyWithdrawn;
            account.Withdraw(parameters.Amount);
            account.Withdrawn -= parameters.MoneyWithdrawn;
        }

        private static void AddAndDeletePutEvent(PutAccountParameters parameters, Account account)
        {
            account.Putted += parameters.MoneyPutted;
            account.Put(parameters.Amount);
            account.Putted -= parameters.MoneyPutted;
        }
    }
}