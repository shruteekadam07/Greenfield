using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Orderprocessing;

namespace Orderprocessing
{
    public class OrderService : IOrderService
    {
        private List<Order> _orderList;
        public OrderService()
        {
            this._orderList = new List<Order>();    // customer services class is maintaining the record of customers
        }

        public bool Delete(int orderid)
        {
            Order theorder = this.Get(orderid);
            return this._orderList.Remove(theorder);
        }

        public Order Get(int orderid)
        {
            foreach (Order order in _orderList)
            {
                if (order.OrderId == orderid)
                    return order;
            }
            return null;
        }

        public List<Order> GetAll()
        {
            return this._orderList;
        }

        public bool Insert(Order order)
        {
            this._orderList.Add(order);
            return true;

        }

        //public bool CheckStatus(Order order)
       // {Order theorder = this.Get(id);
           // if(this.Status==1)
           // {
           //     Console.WriteLine("Order Delivered");          
           // }
       // }

        public bool Update(Order order)
        {
            Order theorder = this.Get(order.OrderId);
            theorder.Amount = order.Amount;
            theorder.Status = order.Status;

            //this._orderList.Remove(theorder);
            //this._orderList.Add(theorder);
            return true;
        }
    }
}
