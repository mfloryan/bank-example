using System;

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
}