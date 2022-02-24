using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimisticConcurrentHandle.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public double Balance { get; set; }
    }
}
