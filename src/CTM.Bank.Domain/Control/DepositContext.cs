﻿using System.Collections.Generic;
using System.Linq;
using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Domain.Control
{
    public class DepositContext : BankingContext
    {
        private readonly IEnumerable<string> arguments;

        public DepositContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        protected override string DoExecute(BankingApplication bank)
        {
            var amount = Money.From(arguments.First());
            bank.Deposit(amount);
            return "Deposited " + amount;
        }
    }
}