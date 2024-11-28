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

namespace ECommerceDALLib
{
    public class DBManager 
    {
        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public static bool Insert(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
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

        public static bool Update(Product product)
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
                string query = "UPDATE products SET Title = @Title, Description = @Description, UnitPrice = @UnitPrice, Quantity = @Quantity, ImageUrl = @ImageUrl WHERE 'ProductId = @ProductId";
                IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
                // Add parameters to avoid SQL injection
                cmd.Parameters.Add(new SqlParameter("@Title", product.Title));
                cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@UnitPrice", product.UnitPrice));
                cmd.Parameters.Add(new SqlParameter("@Quantity", product.Quantity));
                cmd.Parameters.Add(new SqlParameter("@Image", product.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));

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

        public static void Delete(int id)
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "DELETE from products_shruti WHERE Id=2";
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

        public static void GetCount()
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


        public static List<Product> GetAll()
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
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());
                    int unitprice = int.Parse(dr["UnitPrice"].ToString());
                    int id = int.Parse(dr["Id"].ToString());



                    Product product = new Product();
                    product.Title = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    product.UnitPrice = unitprice;
                    product.ProductId = id;


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

        public static Product GetById(int id)
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            Product product = new Product();
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string title = dr["Title"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());
                   
                    product.Title = title;
                    product.Description = description;
                    product.Quantity = quantity;
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
           return product;
        }
    }
}
