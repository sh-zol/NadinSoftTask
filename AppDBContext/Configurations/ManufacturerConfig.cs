using Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Configurations
{
    public class ManufacturerConfig : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasData(
                new List<Manufacturer>
                {
                    new Manufacturer()
                    {
                        Id = 1,
                        AppUserId = 3,
                        Email = "sadradn@gmail.com",
                        Name = "Sadra",
                        Password = "sh19451960",
                        PhoneNumber = "09113195467",
                    }
                }
                );
        }
    }
}
