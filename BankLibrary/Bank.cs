using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private const string KgkPassPhrase = "CleanUp";
        private readonly List<Account> _accounts = new();
        private readonly Dictionary<Locker, object> _lockers = new();

        public int AddLocker(string keyword, object data)
        {
            var locker = new Locker(_lockers.Count + 1, keyword, data);
            _lockers.Add(locker, data);
            return locker.Id;
        }

        public object GetLockerData(int id, string keyword)
        {
            var tempLocker = new Locker(id, keyword);
            if (_lockers.ContainsKey(tempLocker))
            {
                return _lockers[tempLocker];
            }

            throw new ArgumentOutOfRangeException(
                $"Cannot find locker with ID: {id} or keyword does not match");
        }

        public TU GetLockerData<TU>(int id, string keyword)
        {
            return (TU)GetLockerData(id, keyword);
        }

        public void VisitKgk(string passPhrase)
        {
            if (passPhrase.Equals(KgkPassPhrase))
            {
                foreach (var locker in _lockers.Keys)
                {
                    locker.RemoveData();
                }
            }
        }

        public void OpenAccount(OpenAccountParameters parameters)
        {
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }
    }
}
