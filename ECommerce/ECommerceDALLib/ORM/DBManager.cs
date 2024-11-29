using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ECommerceDALLib.ORM

{
    [Table("products_shruti")]  //mapping your class in database 
    public class Product
    {

        [Key]
        public string Id { get; set; }
        //[Column("Title")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }

    public class ECommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ECommerceContext() : base("name=conString") { }
    }

    public static class DBManager
    {
        public static void Delete(int id)
        {
            string str_Id = id.ToString();
            using (var context = new ECommerceContext())
            {
                var product = context.Products.SingleOrDefault(s => s.Id == str_Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }


        }
        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var context = new ECommerceContext())
            {
                var dbProducts = context.Products.ToList();
                foreach (var product in dbProducts)
                {
                    Product theProduct = new Product();
                    theProduct.Name = product.Name;
                    theProduct.Description = product.Description;
                    theProduct.Quantity = product.Quantity;
                    theProduct.Image = product.Image;
                    products.Add(product);
                }
            }
            return products;
        }

        public static Product GetById(int id)
        {
            Product product = null;
            string str_Id = id.ToString();
            using (var context = new ECommerceContext())
            {
                product = context.Products.SingleOrDefault(s => s.Id == str_Id);

            }
            return product;
        }
        public static bool Insert(Product product)
        {
            bool status = false;
            using (var context = new ECommerceContext())
            {
                context.Products.Add(product);
            }
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;

            using (var context = new ECommerceContext())
            {
                var foundDroduct = context.Products.SingleOrDefault(s => s.Id == product.Id);
                if (foundDroduct != null)
                {
                    foundDroduct.Name = product.Name;
                    foundDroduct.Description = product.Description;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }


            return status;
        }

    }

}