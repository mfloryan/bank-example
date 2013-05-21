using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CTM.Bank.Domain.ValueTypes
{
    public class Currency
    {
        private static readonly List<Currency> Currencies = new List<Currency>();

        public static readonly Currency GBP = new Currency("GBP", "£", "en-GB");
        public static readonly Currency USD = new Currency("USD", "$", "en-US");
        
        private readonly string code;
        private readonly string symbol;
        internal readonly CultureInfo Format;

        private Currency(string code, string symbol, string cultureCode)
        {
            this.code = code;
            this.symbol = symbol;
            Format = CultureInfo.GetCultureInfo(cultureCode);
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

        public override string ToString()
        {
            return string.Format("{0}({1})", code, symbol);
        }

        public static Currency From(string str)
        {
            return Currencies.FirstOrDefault(c => str.Contains(c.symbol)) ?? DefaultCurrencyForCurrentLocale;
        }

        protected static Currency DefaultCurrencyForCurrentLocale
        {
            get { return From(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol); }
        }

        public class Exception : System.Exception
        {
            public Exception(string message) : base(message)
            {
            }
        }
    }
}