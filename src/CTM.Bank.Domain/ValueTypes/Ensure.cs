using System;

namespace CTM.Bank.Domain.ValueTypes
{
    public static class Ensure
    {
        public static void Equals(object left, object right, Action onFailure)
        {
            if (!left.Equals(right))
            {
                onFailure();
            }
        }
    }
}