using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public class CurrentEvent
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("EventID")]

        public int EventID { get; set; }
        public Events Events { get; set; }
    }
}
