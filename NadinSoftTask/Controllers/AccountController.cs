using Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoftTask.VMs;

namespace NadinSoftTask.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAppUserAppService _appuser;

        public AccountController(IAppUserAppService appuser)
        {
            _appuser = appuser;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm register)
        {
            var result = await _appuser.Register(register.Email
                , register.Password
                , register.Fullname
                , register.Phonenumber
                , register.IsCustomer
                , register.IsManufacturer
                , register.isAdmin);
            if(result.Count == 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm login)
        {
            var result = await _appuser.Login(login.Email,login.Password);
            if(result == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _appuser.SignOutUser();
            return Ok();
        }


    }
}
