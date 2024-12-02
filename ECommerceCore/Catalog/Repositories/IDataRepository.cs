using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IDataRepository
    {
        bool Insert(Product product);
        bool Update(Product product);
        void Delete(int id);
        void GetCount();
        List<Product> GetAll();
        Product GetById(int id);
    }
}
