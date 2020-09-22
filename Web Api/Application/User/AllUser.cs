using Domain.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class AllUser
    {
        public class Query : IRequest<List<User>> { }
        public class Handler : IRequestHandler<Query, List<User>>
        {
            private readonly ApplicationDataContext _context;

            public Handler(ApplicationDataContext context)
            {
                _context = context;
            }
            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Select(e => new User { Id = e.Id, FullName = e.FirstName + " " + e.LastName, Address = e.Address, PhoneNumber = e.PhoneNumber, UserName = e.Email }).ToListAsync();
                return (List<User>)user;
            }
        }
    }
}
