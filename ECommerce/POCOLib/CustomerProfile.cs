using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    public class CustomerProfile
    {
        public Customer theCustomer {  get; set; }
        public List<Order> OrderHistory { get; set; }
    }
}
