namespace BankLibrary
{
    public class OnDemandAccount : Account
    {
        public OnDemandAccount(decimal amound) 
            : base(amound)
        {
        }
        public override AccountType Type => AccountType.OnDemand;
    }
}