using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private const string KgkPassPhrase = "CleanUp";
        private Dictionary<Locker,object> _lockers = new();
        private readonly List<T> _accounts = new();
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

            throw new ArgumentOutOfRangeException($"Cannot find locker with id {id} or keyword does not match");
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
            AssertValidType(parameters.Type);
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }

        private static void AssertValidType(AccountType type)
        {
            var itemType = typeof(T);
            if (itemType != typeof(Account) && ((type == AccountType.Deposit && itemType != typeof(DepositAccount))
                                           || (type == AccountType.OnDemand && itemType != typeof(OnDemandAccount))))
            {
                throw new InvalidOperationException("Ivalid account type.");
            }

        }


        private void CreateAccount(AccountStatus accountNotify, Func<T> creator)
        {
            var account = creator();
            account.Notify += accountNotify;
            account.Open();

            _accounts.Add(account);
        }
        public void Withdraw(int id, decimal amount)
        {
            AssertValidId(id--);
            _accounts[id].Withdraw(amount);
        }

        private void AssertValidId(int id)
        {
            if (id < 1 || id > _accounts.Count)
            {
                throw new InvalidOperationException("Not valid Id");
            }
        }

        public void Put(int id, decimal amount)
        {
            AssertValidId(id--);
            _accounts[id].Put(amount);
        }

        public void CloseAccount(int id)
        {
            AssertValidId(id--);
            _accounts[id].Close();
        }

        public void IncrementDays()
        {
            foreach (var item in _accounts)
            {
                item.IncrementDays();
            }
        }
    }
}