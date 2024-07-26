using Core.Product.Contracts.AppServices;
using Core.Product.Contracts.Services;
using Core.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _service;

        public ProductAppService(IProductService service)
        {
            _service = service;
        }

        public Task Create(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>?> GetAllByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>?> GetAllByManufacturerId(int manufacturerId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
