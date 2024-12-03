using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Entities;
using CRM.Repositories;
using CRM.Repositories.DisConnected;

namespace CRM.Services
{
    public class AuthService : IAuthService
    {
        public List<User> GetAllUsers()
        {
            IAuthRepository authRepository = new AuthRepository();
            List<User> users = authRepository.GetAllUsers();
            return users;
        }

        public User GetById(int id)
        {
            IAuthRepository authRepository = new AuthRepository();
            User foundUser = authRepository.GetById(id);
            return foundUser;
        }


        public bool Login(string username, string password)
        {
            IAuthRepository authRepository = new AuthRepository();
            return authRepository.Login(username, password);
        }

        public bool Register(User u)
        {
            IAuthRepository authRepository = new AuthRepository();
            return authRepository.Register(u);
        }
    }
}