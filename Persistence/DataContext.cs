using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext:IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options): base(options)
        {            
        }

          public DbSet<Ticket> Tickets { get; set; }
           public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
           base.OnModelCreating(builder);
            
          

         
                
        }
         
    }
}