using CTM.Bank.Domain.ValueTypes;
using CTM.Domain.Core;

namespace CTM.Bank.Domain.Commands
{
    public class CreateAccount : CommandBase
    {
        public readonly SortCode SortCode;
        public readonly AccountNumber AccountNumber;

        public CreateAccount(AggregateDescriptor descriptor, SortCode sortCode, AccountNumber accountNumber) : base(descriptor)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}