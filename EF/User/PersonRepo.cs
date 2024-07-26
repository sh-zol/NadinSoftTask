using AppDBContext.Context;
using Core.User.Contracts.Repositories;
using Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.User
{
    public class PersonRepo : IPersonRepo
    {
        private readonly DBContext _context;

        public PersonRepo(DBContext context)
        {
            _context = context;
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
