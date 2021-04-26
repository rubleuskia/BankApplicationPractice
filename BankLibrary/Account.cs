using System;

namespace BankLibrary
{
    public delegate void AccountCreated(string message);
    public delegate void AccountClosed(string message);
    public delegate void MoneyPutted(string message);
    public delegate void MoneyWithdrawn(string message);

    public abstract class Account
    {
        private static int _counter = 0;
        private decimal _amount;
        private int _id;
        private int _days = 0;
        private decimal _percentage;
        private AccountState _state;

        public event AccountCreated Created;
        public event AccountClosed Closed;
        public event MoneyPutted Putted;
        public event MoneyWithdrawn Withdrawn;

        public Account(decimal amount, decimal percentage)
        {
            _amount = amount;
            _state = AccountState.Created;
            _id = _counter++;
            _percentage = percentage;
        }

        public virtual void Open()
        {
            AssertValidState(AccountState.Created);

            _state = AccountState.Opened;
            IncrementDays();
            Created?.Invoke($"Account created.");
        }
        
        public virtual void Close()
        {
            AssertValidState(AccountState.Opened);
    
            _state = AccountState.Closed;
            Closed?.Invoke("Account closed");
        }
        
        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            _amount += amount;
            Putted?.Invoke("Money was putted on the account");
        }
        
        public virtual void Withdraw(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");
            }

            _amount -= amount;
            Withdrawn?.Invoke("Money was withdrawn to the account");
        }
        
        public abstract AccountType Type { get; }

        public BankType BankType => BankType.Account;

        public int Id => _id;

        public void IncrementDays()
        {
            _days++;
        }

        public virtual void CalculatePercentage()
        {
            AssertValidState(AccountState.Opened);

            _amount += _amount * _percentage / 100;
        }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        protected int Days => _days;

        protected decimal Percentage => _percentage;
    }
}