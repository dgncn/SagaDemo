using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events
{
    public class ProductBoughtEvent
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

    }
}
