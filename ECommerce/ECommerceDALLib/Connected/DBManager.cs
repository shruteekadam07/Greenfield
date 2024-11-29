using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;
using Specification;

namespace ECommerceDALLib.ConnectedDataAccess
{
    public class DBManager :IDBManager
    {
        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public  bool Insert(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products_shruti (Id, Name, Description, UnitPrice, Quantity, Image)"
                           + "values(" + product.ProductId + ", '" + product.Title + "','" + product.Description + "','" + product.UnitPrice + "','" + product.Quantity + "','" + product.ImageUrl+ "')";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public  bool Update(Product product)
        {
            /*  bool status = false;
             IDbConnection con = new SqlConnection(conString);
             string query = "INSERT INTO products (ProductId, Title, Description, UnitPrice, Quantity, ImageUrl)"
                            + "values(" + product.ProductId + ", '" + product.Title + "')";

             IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
             try
             {
                 con.Open();
                 cmd.ExecuteNonQuery();
                 status = true;
             }
             catch (SqlException ex)
             {
                 Console.WriteLine(ex.Message);
             }
             finally
             {
                 con.Close();
             }
             return status;*/

                bool status = false;
                IDbConnection con = new SqlConnection(conString);
            // Use parameterized query to avoid SQL injection
            string query = "UPDATE products_shruti SET Name='" + product.Title + "', Description='" + product.Description + "', UnitPrice=" + product.UnitPrice + ", Quantity=" + product.Quantity + ", Image='" + product.ImageUrl + "' WHERE id = " + product.ProductId + "";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // If at least one row was affected, the update was successful
                    if (rowsAffected > 0)
                    {
                        status = true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }

                return status;          
        }

        public  void Delete(int id)
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "DELETE from products_shruti WHERE Id="+id;
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public  void GetCount()
        {

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT COUNT(*) from products_shruti";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                Console.WriteLine("Records {0}", count, 56);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
        }

        public  List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_shruti";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int Id = int.Parse(dr["Id"].ToString());
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());
                    int unitprice = int.Parse(dr["UnitPrice"].ToString());

                    Product product = new Product();
                    product.ProductId = Id;
                    product.Title = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    product.UnitPrice = unitprice;

                    products.Add(product);

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
            return products;

        }

        public  Product GetById(int id)
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_shruti WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            Product p = new Product();
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int Id = int.Parse(dr["Id"].ToString());
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());
                    int UnitPrice = int.Parse(dr["UnitPrice"].ToString());

                    p.ProductId = Id;
                    p.Title = name;
                    p.Description = description;
                    p.Quantity = quantity;
                    p.UnitPrice = UnitPrice;

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
           return p;
        }
    }
}
