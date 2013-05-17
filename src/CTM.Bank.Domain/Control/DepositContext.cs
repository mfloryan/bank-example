using System;
using System.Collections.Generic;
using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Domain.Control
{
    public class HelpContext : IBankingContext
    {
        public void Execute(BankingApplication bank)
        {
            Console.Out.WriteLine("The valid commands are: help, create, open, deposit, withdraw, quit");
        }
    }

    public class BankingContext : IBankingContext
    {
        private readonly Action<BankingApplication> action;
        public static readonly BankingContext Quit = new BankingContext(bank => bank.Close());
        public static readonly BankingContext DoNothing = new BankingContext(bank => { });

        private BankingContext(Action<BankingApplication> action)
        {
            this.action = action;
        }

        public void Execute(BankingApplication bank)
        {
            action(bank);
        }
    }

    public class DepositContext : IBankingContext
    {
        private readonly IEnumerable<string> arguments;

        public DepositContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        public void Execute(BankingApplication bank)
        {
            bank.Deposit(Money.From(arguments));
        }
    }
    
    public class WithdrawContext : IBankingContext
    {
        private readonly IEnumerable<string> arguments;

        public WithdrawContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        public void Execute(BankingApplication bank)
        {
            bank.Withdraw(Money.From(arguments));
        }
    }

    public class CreateAccountContext : IBankingContext
    {
        private readonly IEnumerable<string> arguments;

        public CreateAccountContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        public void Execute(BankingApplication bank)
        {
            bank.CreateAccount(arguments);
        }
    }

    public class OpenAccountContext : IBankingContext
    {
        private readonly IEnumerable<string> arguments;

        public OpenAccountContext(IEnumerable<string> arguments)
        {
            this.arguments = arguments;
        }

        public void Execute(BankingApplication bank)
        {
            bank.Open(arguments);
        }
    }
}