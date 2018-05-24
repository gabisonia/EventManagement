using Newtonsoft.Json;
using Shared;

namespace EventManagement.Venue
{
    public class VenueId : Identity
    {
        public VenueId() { }
        [JsonConstructor]
        public VenueId(string value) : base(value)
        {
        }
    }
}
