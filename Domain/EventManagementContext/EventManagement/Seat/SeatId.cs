using Newtonsoft.Json;
using Shared;

namespace EventManagement.Seat
{
    public class SeatId : Identity
    {
        public SeatId()
        {
        }
        [JsonConstructor]
        public SeatId(string value) : base(value)
        {
        }
    }
}
