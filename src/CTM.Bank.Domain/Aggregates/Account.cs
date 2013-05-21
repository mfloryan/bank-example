using CTM.Bank.Domain.Events;
using CTM.Domain.Core;

namespace CTM.Bank.Domain.Aggregates
{
    public class Account : AggregateRoot
    {
        public Account(AggregateDescriptor aggregateDescriptor) : base(aggregateDescriptor.Id)
        {
            RaiseEvent(new AccountCreated());
        }

        private void Apply(AccountCreated evt) {}
    }
}