using Newtonsoft.Json;
using Shared;

namespace EventManagement.SeatTypeAggregate
{
    public class SeatTypeId : Identity
    {
        public SeatTypeId()
        {
        }
        [JsonConstructor]
        public SeatTypeId(string value) : base(value)
        {
        }
    }
}
