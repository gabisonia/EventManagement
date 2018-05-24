using Shared;
using System;
using System.Runtime.Serialization;

namespace OrderManagement.Domain.OrderAggregate
{
    [DataContract]
    public class OrderTotalCalculated : VersionedDomainEvent
    {
        public OrderTotalCalculated(Tuple<string, decimal> total)
        {
            Total = total;
        }
        [DataMember]
        public Tuple<string, decimal> Total { get; }
    }
}
