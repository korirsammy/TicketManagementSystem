using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {

            if (!context.Tickets.Any())
            {
                var tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        Title = "Issue 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Issue 2 months ago",
                        Category = "Network",
                        City = "Fredericton",
                        Reporter = "Sammy",
                        Severity = "High",
                    },
                      new Ticket
                    {
                        Title = "Issue 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "2 months in future",
                        Category = "Network",
                        City = "Moncton",
                        Reporter = "James",
                        Severity = "High",
                    },
                      new Ticket
                    {
                        Title = "Issue 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "3 months in future",
                        Category = "Network",
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