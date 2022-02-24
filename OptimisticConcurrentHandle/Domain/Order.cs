using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimisticConcurrentHandle.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public Guid Buyer { get; set; }
    }
}
