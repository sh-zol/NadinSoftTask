using Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Configurations
{
    public static class AppUserConfig
    {
        public static void SeedRole(ModelBuilder modelBuilder)
        {
            var users = new List<AppUser>()
            {
                new AppUser()
                {
                    Id = 1,
                    UserName = "zolghadrisahin@ymail.com",
                    NormalizedEmail = "ZOLGHADRISAHIN@YMAIL.COM",
                    Email = "zolghadrisahin@ymail.com",
                    NormalizedUserName = "ZOLGHADRISAHIN@YMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09193017184",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },
                new AppUser()
                {
                    Id = 2,
                    UserName = "shakibzolghadri@gmail.com",
                    Email = "shakibzolghadri@gmail.com",
                    NormalizedEmail = "SHAKIBZOLGHADRI@GMAIL.COM",
                    NormalizedUserName = "SHAKIBZOLGHADRI@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09106265176",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new AppUser()
                {
                    Id =3,
                    UserName = "sadradn@gmail.com",
                    Email = "sadradn@gmail.com",
                    NormalizedEmail = "SADRADN@GMAIL.COM",
                    NormalizedUserName = "SADRADN@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "09113195467",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            foreach(var user in users)
            {
                var passwordHasher = new PasswordHasher<AppUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "sh19451960");
                modelBuilder.Entity<AppUser>().HasData(user);
            }

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1 , Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole<int>() { Id = 2 , Name = "Customer", NormalizedName = "CUSTOMER"},
                new IdentityRole<int>() { Id = 3 , Name = "Manufacturer", NormalizedName = "MANUFACTURER"}
                );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2},
                new IdentityUserRole<int>() { RoleId = 3, UserId = 3}
                );
        }
    }
}
