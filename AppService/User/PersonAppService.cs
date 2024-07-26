using Core.User.Contracts.AppServices;
using Core.User.Contracts.Services;
using Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.User
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonService _service;

        public PersonAppService(IPersonService service)
        {
            _service = service;
        }

        public Task<AdminDTO>? GetAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO>? GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ManufacturerDTO>? GetManufacturer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
