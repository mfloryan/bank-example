using System.Collections.Generic;
using System.Linq;
using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Domain.Control
{
    public class WithdrawContext : BankingContext
    {
        private readonly IEnumerable<string> arguments;

        public WithdrawContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        protected override string DoExecute(BankingApplication bank)
        {
            var amount = Money.From(arguments.First());
            bank.Withdraw(amount);
            return "Withdrawn " + amount;
        }
    }
}