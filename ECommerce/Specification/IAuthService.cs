using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCOLib;

namespace Specification

{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(User u,string pass);
        string ForgotPassword(string username);
        bool ResetPassword(string username, string oldPassword,string newPassword);
        List<User> GetAllUsers();
        List<credential> GetAllCredentials();
    }
}
