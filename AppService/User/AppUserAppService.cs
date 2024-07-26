using Core.User.Contracts.AppServices;
using Core.User.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppService.User
{
    public class AppUserAppService : IAppUserAppService
    {
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<AppUserAppService> _logger;
        public AppUserAppService(SignInManager<AppUser> signinManager
            , UserManager<AppUser> userManager
            , IHttpContextAccessor contextAccessor,
            ILogger<AppUserAppService> logger)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }


        public async Task<int>? LoggedInUserId()
        {
            var userName = _contextAccessor.HttpContext.User.Identity.Name;
            if (userName != null)
            {
                _logger.LogInformation("user logged in");
            }
            else
            {
                _logger.LogError("user is not logged in");
            }
            var user = await _userManager.FindByNameAsync(userName);
            var id = user.Id;
            return id;
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _userManager.Users
                .Include(x=>x.Admin)
                .Include(x=>x.Customer)
                .Include(x=>x.Manufacturer)
                .FirstOrDefaultAsync(x=>x.Email == email);
            var result = await _signinManager.PasswordSignInAsync(email, password, true, lockoutOnFailure:false);
            return result.Succeeded;
        }

        public async Task<List<IdentityError>> Register(string email, string password, string fullname, string phonenumber, bool IsCustomer, bool IsManufacturer, bool isAdmin)
        {
            var role = string.Empty;
            var user = CreateUser();
            if(IsCustomer)
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                    Email = email,
                    Password = password,
                    Name = fullname,
                    PhoneNumber = phonenumber,
                };
            }
            if(IsManufacturer)
            {
                role = "Manufacturer";
                user.Manufacturer = new Manufacturer()
                {
                    Email = email,
                    Name = fullname,
                    PhoneNumber = phonenumber,
                    Password = password,
                };
            }
            if (isAdmin)
            {
                role = "Admin";
                user.Admin = new Admin()
                {
                    Password = password,
                    Name = fullname,
                    PhoneNumber = phonenumber,
                    Email = email,
                };
            }

            var result = await _userManager.CreateAsync(user,password);
            if (IsCustomer)
            {
                var userIdCustomer = user.Customer!.Id;
                await _userManager.AddClaimAsync(user,new Claim("userIdCustomer",userIdCustomer.ToString()));
            }
            if (IsManufacturer)
            {
                var userIdManufacturer = user.Manufacturer!.Id;
                await _userManager.AddClaimAsync(user,new Claim("userIdManufacturer",userIdManufacturer.ToString()));
            }
            if (isAdmin)
            {
                var userAdminId = user.Admin!.Id;
                await _userManager.AddClaimAsync(user,new Claim("userAdminId",userAdminId.ToString()));
            }

            if (result.Succeeded) await _userManager.AddToRoleAsync(user, role);
            return (List<IdentityError>)result.Errors;
        }

        public async Task SignOutUser()
        {
            await _signinManager.SignOutAsync();
        }

        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                                                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
