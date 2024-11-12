using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCOLib;

namespace Specification

{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(int productid);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int productid);
    }
}
