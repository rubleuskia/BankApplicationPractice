using System;

namespace BankLibrary
{
    public delegate void AccountStatus(string message);

    public abstract class Account
    {


        private static int s_counter;
        private decimal _amount;
        protected int Days { get; private set; }
        protected int Id { get; }
        private AccountState _state;
        private AccountState Type { get; }
        public event AccountStatus Notify;

        public override string ToString()
        {
            if (_state != AccountState.Closed)
            {
                return $"{Id}. {Type} {_amount} money, {Days} days";
            }
            else
            {
                return $"{Id}. {Type} {_state}";
            }
        }
        public Account(decimal amount)
        {
            _amount = amount;
            _state = AccountState.Created;
            Id = ++s_counter;
        }

        public virtual void Open()
        {
            AssertValidState(AccountState.Created);
            _state = AccountState.Opened;
            IncrementDays();
            Notify?.Invoke("Account created. On your account {_amount}");
        }

        public virtual void Close()
        {
            AssertValidState(AccountState.Opened);
            _state = AccountState.Closed;
            IncrementDays();
            Notify?.Invoke("Account closed. On your account {_amount}");
        }

        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);
            _amount += amount;
            Notify?.Invoke("Amount of money replenished. On your account {_amount}");
        }

        public virtual void Withdraw(decimal amount)
        {
             AssertValidState(AccountState.Opened);
            AssertValidAmount(amount);
            _amount -= amount;
            Notify?.Invoke($"{amount} was withdrawed from account");

        }
        private void AssertValidAmount(decimal amount)
        {
            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");
            }
        }
        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        public void Skip() => IncrementDays();

        public void IncrementDays()
        {
            Days++;
            _amount = CalculatePercentage(_amount);
        }
        internal abstract decimal CalculatePercentage(decimal amount);
    }
}