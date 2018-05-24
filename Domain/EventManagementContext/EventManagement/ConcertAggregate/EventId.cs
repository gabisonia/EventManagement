using Newtonsoft.Json;
using Shared;

namespace EventManagement.ConcertAggregate
{
    public class ConcertId : Identity
    {
        public ConcertId()
        {
        }

        [JsonConstructor]
        public ConcertId(string value) : base(value)
        {

        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class EmptyId : Identity
    {
        public override bool HasValue() => false;
    }
}
