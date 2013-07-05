using CTM.Bank.Domain.Events;

namespace CTM.Bank.Domain.Aggregates
{
    public partial class BankAccount
    {
        private void Apply(AccountCreated evt) { }

        private void Apply(DepositMade evt)
        {
            // Rich: aha, what's this all about then!?
        }
    }
}