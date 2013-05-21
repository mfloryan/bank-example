namespace CTM.Bank.Domain.ValueTypes
{
    public class Money
    {
        private readonly decimal amount;
        private readonly Currency currency;

        public Money(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        protected bool Equals(Money other)
        {
            return !ReferenceEquals(null, other) && (amount == other.amount && Equals(currency, other.currency));
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || Equals(obj as Money);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (amount.GetHashCode()*397) ^ (currency != null ? currency.GetHashCode() : 0);
            }
        }

        public static Money From(string str)
        {
            return Currency.Parse(str);
        }

        public override string ToString()
        {
            return currency.ToString(amount);
        }
    }
}