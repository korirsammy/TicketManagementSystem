using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories
{
    public class CatgoryList
    {
         public class Query: IRequest<List<Category>>{}
        
         public class Handler : IRequestHandler<Query, List<Category>>
        {
             private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                 var categories = await _context.Categories.ToListAsync();

                return categories;
            }
        }
               
    }
}