using System;

namespace BankLibrary
{
    public delegate void AccountStatus(string message);

    public abstract class Account 
    {


        private static int _counter;
        private decimal _amount;
        private readonly int _id;
        private int _days = 0;
        private readonly decimal rate = 0.5m;

        public abstract AccountType Type { get; }

        internal AccountState _state { get; set; }

        internal int Days => _days;

        internal int Id => _id;

        public event AccountStatus Created;
        public event AccountStatus WithdrawAccount;
        public event AccountStatus PutAccount;
        public event AccountStatus AccountCloser;

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
            Created?.Invoke("Account created. On your account {_amount}");
        }

        public virtual void Close()
        {
            AssertValidState(AccountState.Opened);
            _state = AccountState.Closed;
            IncrementDays();
            Created?.Invoke("Account closed. On your account {_amount}");
        }

        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);
            _amount += amount;
            IncrementDays();
            Created?.Invoke("Amount of money replenished. On your account {_amount}");
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
            Created?.Invoke($"You have withdrawn an amount of {amount}. On your account {_amount}");
        }

        public void Skip() => IncrementDays();

        public void IncrementDays() => _days++;

        public void PaymentAmount()
        {
            _amount = (_amount * rate) + _amount;
        }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }
    }
}