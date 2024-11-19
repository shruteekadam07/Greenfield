using ECommerceEntities;
using EcommerceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SerializationTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ProductService svc = new ProductService();
            svc.Seeding();
            List<Product> allProducts = svc.GetAll();
            foreach (Product product in allProducts)
            {
                Console.WriteLine(product.Title + " " + product.UnitPrice);
            }*/

            AuthService svc = new AuthService();
            svc.Seeding();
            List<User> allUsers = svc.GetAllUsers();
            foreach (User user in allUsers)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
            Console.ReadLine();
        }
    }
}