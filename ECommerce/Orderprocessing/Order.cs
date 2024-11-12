using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderprocessing
{ 
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Orderdate { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }

    }
}
