using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Database
{
    public partial class BookinghutContext:DbContext
    {
        public BookinghutContext(DbContextOptions<BookinghutContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<CurrentEvent> CurrentEvent { get; set; }
        public virtual DbSet<EventCustomer> EventCustomer { get; set; }
        public virtual DbSet<EventOrganizer> EventOrganizer { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
     .HasOne(e => e.CurrentEvent)
     .WithOne(c => c.Events).HasForeignKey<CurrentEvent>(b=>b.EventID);
            OnModelCreatingPartial(modelBuilder);
        }
           partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
