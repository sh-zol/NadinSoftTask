using Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Entities
{
    public class Manufacturer:Person
    {
        public Manufacturer()
        {
            Role = Enums.Role.Manufacturer;
            Products = new List<Product.Entities.Product>();
        }
        public List<Product.Entities.Product>? Products { get; set; }
    }
}
