using AppDBContext.Configurations;
using Core.Product.Entities;
using Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Context
{
    public class DBContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AdminConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new ManufacturerConfig());
            builder.ApplyConfiguration(new ProductConfig());
            AppUserConfig.SeedRole(builder);
        }
    }
}
