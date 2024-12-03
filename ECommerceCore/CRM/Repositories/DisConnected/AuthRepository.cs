using CRM.Entities;
using CRM.Services;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CRM.Repositories.DisConnected
{
    public class AuthRepository : IAuthRepository
    {
        public static string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";

        public bool Login(string username, string password)
        {
            List<User> users = new List<User>();
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from t_users";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataSet = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                string email = row["Email"].ToString();
                string pass = row["Password"].ToString();

                if (username == email && password == pass)
                {
                    return true;
                }

            }
            return false;
        }

        public bool Register(User user)
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * FROM t_users";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataSet = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            DataRowCollection rows = table.Rows;
            DataRow newrow = table.NewRow();
            newrow["id"] = user.Id;
            newrow["first_name"] = user.FirstName;
            newrow["last_name"] = user.LastName;
            newrow["email"] = user.Email;
            newrow["password"] = user.Password;
            rows.Add(newrow);


            adapter.Update(dataSet);
            return true;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from t_users";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataSet = new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string firstname = row["first_name"].ToString();
                string lastname = row["last_name"].ToString();
                string email = row["email"].ToString();
                string password = row["password"].ToString();
                User user = new User();
                user.Id = id;
                user.FirstName = firstname;
                user.LastName = lastname;
                user.Email = email;
                user.Password = password;
                users.Add(user);
            }
            return users;
        }
        public User GetById(int id)
        {
            List<User> users = new List<User>();
            users = GetAllUsers();
            User theUser = users.Find((user) => (user.Id == id));
            return theUser;
        }
    }
}