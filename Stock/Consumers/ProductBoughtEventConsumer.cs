using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Shared.Contracts.Events;
using System.Threading;

namespace Stock
{
    public class ProductBoughtEventConsumer : IConsume<ProductBoughtEvent>
    {
        private readonly IBus _bus;
        private readonly IStockService _stockService;
        public ProductBoughtEventConsumer(IBus bus, IStockService stockService)
        {
            _bus = bus;
            _stockService = stockService;
        }

        public void Consume(ProductBoughtEvent productBought, CancellationToken cancellationToken = default)
        {
            _stockService.ReserveStock();

            _bus.PubSub.Publish(new StockReservedEvent()
            {
                CustomerId = productBought.CustomerId,
                ProductId = productBought.ProductId,
            });
        }

    }
}
