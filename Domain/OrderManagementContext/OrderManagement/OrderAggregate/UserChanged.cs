using Shared;

namespace OrderManagement.Domain.OrderAggregate
{
    public class UserChanged : VersionedDomainEvent
    {
        public string UserId { get; }
        public UserChanged(string userId)
        {
            UserId = userId;
        }
    }
}
