using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Mongo.Services.Identity.DbContexts;
using Mongo.Services.Identity.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Mongo.Services.Identity.Initializer
{
    public interface IDbInitializer
    {
        void Initilize();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initilize()
        {
            if (_roleManager.FindByNameAsync(StaticDictionary.Admin).Result == null)
            {
                //first time
                _roleManager.CreateAsync(new IdentityRole(StaticDictionary.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDictionary.Customer)).GetAwaiter().GetResult();
            }
            else
                return;

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1111",
                FirstName = "Admin",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, StaticDictionary.Admin).GetAwaiter().GetResult();

            var tmp1= _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDictionary.Admin)
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1111",
                FirstName = "Cust",
                LastName = "Cust"
            };

            _userManager.CreateAsync(customerUser, "Cust123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, StaticDictionary.Admin).GetAwaiter().GetResult();

            var tmp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{customerUser.FirstName} {customerUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDictionary.Customer)
            }).Result;
        }
    }
}
