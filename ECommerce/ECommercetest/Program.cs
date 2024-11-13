using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM;
using Orderprocessing;
using ECommerceEntities;
using Specification;
using Services;

namespace ECommercetest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;



            while (true)
            {
                Console.WriteLine("Available Options:");
                Console.WriteLine("1. CRM");
                Console.WriteLine("2. Order");
                Console.WriteLine("3. Catalog");
                Console.Write("Select the option you want to choose from (1-3): ");
                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Customer customer1 = new Customer();
                        customer1.Id = 34;
                        customer1.FirstName = "Shruti";
                        customer1.LastName = "Kadam";
                        customer1.Email = "kadamshruti9661@gmail.com";
                        customer1.Contact = "9022371763";

                        Customer customer2 = new Customer();
                        customer2.Id = 56;
                        customer2.FirstName = "Seema";
                        customer2.LastName = "Patil";
                        customer2.Email = "seemapatil9661@gmail.com";
                        customer2.Contact = "9017856763";

                        ICustomerService customerService = new CustomerService();
                        customerService.Insert(customer1);
                        customerService.Insert(customer2);

                        List<Customer> allCustomers = customerService.GetAll();
                        foreach (Customer customer in allCustomers)
                        {
                            Console.WriteLine(customer.FirstName);
                            Console.WriteLine(customer.LastName);
                            Console.WriteLine(customer.Email);
                            Console.WriteLine(customer.Contact);
                        }
                        break;

                    case 2:
                        Order order1 = new Order();
                        order1.OrderId = 22;
                        order1.Status = "Accepted";
                        order1.Amount = 6522;
                        order1.Orderdate = new DateTime(2024, 12, 10);

                        Order order2 = new Order();
                        order2.OrderId = 23;
                        order2.Status = "Reject";
                        order2.Amount = 4522;
                        order2.Orderdate = new DateTime(2024, 12, 10);

                        IOrderService orderService = new OrderService();

                        orderService.Insert(order1);
                        orderService.Insert(order2);

                        List<Order> allorder = orderService.GetAll();
                        foreach (Order order in allorder)
                        {
                            Console.WriteLine(order.OrderId);
                            Console.WriteLine(order.Status);
                            Console.WriteLine(order.Amount);
                            Console.WriteLine(order.Orderdate);
                        }
                        break;

                    case 3:
                        Product product1 = new Product(); //id, unit price, quantity, title, description, image url
                        product1.ProductId = 1;
                        product1.UnitPrice = 5000;
                        product1.Quantity = 1;
                        product1.Title = "Mobile";
                        product1.Description = "Experience powerful performance and stunning visuals in a sleek design. Capture every moment with an advanced camera system.";
                        product1.ImageUrl = " https://www.example.com/mobile";

                        Product product2 = new Product(); //id, unit price, quantity, title, description, image url
                        product2.ProductId = 2;
                        product2.UnitPrice = 10000;
                        product2.Quantity = 3;
                        product2.Title = "TV";
                        product2.Description = "Experience stunning visuals and immersive sound with our smart TV. Stream your favorite shows and movies with ease!";
                        product2.ImageUrl = " https://www.example.com/tv";

                        IProductService ProductService = new ProductService();
                        ProductService.Insert(product1);
                        ProductService.Insert(product2);

                        List<Product> allproduct = ProductService.GetAll();
                        foreach (Product product in allproduct)
                        {
                            Console.WriteLine(product.ProductId);
                            Console.WriteLine(product.UnitPrice);
                            Console.WriteLine(product.Quantity);
                            Console.WriteLine(product.Title);
                            Console.WriteLine(product.Description);
                            Console.WriteLine(product.ImageUrl);
                        }
                        break;

                }
                Console.ReadLine();
            }

        }
    }
}
