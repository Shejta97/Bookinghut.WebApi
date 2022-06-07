using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public class Users
    {
        [Key]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public enum UserRoles { Admin, Organizer, Customer }
    }
}
