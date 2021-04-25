using System;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal amount, int percentage)
            : base(amount, percentage)
        {
        }

        public override AccountType Type => AccountType.Deposit;

        public override void Put(decimal sum)
        {
            if (Days % 30 == 0)
                base.Put(sum);
        }

        internal override void Calculate()
        {
            if (Days % 30 == 0)
                base.Calculate();
        }

        public override void Withdraw(decimal amount)
        {
            if (Days / 30 == 0)
            {
                throw new InvalidOperationException("Cannot withdraw money.");
            }

            base.Withdraw(amount);
        }
    }
}