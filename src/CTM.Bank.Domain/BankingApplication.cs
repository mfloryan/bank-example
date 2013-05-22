using System;
using CTM.Bank.Domain.Commands;
using CTM.Bank.Domain.Services;
using CTM.Bank.Domain.ValueTypes;
using CTM.Domain.Core;
using CTM.Domain.Core.Validation;

namespace CTM.Bank.Domain
{
    public class BankingApplication
    {
        private readonly CreateAccountHandler createAccountHandler;
        private AggregateDescriptor accountId;
        public bool IsOpen { get; private set; }

        public BankingApplication(CreateAccountHandler createAccountHandler)
        {
            this.createAccountHandler = createAccountHandler;
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
            accountId = AggregateDescriptor.New();
            createAccountHandler.Handle(new CreateAccount(accountId, new SortCode("40-40-40"), new AccountNumber()), new ErrorCollection());
        }

        public void Open(object additionalOptions)
        {
            throw new NotImplementedException("AccountId is currently hard-coded, implement this method to allow opening specific accounts by some sort of identifier");
        }
    }
}
