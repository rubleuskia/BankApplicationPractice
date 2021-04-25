namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }
        
        public decimal Amount { get; set; }

        public WriteOutput AccountCreated { get; set; }

        public WriteOutput WithdrawMoney { get; set; }
    }
}