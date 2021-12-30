using SagaDemo.Web.Models;

namespace SagaDemo.Web.Services
{
    public interface IProductService
    {

        void BuyProduct(CustomerBuyRequest customerBuyRequest);

    }
}
