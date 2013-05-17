using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CTM.Bank.Domain.Control
{
    public class BankingVerb
    {
        private static readonly IList<BankingVerb> Verbs = new List<BankingVerb>();

        public static readonly BankingVerb Quit = new BankingVerb("quit", arguments => BankingContext.Quit);
        public static readonly BankingVerb Deposit = new BankingVerb("deposit", arguments => new DepositContext(arguments));
        public static readonly BankingVerb Withdraw = new BankingVerb("withdraw", arguments => new WithdrawContext(arguments));
        public static readonly BankingVerb Create = new BankingVerb("create", arguments => new CreateAccountContext(arguments));
        public static readonly BankingVerb Open = new BankingVerb("open", arguments => new OpenAccountContext(arguments));
        public static readonly BankingVerb Help = new BankingVerb("help", arguments => new HelpContext());
        public static readonly BankingVerb Unknown = new BankingVerb("unknown");
        private readonly string verb;
        private readonly Func<IEnumerable<string>, IBankingContext> context;

        private BankingVerb(string verb) : this(verb, arguments => BankingContext.DoNothing){ }

        private BankingVerb(string verb, Func<IEnumerable<string>, IBankingContext> context)
        {
            this.verb = verb;
            this.context = context;
            Verbs.Add(this);
        }

        private bool Matches(string other)
        {
            return other.StartsWith(verb, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return verb;
        }

        public static IBankingContext From(string verb)
        {
            var bankingVerb = Verbs.SingleOrDefault(v => v.Matches(verb)) ?? Unknown;
            var arguments = Regex.Split(verb.Replace(bankingVerb.verb, string.Empty), "\\s");
            return bankingVerb.Context(arguments);
        }

        private IBankingContext Context(IEnumerable<string> arguments)
        {
            return context(arguments);
        }
    }
}