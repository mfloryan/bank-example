using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CTM.Bank.Domain.ValueTypes
{
    public class Currency
    {
        private static readonly string DecimalCurrencyExpression = @"(?:\d+(?:,\d{3},?)?)+(?:\.\d{2})?$";
        private static readonly List<Currency> Currencies = new List<Currency>();

        public static readonly Currency GBP = new Currency("GBP", "£", DecimalCurrencyExpression);
        public static readonly Currency USD = new Currency("USD", "$", DecimalCurrencyExpression);
        
        private readonly string code;
        private readonly string symbol;
        private readonly Regex expression;

        private Currency(string code, string symbol, string currencyExpression)
        {
            this.code = code;
            this.symbol = symbol;
            expression = new Regex(currencyExpression, RegexOptions.Compiled);
            Currencies.Add(this);
        }

        protected bool Equals(Currency other)
        {
            return !ReferenceEquals(null, other) && string.Equals(code, other.code);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || Equals(obj as Currency);
        }

        public override int GetHashCode()
        {
            return (code != null ? code.GetHashCode() : 0);
        }

        public string ToString(decimal amount)
        {
            return symbol + amount.ToString("#,##0.00");
        }

        public static Currency From(string str)
        {
            return Currencies.FirstOrDefault(c => str.Contains(c.symbol));
        }

        internal static Money Parse(string str)
        {
            var currency = From(str);
            var match = currency.expression.Match(str.Trim());
            var amount = decimal.Parse(match.Value);
            return new Money(amount, currency);
        }
    }
}