using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDALLib.DisconnectedDataAccess;
using ECommerceEntities;

namespace DisconnectedTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void PrintL()
            {
                List<Product> products = DBManager.GetAll();

                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                }
            }


            void deleteL()
            {
                Console.WriteLine("Enter ID to be deleted");
                int id = Convert.ToInt32(Console.ReadLine());
                DBManager.Delete(id);
            }

            void ProductByID()
            {
                Product product = DBManager.GetById(4);
                Console.WriteLine(product);
            }
            void UpdateL()
            {
                Product p = new Product { Title = "Hibiscus", ProductId = 1, Description = "Worship Flower", Quantity = 5000, ImageUrl = "", UnitPrice = 500 };
                DBManager.Update(p);
            }

            void InsertL()
            {
                Product p1 = new Product { Title = "LILY", ProductId = 4, Description = "White Flower", Quantity = 2000, ImageUrl = "", UnitPrice = 300 };
                DBManager.Insert(p1);
            }

            PrintL();
            /*Console.WriteLine();
            deleteL();
            Console.WriteLine();
            PrintL();
            Console.WriteLine();
            ProductByID();
            Console.WriteLine();
            Console.WriteLine("Update Called !!");
            UpdateL();
            PrintL();
            Console.WriteLine();
            Console.WriteLine("Insert Called !!");
            InsertL();
            PrintL();*/


            Console.ReadLine();
        }
    }
}
