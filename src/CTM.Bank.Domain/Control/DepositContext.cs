using System;
using System.Collections.Generic;
using System.Linq;
using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Domain.Control
{
    public class BankingContext : IBankingContext
    {
        public static readonly BankingContext Quit = new BankingContext(bank => bank.Close(), "Quitting");
        public static readonly BankingContext DoNothing = new BankingContext(bank => { }, "Unknown Command");
        private readonly Action<BankingApplication> action = bank => { };
        private readonly string message;

        protected BankingContext()
        {
            message = "Unknown Command";
        }

        private BankingContext(Action<BankingApplication> action, string message)
        {
            this.action = action;
            this.message = message;
        }

        public string Execute(BankingApplication bank)
        {
            try
            {
                return DoExecute(bank);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        protected virtual string DoExecute(BankingApplication bank)
        {
            action(bank);
            return message;
        }
    }

    public class HelpContext : BankingContext
    {
        protected override string DoExecute(BankingApplication bank)
        {
            return "The valid commands are: help, create, open, deposit, withdraw, quit";
        }
    }

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