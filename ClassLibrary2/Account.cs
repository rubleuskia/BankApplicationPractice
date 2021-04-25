using System;

namespace BankLibrary
{
    public delegate void AccountCreated(string message);

    public abstract class Account
    {
        private static int _counter = 0;
        private decimal _amount;
        private int _id;
        private int _days = 0;
        private AccountState _state;

        public event AccountCreated Created;

        public Account(decimal amount, int percentage)
        {
            _amount = amount;
            _state = AccountState.Created;
            _id = ++_counter;
        }

        protected internal virtual void Open()
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
            IncrementDays();
            Created?.Invoke("Account closed.");
        }

        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            _amount += amount;
            IncrementDays();
            Created?.Invoke("Account is topped up.");
        }

        public virtual void Withdraw(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");
            }

            _amount -= amount;
            IncrementDays();
            Created?.Invoke($"You have withdrawn an amount of {amount}. On your account remained {_amount}");
        }

        public abstract AccountType Type { get; }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        protected int Days => _days;
        public int Id => _id;

        public int Length { get; internal set; }

        public void IncrementDays()
        {
            _days++;
        }

        internal virtual void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}