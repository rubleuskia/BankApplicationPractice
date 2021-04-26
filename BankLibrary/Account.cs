using System;

namespace BankLibrary
{
    public delegate void AccountCreated(string message);
    public delegate void Account—hangedStateSum();

    public abstract class Account
    {
        private static int _counter = 0;
        public decimal _amount;
        private int _id;
        private int _days = 0;
        private AccountState _state;
        public abstract AccountType Type { get; }

        public event AccountCreated Created;
        public event Account—hangedStateSum —hangedStateSum;

        public Account(decimal amount)
        {
            _amount = amount;
            _state = AccountState.Created;
            _id = ++_counter;
        }

        public virtual void Open()
        {
            AssertValidState(AccountState.Created);

            _state = AccountState.Opened;
            IncrementDays();
            Created?.Invoke("Account created.");
        }

        public virtual void Close()
        {
            AssertValidState(AccountState.Opened);

            _state = AccountState.Closed;
            —hangedStateSum();
        }

        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            _amount += amount;
            —hangedStateSum();
        }

        public virtual void Withdraw(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");

            }

            _amount = _amount - amount;
            —hangedStateSum();
        }

        public void AccrualOfPercent(decimal Percent)
        {
            _amount= _amount+ ((_amount /100) * Percent);
        }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        protected int Days => _days;
        public int Id => _id;

        public void IncrementDays()
        {
            _days++;
        }

    }
}