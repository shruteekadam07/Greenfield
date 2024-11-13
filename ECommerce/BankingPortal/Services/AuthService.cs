using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingPortal.Services
{
    public class AuthService : IAuthService
    {
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