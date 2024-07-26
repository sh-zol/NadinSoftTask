﻿using Core.User.Contracts.Repositories;
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

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetAdmin(id, cancellationToken);
        }

        public async Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetCustomer(id, cancellationToken);
        }

        public async Task<ManufacturerDTO>? GetManufacturer(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetManufacturer(id, cancellationToken);
        }
    }
}
