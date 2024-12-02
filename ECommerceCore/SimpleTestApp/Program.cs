// See https://aka.ms/new-console-template for more information
using Catalog;
using Catalog.Entities;
using Catalog.Repositories.Connected;

Console.WriteLine("Hello, World!");
List<Product> products = ProductRepository.GetAll();
foreach (var product in products)
{
    Console.WriteLine(product);
}
Console.ReadLine();