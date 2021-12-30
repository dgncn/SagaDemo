using System;

namespace Stock
{
    public class StockService : IStockService
    {
        public void ReserveStock()
        {
            Console.WriteLine("stock reserved");
        }
    }
}
