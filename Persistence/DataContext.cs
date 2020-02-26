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
         
    }
}