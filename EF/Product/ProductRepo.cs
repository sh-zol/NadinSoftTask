using AppDBContext.Context;
using Core.Product.Contracts.Repositories;
using Core.Product.DTOs;
using Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Product
{
    public class ProductRepo : IProductRepo
    {
        private readonly DBContext _context;
        private readonly ILogger<ProductRepo> _logger;

        public ProductRepo(DBContext context
            ,ILogger<ProductRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(ProductDTO productDTO,CancellationToken cancellationToken)
        {
            var product = new Core.Product.Entities.Product()
            {
                Name = productDTO.Name,
                ManufacturerEmail = productDTO.ManufacturerEmail,
                ManufacturerPhoneNumber = productDTO.ManufacturerPhoneNumber,
                ProduceDate = DateTime.Now,
                // Manufacturer = productDTO.Manufacturer,
                ManufacturerId = productDTO.ManufacturerId,
                IsAvaiable = productDTO.IsAvaiable,
            };
            await _context.Products.AddAsync(product,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Product added");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"product with the id of {id} has been deleted");
            }
            else
            {
                _logger.LogError("product was not found");
            }

        }

        public async Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Products.AsNoTracking().Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                ManufacturerEmail = x.ManufacturerEmail,
                ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                ProduceDate = x.ProduceDate,
                ManufacturerId = x.ManufacturerId,
                Customer = x.Customer,
                CustomerId = x.CustomerId,
                IsAvaiable = x.IsAvaiable,
                Manufacturer = x.Manufacturer
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no product was found");
                return new List<ProductDTO>();
            }
        }

        public async Task<List<ProductDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            var list = await _context.Products.AsNoTracking().Where(x => x.CustomerId == customerId)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerEmail = x.ManufacturerEmail,
                    ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                    ProduceDate = x.ProduceDate,
                    ManufacturerId = x.ManufacturerId,
                    Customer = x.Customer,
                    CustomerId = x.CustomerId,
                    IsAvaiable = x.IsAvaiable,
                    Manufacturer = x.Manufacturer
                }).ToListAsync(cancellationToken);
            if (list != null) { return list; }
            else
            {
                _logger.LogError("no product was found");
                return new List<ProductDTO>();
            }
        }

        public async Task<List<ProductDTO>?> GetAllByManufacturerId(int manufacturerId, CancellationToken cancellationToken)
        {
            var list = await _context.Products.AsNoTracking().Where(x => x.ManufacturerId == manufacturerId)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    ManufacturerEmail = x.ManufacturerEmail,
                    ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                    ProduceDate = x.ProduceDate,
                    ManufacturerId = x.ManufacturerId,
                    Customer = x.Customer,
                    CustomerId = x.CustomerId,
                    IsAvaiable = x.IsAvaiable,
                    Manufacturer = x.Manufacturer,
                    Name = x.Name
                }).ToListAsync(cancellationToken);
            if (list != null) { return list; }
            else
            {
                _logger.LogError("no product was found");
                return new List<ProductDTO>();
            }
        }

        public async Task<ProductDTO> GetById(int id, CancellationToken cancellationToken)
        {
                var product = await _context.Products.AsNoTracking().Where(x => x.Id == id)
                    .Select(x => new ProductDTO
                    {
                        Id = x.Id,
                        ManufacturerEmail = x.ManufacturerEmail,
                        ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                        ProduceDate = x.ProduceDate,
                        ManufacturerId = x.ManufacturerId,
                        Customer = x.Customer,
                        CustomerId = x.CustomerId,
                        IsAvaiable = x.IsAvaiable,
                        Manufacturer = x.Manufacturer,
                        Name = x.Name
                    }).SingleOrDefaultAsync(cancellationToken);
                if(product != null)
                {
                    return product;
                }
            else
            {
                _logger.LogError("no product was found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(ProductDTO productDTO,CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == productDTO.Id,cancellationToken);
            if (product != null)
            {
                product.Name = productDTO.Name;
                product.ManufacturerEmail = productDTO.ManufacturerEmail;
                product.ManufacturerPhoneNumber = productDTO.ManufacturerPhoneNumber;
                product.CustomerId = productDTO.CustomerId;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("product updated");
            }
            else
            {
                _logger.LogError("no product was found");
            }
        }
    }
}
