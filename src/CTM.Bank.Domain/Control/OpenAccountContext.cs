using System.Collections.Generic;

namespace CTM.Bank.Domain.Control
{
    public class OpenAccountContext : BankingContext
    {
        private readonly IEnumerable<string> arguments;

        public OpenAccountContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        protected override string DoExecute(BankingApplication bank)
        {
            bank.Open(arguments);
            return "Opened account.";
        }
    }
}