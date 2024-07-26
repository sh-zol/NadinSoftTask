using AppDBContext.Context;
using Core.User.Contracts.Repositories;
using Core.User.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PersonRepo> _logger;

        public PersonRepo(DBContext context,
            ILogger<PersonRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.AsNoTracking()
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id)
                .Select(x => new AdminDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                }).SingleOrDefaultAsync(cancellationToken);
            if(admin != null)
            {
                return admin;
            }
            else
            {
                _logger.LogError("no user was found");
                throw new NullReferenceException();
            }
        }

        public async Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking()
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id)
                .Select(x => new CustomerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Products = x.Products
                }).SingleOrDefaultAsync(cancellationToken);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                _logger.LogError("no user was found");
                throw new NullReferenceException();
            }
        }

        public async Task<ManufacturerDTO>? GetManufacturer(int id, CancellationToken cancellationToken)
        {
            var manufacturer = await _context.Manufacturers.AsNoTracking()
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id)
                .Select(x => new ManufacturerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Products = x.Products
                }).SingleOrDefaultAsync(cancellationToken);
            if(manufacturer != null)
            {
                return manufacturer;
            }
            else
            {
                _logger.LogError("no user was found");
                throw new NullReferenceException();
            }
        }
    }
}
