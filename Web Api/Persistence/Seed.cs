using Domain.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
   public class Seed
    {
        public static async  Task SeedData(ApplicationDataContext context, UserManager<AppUser>userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName = "H Kabir ",
                        UserName = "HK" ,
                        Email = "hk@mail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Hossaon K. ",
                        UserName = "HKabir" ,
                        Email = "hossain@mail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Hossain ",
                        UserName = "hossain" ,
                        Email = "kabir@mail.com"
                    }
                };

                foreach(var user in users)
                {
                 await   userManager.CreateAsync(user, "admin123#@");
                }
            }

        }
    }
}
