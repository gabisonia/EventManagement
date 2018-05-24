using OrderManagement.Domain.OrderAggregate;
using OrderManagement.OrderAggregate;
using Shared.Models.Money;
using System.Collections.Generic;

namespace OrderManagement.Domain.Services
{
    public interface IPriceCalculator
    {
        Money Total(IEnumerable<OrderItem> items);
    }

    public class AllOrdersProjector
    {
        public void Project(OrderPlaced @event)
        {
            //allorders.add(@event);
            //save
        }
    }
}
