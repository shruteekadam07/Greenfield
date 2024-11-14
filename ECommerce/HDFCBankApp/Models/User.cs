using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDFCBankApp.Models
{
    public class User
    {
        public static int i = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public string Location { get; set; }
        public User()
        {
            i++;
            this.Id = i;
        }
    }
}