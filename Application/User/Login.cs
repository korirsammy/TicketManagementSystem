using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<AppUser> { 
            public string Email { get; set; }
            public string Password { get; set; }
        }

       
        
    }
}