using BankingPortal.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using BankingPortal.Repositories;
namespace BankingPortal.Services

{

    public class AuthService : IAuthService

    {

        public static string logfile = "D:/BankUsers.json";

        public static string credfile = "D:/BankCredential.json";

        public bool Seeding()

        {

            bool status = false;

            List<User> Users = new List<User>();

            List<credential> credentials = new List<credential>();

            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "shrutikadam@gmail.com", ContactNo = 5667788990, Location = "Pune" });
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "vmarathe@gmail.com", ContactNo = 5667788990, Location = "Pune" });
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "shruti@gmail.com", ContactNo = 5667788990, Location = "Pune" });
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "Shruti@gmail.com", ContactNo = 5667788990, Location = "Pune" });

            credentials.Add(new credential { Email = "shrutikadam@gmail.com", Password = "abc" });

            credentials.Add(new credential { Email = "vmarathe@gmail.com", Password = "abc" });

            credentials.Add(new credential { Email = "shruti@gmail.com", Password = "123" }); 
            credentials.Add(new credential { Email = "shruti@gmail.com", Password = "123" });


            IDataRepository<User> repository = new JsonDataRepository<User>();

            IDataRepository<credential> dataRepository = new JsonDataRepository<credential>();

            status = repository.Serialize(logfile, Users);

            status = false;

            status = dataRepository.Serialize(credfile, credentials);

            return status;

        }

        private static Random random = new Random();

        public static string RandomString(int length)

        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)

                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public bool Register(string firstname, string lastname, string email, long contactno, string location)

        {

            bool status = false;

            List<User> users = new List<User>();

            users = GetAllUsers();

            User u = new User();

            u.FirstName = firstname;

            u.LastName = lastname;

            u.Email = email;

            u.ContactNo = contactno; u.Location = location;

            users.Add(u);

            List<credential> credentials = new List<credential>();

            credentials = GetAllCredentials();

            credential credential = new credential { Email = email, Password = RandomString(6) };

            credentials.Add(credential);

            IDataRepository<User> repository = new JsonDataRepository<User>();

            status = repository.Serialize(logfile, users);

            IDataRepository<credential> dataRepository = new JsonDataRepository<credential>();

            status = dataRepository.Serialize(credfile, credentials);

            return status;

        }

        public string ForgotPassword(string username)

        {

            List<credential> credentials = new List<credential>();

            credentials = GetAllCredentials();

            foreach (credential cred in credentials)

            {

                if (cred.Email == username)

                {

                    return cred.Password;

                }

            }

            return null;

        }

        public List<User> GetAllUsers()

        {

            List<User> users = new List<User>();

            IDataRepository<User> repository = new JsonDataRepository<User>();

            users = repository.Deserialize(logfile);

            return users;

        }

        public User GetById(int Id)

        {

            User user = null;

            List<User> users = GetAllUsers();

            foreach (User u in users)

            {

                if (u.Id == Id)

                {

                    user = u;

                }

            }

            return user;

        }

        public List<credential> GetAllCredentials()

        {

            List<credential> credentials = new List<credential>();

            IDataRepository<credential> repository = new JsonDataRepository<credential>();

            credentials = repository.Deserialize(credfile);

            return credentials;

        }


        public bool Login(string username, string password)

        {

            IDataRepository<credential> repository = new JsonDataRepository<credential>();

            List<credential> credentials = repository.Deserialize(credfile);

            foreach (credential cred in credentials)

            {

                if (cred.Email == username && cred.Password == password)

                {

                    return true;

                }

            }

            return false;

        }

        public bool ResetPassword(string username, string oldpassword, string newpassword)

        {

            List<credential> credentials = new List<credential>();

            credentials = GetAllCredentials();

            foreach (credential cred in credentials)

            {

                if (cred.Email == username & cred.Password == oldpassword)

                {

                    cred.Password = newpassword;

                    IDataRepository<credential> dataRepository = new JsonDataRepository<credential>();

                    return dataRepository.Serialize(credfile, credentials);

                }

            }

            return false;

        }

        public bool Delete(int id)

        {

            User user = GetById(id);

            if (user != null)

            {

                List<User> users = GetAllUsers();

                users.RemoveAll(u => u.Id == id);

                IDataRepository<User> repository = new JsonDataRepository<User>();

                repository.Serialize("D:/BankUsers.json", users);

                return true;

            }

            return false;

        }

    }

}
