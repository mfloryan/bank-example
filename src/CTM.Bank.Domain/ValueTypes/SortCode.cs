namespace CTM.Bank.Domain.ValueTypes
{
    public class SortCode
    {
        private readonly string sortCode;

        public SortCode(string sortCode)
        {
            this.sortCode = sortCode;
        }

        protected bool Equals(SortCode other)
        {
            return !ReferenceEquals(null, other) && string.Equals(sortCode, other.sortCode);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || Equals(obj as SortCode);
        }

        public override int GetHashCode()
        {
            return (sortCode != null ? sortCode.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return sortCode;
        }
    }
}