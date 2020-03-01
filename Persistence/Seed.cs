using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                 var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Sammy",
                        UserName = "Sammy",
                        Email = "sammy@test.com",
                        isAdmin=true
                    },
                    new AppUser
                    {
                        DisplayName = "Jeff",
                        UserName = "jeff",
                        Email = "jeff@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    }
                };

                foreach (var user in users) 
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
                
            }
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                      
                        Name = "Network"                       
                    },
                      new Category
                    {
                      
                        Name = "Application"                       
                    },
                    new Category
                    {
                       
                        Name = "Desktop"                       
                    },
                  
                };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
            }
            if (!context.Tickets.Any())
            {
               var categoryList= context.Categories.ToList();
                var tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        Title = "Issue 1",                       
                        Description = "Issue 2 months ago",                      
                        City = "Fredericton",
                        Reporter = "Sammy",
                        Severity = "High",
                    },
                      new Ticket
                    {
                        Title = "Issue 2",                   
                        Description = "2 months in future",                    
                        City = "Moncton",
                        Reporter = "James",
                        Severity = "High",
                    },
                      new Ticket
                    {
                        Title = "Issue 3",                      
                        Description = "3 months in future",                      
                        City = "St John",
                        Reporter = "Sheila",
                        Severity = "High",
                    }

                  
                };
                    context.Tickets.AddRange(tickets);
                    context.SaveChanges();
            }
        }
    }
}