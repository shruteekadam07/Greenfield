using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;

namespace Specification
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order Get(int orderid);
        bool Insert(Order order);
        bool Update(Order order);
       // bool CheckStatus(Order order);
        bool Delete(int orderid);

    }
}
