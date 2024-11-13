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
        public static string logfile = "D:/bankusers.json";
        public static string credfile = "D:/bankcredentials.json";

        public bool Seeding()
        {
            bool status = false;
            List<User> Users = new List<User>();
            List<credential> credentials = new List<credential>();
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "Shrutikadam@gmail.com", ContactNo = "5667788990" });
            credentials.Add(new credential { Email = "shrutikadam@gmail.com", Password = "abc" });

            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<User> repository = new JsonRepository<User>();
            //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            IDataRepository<credential> dataRepository = new JsonRepository<credential>();
            status = repository.Serialize(logfile, Users);
            status = false;
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }
        public string ForgotPassword(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            bool status = false;
            //fetsvh all banking credential
            //verify email and passwird
            //

            return status;  
        }

        public bool Register(User u, string pass)
        {
            throw new NotImplementedException();
        }

        public bool ResetPassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}