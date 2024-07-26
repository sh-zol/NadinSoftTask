using Core.User.Contracts.AppServices;
using Core.User.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.User
{
    public class AppUserAppService : IAppUserAppService
    {
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        // private readonly ILogger<AppUserAppService> _logger;
        public AppUserAppService(SignInManager<AppUser> signinManager
            , UserManager<AppUser> userManager
            , IHttpContextAccessor contextAccessor)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        
        public Task<int>? LoggedInUserId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<List<IdentityError>> Register(string email, string password, string fullname, string phonenumber, bool IsCustomer, bool IsManufacturer, bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public Task SignOutUser()
        {
            throw new NotImplementedException();
        }
    }
}
