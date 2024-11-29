using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDALLib.ORM;

namespace ORMTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = DBManager.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.ReadLine();
        }
    }
}
