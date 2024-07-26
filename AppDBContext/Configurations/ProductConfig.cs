using Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x=>x.ManufacturerPhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(x=>x.ManufacturerEmail)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasOne(x => x.Manufacturer)
                .WithMany(x => x.Products);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Products);

            builder.HasData(
                new List<Product>
                {
                    new Product
                    {
                        Id = 1 ,
                        IsAvaiable = true ,
                        ManufacturerEmail = "sadradn@gmail.com",
                        ManufacturerId = 1 ,
                        ManufacturerPhoneNumber = "09113195467",
                        Name = "GPU",
                        ProduceDate = DateTime.Now,
                    }
                }
                );
        }
    }
}
