namespace CTM.Bank.Domain.Control
{
    public class HelpContext : BankingContext
    {
        protected override string DoExecute(BankingApplication bank)
        {
            return "The valid commands are: help, create, open, deposit, withdraw, quit";
        }
    }
}