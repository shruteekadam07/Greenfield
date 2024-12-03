using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRM.Entities
{
    [Table("t_users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]

        public string FirstName { get; set; }
        [Column("last_name")]

        public string LastName { get; set; }
        [Column("email")]


        public string Email { get; set; }
        [Column("password")]

        //public string ContactNo { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName;
        }
    }

}