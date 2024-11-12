﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public double OrderAmount {  get; set; }
        public DateTime OrderDate { get; set; }
    }
}