using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BinaryDataRepositoryLib;
using POCOLib;
using Specification;

namespace Services
{
    public class AuthService : IAuthService
    {

        public static string logfile = "logfile.dat";

        public static string credfile = "credentials.dat";

        public bool Seeding()
        {
            bool status = false;
            List<User> Users = new List<User>();
            List<credential> credentials = new List<credential>();
            Users.Add(new User { Id = 1, FirstName = "Ruchi", LastName = "Amale", Email = "amaleruchita@gmail.com", ContactNo = "5667788990" });
            Users.Add(new User { Id = 1, FirstName = "Ruchi", LastName = "Amale", Email = "amaleruchita@gmail.com", ContactNo = "5667788990" });
            Users.Add(new User { Id = 1, FirstName = "Ruchi", LastName = "Amale", Email = "amaleruchita@gmail.com", ContactNo = "5667788990" });
            Users.Add(new User { Id = 1, FirstName = "Ruchi", LastName = "Amale", Email = "amaleruchita@gmail.com", ContactNo = "5667788990" });
            credentials.Add(new credential { Email = "amaleruchita@gmail.com", Password = "abc" });
            credentials.Add(new credential { Email = "amaleruchita@gmail.com", Password = "abc" });
            credentials.Add(new credential { Email = "amaleruchita@gmail.com", Password = "abc" });
            credentials.Add(new credential { Email = "amaleruchita@gmail.com", Password = "abc" });

            IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<credential> dataRepository = new BinaryRepository<credential>();
            status = repository.Serialize(logfile, Users);
            status = false;
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

        public bool Login(string username, string password)
        {
            IDataRepository<credential> repository = new BinaryRepository<credential>();
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

        public bool Register(User u,string pass )
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUsers();
            users.Add(u);
            List<credential> credentials = new List<credential>();
            credentials = GetAllCredentials();
            credential credential = new credential { Email = u.Email, Password = pass };

            credentials.Add(credential);

            IDataRepository<User> repository = new BinaryRepository<User>();
            status = repository.Serialize(logfile, users);

            IDataRepository<credential> dataRepository = new BinaryRepository<credential>();
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            IDataRepository<User> repository = new BinaryRepository<User>();
            users = repository.Deserialize(logfile);
            return users;
        }

        public List<credential> GetAllCredentials()
        {
            List<credential> credentials = new List<credential>();
            IDataRepository<credential> repository = new BinaryRepository<credential>();
            credentials = repository.Deserialize(credfile);
            return credentials;
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
                    IDataRepository<credential> dataRepository = new BinaryRepository<credential>();
                    return dataRepository.Serialize(credfile, credentials);
                }
            }
            return false;
        }
    }
}
