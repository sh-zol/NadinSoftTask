using Core.Product.Contracts.Repositories;
using Core.Product.Contracts.Services;
using Core.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
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
