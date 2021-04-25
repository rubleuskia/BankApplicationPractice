namespace BankLibrary
{
    public class OnDemandAccount : Account
    {
        public OnDemandAccount(decimal amount, int percentage)
            : base(amount, percentage)
        {
        }

        public override AccountType Type => AccountType.OnDemand;

        
        internal override void Calculate()
        {
            throw new System.NotImplementedException();
        }

    }
}