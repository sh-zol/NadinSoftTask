using Core.Product.Contracts.AppServices;
using Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NadinSoftTask.Controllers
{
    [ApiController]
    [Authorize(Roles = "Manufacturer")]
    public class ManufacturerController : Controller
    {
        private readonly IPersonAppService _person;
        private readonly IAppUserAppService _appUser;
        private readonly IProductAppService _product;

        public ManufacturerController(IPersonAppService person
            , IAppUserAppService appUser
            , IProductAppService product)
        {
            _person = person;
            _appUser = appUser;
            _product = product;
        }
    }
}
