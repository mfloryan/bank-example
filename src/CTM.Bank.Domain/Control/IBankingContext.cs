namespace CTM.Bank.Domain.Control
{
    public interface IBankingContext
    {
        void Execute(BankingApplication bank);
    }
}