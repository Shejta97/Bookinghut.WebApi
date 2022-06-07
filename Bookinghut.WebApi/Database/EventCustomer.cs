using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public class EventCustomer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("EventID")]

        public int EventID { get; set; }
        public Events Events { get; set; }
        [ForeignKey("UserID")]

        public int UserID { get; set; }
        public Users Users { get; set; }
        public float TotalCost { get; set; }
    }
}
