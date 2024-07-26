using Core.User.Contracts.Repositories;
using Core.User.Contracts.Services;
using Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepo _repo;

        public PersonService(IPersonRepo repo)
        {
            _repo = repo;
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
