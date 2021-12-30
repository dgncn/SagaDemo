using EasyNetQ;
using SagaDemo.Web.Models;
using Shared.Contracts.Events;

namespace SagaDemo.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IBus _bus;
        public ProductService(IBus bus)
        {
            _bus = bus;
        }

        public void BuyProduct(CustomerBuyRequest customerBuyRequest)
        {

            _bus.PubSub.Publish(new ProductBoughtEvent()
            {
                CustomerId = customerBuyRequest.CustomerId,
                ProductId = customerBuyRequest.ProductId,
            });

            System.Console.WriteLine(customerBuyRequest.CustomerId);
        }
    }
}
