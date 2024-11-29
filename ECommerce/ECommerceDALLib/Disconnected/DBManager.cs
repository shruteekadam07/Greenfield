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
using System.Data.Common;

namespace ECommerceDALLib.DisconnectedDataAccess
{
    public class DBManager 
    {
        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public static bool Insert(Product product)
        {
            bool status = false;
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_shruti";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataset = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];

            DataRowCollection rows = table.Rows;
            // DataRow foundrow = null;
            DataRow newrow = table.NewRow();
            // newrow=foundrow;
            newrow["Id"] = product.ProductId;
            newrow["Name"] = product.Title;
            newrow["Description"] = product.Description;
            newrow["Quantity"] = product.Quantity;
            newrow["Image"] = product.ImageUrl;
            newrow["UnitPrice"] = product.UnitPrice;

            rows.Add(newrow);

            adapter.Update(dataset);
            status = true;
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_shruti";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataset = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];

            DataRowCollection rows = table.Rows;
            DataRow foundrow = null;
            // DataRow newrow = null;
            foreach (DataRow row in rows)
            {
                int rowId = int.Parse(row["Id"].ToString());
                if (rowId == product.ProductId)
                {
                    foundrow = row;
                }
            }

            if (foundrow != null)
            {
                // newrow=foundrow;
                foundrow["Id"] = product.ProductId;
                foundrow["Name"] = product.Title;
                foundrow["Description"] = product.Description;
                foundrow["Quantity"] = product.Quantity;
                foundrow["Image"] = product.ImageUrl;
                foundrow["UnitPrice"] = product.UnitPrice;
            }
            adapter.Update(dataset);
            status = true;
            return status;
        }

        public static void Delete(int id)
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products_shruti";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataset = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);

            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];

            DataRowCollection rows = table.Rows;
            DataRow foundrow = null;
            foreach (DataRow row in rows)
            {
                int rowId = int.Parse(row["Id"].ToString());
                if (rowId == id)
                {
                    foundrow = row;
                }
            }

            if (foundrow != null)
            {
                foundrow.Delete();

            }
            adapter.Update(dataset);



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
            DataSet dataset = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                int id = int.Parse(row["Id"].ToString());
                string name = row["Name"].ToString();
                string description = row["Description"].ToString();
                double unitprice = double.Parse(row["UnitPrice"].ToString()) ;
                int quantity = int.Parse(row["Quantity"].ToString());
                string image = row["Image"].ToString();
                Product product = new Product();
                product.ProductId = id;
                product.Title = name;
                product.Description = description;
                product.Quantity = quantity;
                product.UnitPrice = unitprice;
                product.ImageUrl = image;
                products.Add(product);

            }
            return products;

        }

        public static Product GetById(int id)
        {
            List<Product> products = new List<Product>();
            products = GetAll();
            Product theProduct = products.Find((product) => (product.ProductId == id));

            return theProduct;
        }
    }
}
