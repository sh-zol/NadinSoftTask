using Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Entities
{
    public class Customer:Person
    {
        public Customer()
        {
            Role = Enums.Role.Customer;
            Products = new List<Product.Entities.Product>();
        }
        public List<Product.Entities.Product>? Products { get; set; }
    }
}
