using System;
using System.Collections.Generic;
using System.Linq;
using CTM.Bank.Domain;
using CTM.Bank.Domain.ValueTypes;

namespace CTM.Bank.Console
{
    public class BankingVerb
    {
        private static readonly IList<BankingVerb> Verbs = new List<BankingVerb>();

        public static readonly BankingVerb Quit = new BankingVerb("quit", (bank, additionalOptions) => bank.Close());
        public static readonly BankingVerb Deposit = new BankingVerb("deposit", (bank, additionalOptions) => bank.Deposit(Money.From(additionalOptions)));
        public static readonly BankingVerb Withdraw = new BankingVerb("withdraw", (bank, additionalOptions) => bank.Withdraw(Money.From(additionalOptions)));
        public static readonly BankingVerb Create = new BankingVerb("create", (bank, additionalOptions) => bank.Create(additionalOptions));
        public static readonly BankingVerb Open = new BankingVerb("open", (bank, additionalOptions) => bank.Open(additionalOptions));
        public static readonly BankingVerb Help = new BankingVerb("help");
        public static readonly BankingVerb Unknown = new BankingVerb("unknown");
        private readonly string verb;
        private readonly Action<BankingApplication, object> action;

        private BankingVerb(string verb) : this(verb, DoNothing){ }

        private BankingVerb(string verb, Action<BankingApplication, Object> action)
        {
            this.verb = verb;
            this.action = action;
            Verbs.Add(this);
        }

        private static void DoNothing(BankingApplication bank, object options){}

        private bool Matches(string other)
        {
            return string.Equals(verb, other, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return verb;
        }

        public static BankingVerb From(string verb)
        {
            return Verbs.SingleOrDefault(v => v.Matches(verb)) ?? Unknown;
        }

        public void Execute(BankingApplication bank, object additionalOptions)
        {
            action(bank, additionalOptions);
        }
    }
}