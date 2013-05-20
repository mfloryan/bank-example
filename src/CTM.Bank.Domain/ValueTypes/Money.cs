namespace CTM.Bank.Domain.ValueTypes
{
    public class Money
    {
        private readonly decimal amount;

        public Money(decimal amount)
        {
            this.amount = amount;
        }

        public static Money From(object obj)
        {
            return new Money(0m);
        }

        public override string ToString()
        {
            return amount.ToString("C");
        }
    }
}