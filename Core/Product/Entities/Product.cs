using Core.User.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Product.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(11)]
        public string ManufacturerPhoneNumber { get; set; }
        [StringLength(20)]
        public string ManufacturerEmail { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvaiable { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
