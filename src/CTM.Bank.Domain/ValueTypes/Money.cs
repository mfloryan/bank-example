namespace CTM.Bank.Domain.ValueTypes
{
    public class Money
    {
        public static Money From(object obj)
        {
            return new Money();
        }
    }
}