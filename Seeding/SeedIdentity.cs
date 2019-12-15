// Author: Kevin LePage
// Date: 10/22/2019

using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;


namespace fa19projectgroup16.Seeding
{
    //add identity data
    public static class SeedIdentity
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Adds the needed roles
            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //check to see if the admin has been added
            AppUser newUser = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");

            //if admin hasn't been created, then add them
           
            if (newUser == null)
            {
                newUser = new AppUser();
                newUser.UserName = "admin@example.com";
                newUser.Email = "admin@example.com";
                newUser.FirstName = "Admin";
                newUser.LastName = "";
                newUser.PhoneNumber = "555-555-5555";
                newUser.Birthday = new DateTime(2000, 1, 1);
                newUser.City = "Austin";
                newUser.State = "TX";
                newUser.Street = "100 admin st.";
                newUser.Zip = "11111";
                newUser.Is_Employed = true;
                newUser.Is_enabled = true;

                //NOTE: This creates the user - "Abc123!" is the password for this user
                var result = await _userManager.CreateAsync(newUser, "Abc123!");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                newUser = _db.Users.FirstOrDefault(u => u.UserName == "admin@example.com");
            }

            //Adds the new user we just created to the Admin role
            if (await _userManager.IsInRoleAsync(newUser, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser, "Manager");
            }

            //saves changes
            _db.SaveChanges();
        }
    }
}