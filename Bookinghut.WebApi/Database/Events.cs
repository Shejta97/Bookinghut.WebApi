﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public class Events
    {
        [Key]

        public int ID { get; set; }
        [ForeignKey("CurentEventID")]

        public int CurentEventID { get; set; }
        public CurrentEvent CurrentEvent { get; set; }
        public string Name { get; set; }
        [ForeignKey("VenueID")]

        public int VenueID { get; set; }
        public Venue Venue { get; set; }
        public DateTime Timing { get; set; }
        public float Price { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
