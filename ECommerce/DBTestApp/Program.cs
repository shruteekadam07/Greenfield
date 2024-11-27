using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;  //import librarry
using System.Data.SqlClient; //use for microsoft sql server

namespace DBTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //interfacess provided
            string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";
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
                    Console.WriteLine(name + "  " + description + " " + quantity);
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



        }
    }
}
