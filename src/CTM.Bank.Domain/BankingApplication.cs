using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Domain
{
    public class BankingApplication
    {
        public bool IsOpen { get; private set; }

        public BankingApplication()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public void Deposit(Money amount)
        {
            
        }

        public void Withdraw(Money amount)
        {
            
        }

        public void CreateAccount(object additionalOptions)
        {
            
        }

        public void Open(object additionalOptions)
        {
            
        }
    }
}
