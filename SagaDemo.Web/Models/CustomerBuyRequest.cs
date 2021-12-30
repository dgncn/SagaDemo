namespace SagaDemo.Web.Models
{
    public class CustomerBuyRequest
    {
        public CustomerBuyRequest(int customerId,int productId)
        {
            CustomerId = customerId;
            ProductId = productId; 
        }
        public int CustomerId { get; set; } 
        public int ProductId { get; set; }
    }
}
