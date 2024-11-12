using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    // POCO ---> plain old CLR objevt ---> whwn we want to define any business entity which only has variables and not the member functions
    public class Customer
    {
        public int Id {  get; set; }     // auto property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
