using Build_IT_Data.Entities.Application;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.Application
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext,
           RoleManager<IdentityRole> roleManager,
           UserManager<ApplicationUser> userManager)
        {
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                   .GetAwaiter()
                   .GetResult();
            }
        }

        private static async Task CreateUsers(ApplicationDbContext dbContext, 
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            DateTime createdDate = DateTime.Now;
            DateTime lastModifiedDate = DateTime.Now;

            string roleAdministrator = "Administrator";
            string roleRegisteredUser = "RegisteredUser";

            if (!await roleManager.RoleExistsAsync(roleAdministrator))
            {
                await roleManager.CreateAsync(new
                IdentityRole(roleAdministrator));
            }
            if (!await roleManager.RoleExistsAsync(roleRegisteredUser))
            {
                await roleManager.CreateAsync(new
                IdentityRole(roleRegisteredUser));
            }

            var userAdmin = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "KokanPL",
                Email = "kania.konrad92@gmail.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

        }
    }
}
