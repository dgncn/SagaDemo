using Shared.Contracts.Events;
using System;

namespace Payment
{
    public class StockReservedEventConsumer
    {
        public void ConsumeAsync(StockReservedEvent @event)
        {
            Console.WriteLine(@event.CustomerId + " " + @event.ProductId);
        }


    }
}
