using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Tickets
{
    public class Create
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
               var ticket = new Ticket
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,                 
                    City = request.City,
                    Reporter = request.Reporter,
                    Severity= request.Severity
                };

                _context.Tickets.Add(ticket);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }


    }
}