using Core.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Product.Contracts.Services
{
    public interface IProductService
    {
        Task Create(ProductDTO productDTO, CancellationToken cancellationToken);
        Task Update(ProductDTO productDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<ProductDTO>? GetById(int id, CancellationToken cancellationToken);
        Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken);
        Task<List<ProductDTO>?> GetAllByManufacturerId(int manufacturerId, CancellationToken cancellationToken);
        Task<List<ProductDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken);
    }
}
