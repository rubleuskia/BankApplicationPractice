using System;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal amount)
      : base(amount)
        {
        }

        public override AccountType Type => AccountType.Deposit;

        public override void Withdraw(decimal amount)
        {
            if (Days / 30 == 0)
            {
                throw new InvalidOperationException($"Cannot withdraw money. Withdraw money through {30 - Days} day(s)");
            }

            base.Withdraw(amount);
        }
    }
}