using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {            
        }

          public DbSet<Ticket> Tickets { get; set; }

         protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Ticket>()
            .HasData(
                new Ticket {Id=1,Description="Ticket 1"},
                new Ticket {Id=2,Description="Ticket 2"},
                new Ticket {Id=3,Description="Ticket 3"}
               
            );
        }
    }
}