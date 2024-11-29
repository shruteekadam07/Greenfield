using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerceEntities
{
      //[Serializable]
      public class Product
      {
        public int ProductId { get; set; }
        public double UnitPrice {get;set;}
        public int Quantity { get;set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl {  get; set; }

        public override string ToString()
        {
            return ProductId + " " + Title + " " + Description;
        }

    }

}