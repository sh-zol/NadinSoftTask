using Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Contracts.AppServices
{
    public interface IPersonAppService
    {
        Task<AdminDTO>? GetAdmin(int id);
        Task<CustomerDTO>? GetCustomer(int id);
        Task<ManufacturerDTO>? GetManufacturer(int id);
    }
}
