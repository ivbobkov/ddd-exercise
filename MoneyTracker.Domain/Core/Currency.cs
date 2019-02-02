using System;

namespace MoneyTracker.Domain.Core
{
    public class Currency : IEquatable<Currency>
    {
        public Currency(string code, decimal rate)
        {
            Code = code;
            Rate = rate;
        }

        public string Code { get; }

        public decimal Rate { get; }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Code, other.Code) && Rate == other.Rate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode() ^ Rate.GetHashCode();
        }
    }
}
