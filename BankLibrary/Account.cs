using System;

namespace BankLibrary
{
    public delegate void WriteOutput(string message);
    
    public abstract class Account
    {
        private static int _counter = 0;
        private decimal _amount;
        private int _id;
        private int _days = 0;
        private AccountState _state;
        private readonly int _interest = 10;

        public event WriteOutput Created;
        public event WriteOutput WithdrawMoney;
        public event WriteOutput PutMoney;
        public event WriteOutput AccountClosed;

        public abstract AccountType Type { get; }

        protected int Days => _days;

        public int Id => _id;

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
            AccountClosed?.Invoke("Account closed.");
        }
        
        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            _amount += amount;

            PutMoney?.Invoke($"You put: {amount}. Account balance: {_amount}");
        }
        
        public virtual void Withdraw(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");
            }

            _amount -= amount;
            WithdrawMoney?.Invoke($"You withdraw {amount}. Account balance: {_amount}");
        }

        public void IncrementDays()
        {
            _days++;
            InterestAccrual();
        }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        private void InterestAccrual()
        {
            if (_days % 30 == 0)
            {
                _amount += _amount * _interest / 100;
            }
        }
    }
}