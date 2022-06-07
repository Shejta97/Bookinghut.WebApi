using System;
using System.Collections.Generic;
using System.Text;

namespace Bookinghut.Models.Request
{
    public class UserUpsertRequestdto
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
