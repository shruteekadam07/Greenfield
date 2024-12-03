using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Services
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(User u);
        //string ForgotPassword(string username);
        //bool ResetPassword(string username, string oldpassword, string newpassword);
        User GetById(int id);
        List<User> GetAllUsers();
        // List<Credential> GetAllCredentials();
        // bool Delete(int id);
    }
}