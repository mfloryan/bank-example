using CTM.Bank.Domain.Events;
using CTM.Bank.Domain.ValueTypes;
using CTM.Domain.Core;

namespace CTM.Bank.Domain.Aggregates
{
    public partial class BankAccount : AggregateRoot
    {
        public BankAccount(AggregateDescriptor aggregateDescriptor, SortCode sortCode, AccountNumber accountNumber) : base(aggregateDescriptor.Id)
        {
            RaiseEvent(new AccountCreated());
        }
        
    }
}