using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public class Venue
    {
        [Key]

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
