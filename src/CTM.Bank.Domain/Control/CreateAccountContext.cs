using System.Collections.Generic;

namespace CTM.Bank.Domain.Control
{
    public class CreateAccountContext : BankingContext
    {
        private readonly IEnumerable<string> arguments;

        public CreateAccountContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        protected override string DoExecute(BankingApplication bank)
        {
            bank.CreateAccount(arguments);
            return "Created account.";
        }
    }
}