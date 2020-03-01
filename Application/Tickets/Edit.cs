using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tickets
{
    public class Edit
    {
          public class Command : IRequest
                {                    
                    public Guid Id { get; set; }
                    public string Title { get; set; }
                    public string Description { get; set; }
                 
                    public string City { get; set; }
                    public string Reporter { get; set; }
                    public string Severity { get; set; }
                }
            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Title).NotEmpty();
                    RuleFor(x => x.Description).NotEmpty();
                   
                    RuleFor(x => x.City).NotEmpty();
                    RuleFor(x => x.Reporter).NotEmpty();
                }
            }
                public class Handler : IRequestHandler<Command>
                {
                    private readonly DataContext _context;
                    public Handler(DataContext context)
                    {
                        _context = context;
                    }
                    public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                    {
                        var ticket = await _context.Tickets.FindAsync(request.Id);    

                        if (ticket == null)
                        throw new Exception("Could not find ticket");

                            ticket.Title = request.Title ?? ticket.Title;            
                            ticket.Description = request.Description ?? ticket.Description;           
                                     
                            ticket.City = request.City ?? ticket.City;            
                            ticket.Reporter = request.Reporter ?? ticket.Reporter; 
                            ticket.Severity = request.Reporter ?? ticket.Severity; 
                      
                      
                       
                            var success = await _context.SaveChangesAsync()>0;
                             throw new Exception("Problem saving changes");
                       
                      
                    }
                }
    }
}