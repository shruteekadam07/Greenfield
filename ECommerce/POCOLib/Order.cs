﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Orderdate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }
}
