using Core.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Product.Contracts.Repositories
{
    public interface IProductRepo
    {
        Task Create(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(int id);
        Task<ProductDTO>? GetById(int id);
        Task<List<ProductDTO>?> GetAll();
        Task<List<ProductDTO>?> GetAllByManufacturerId(int manufacturerId);
        Task<List<ProductDTO>?> GetAllByCustomerId(int customerId);

    }
}
