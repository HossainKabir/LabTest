using Application.Interfaces;
using Application.Validators;
using Domain.Models.Entity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).Password();
            }
        }
        public class Handler : IRequestHandler<Command, User>
        {
            private readonly ApplicationDataContext _context;
            private readonly UserManager<AppUser> _userManager;
            IJwtGenerator _jwtGenerator;
            public Handler(ApplicationDataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public IJwtGenerator JwtGenerator { get; }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                    throw new Exception();

                if (await _context.Users.Where(x => x.UserName == request.Email).AnyAsync())
                    throw new Exception();


                var user = new AppUser
                {
                    Email = request.Email,
                    UserName = request.Email,
                    Address = request.Address,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                    return new User
                    {
                        FullName = user.FirstName + " " + user.LastName,
                        UserName = user.UserName,
                    };
                throw new Exception("Problem saving changes");
            }
        }
    }
}
