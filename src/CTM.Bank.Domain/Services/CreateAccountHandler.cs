using CTM.Bank.Domain.Aggregates;
using CTM.Bank.Domain.Commands;
using CTM.Domain.Core;
using CTM.Domain.Core.Validation;

namespace CTM.Bank.Domain.Services
{
    public class CreateAccountHandler : IHandle<CreateAccount>
    {
        private readonly AggregateRepository<BankAccount> accountAggregateRepository;

        public CreateAccountHandler(AggregateRepository<BankAccount> accountAggregateRepository)
        {
            this.accountAggregateRepository = accountAggregateRepository;
        }

        public void Handle(CreateAccount command, ErrorCollection errorCollection)
        {
            var bankAccount = new BankAccount(command.AggregateDescriptor, command.SortCode, command.AccountNumber);
            accountAggregateRepository.Save(bankAccount);
        }
    }
}