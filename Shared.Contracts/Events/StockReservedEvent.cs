using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events
{
    public class StockReservedEvent
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

    }
}
