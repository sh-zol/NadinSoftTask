
using AppDBContext.Context;
using AppService.Product;
using AppService.User;
using Core.Product.Contracts.AppServices;
using Core.Product.Contracts.Repositories;
using Core.Product.Contracts.Services;
using Core.SiteSettings;
using Core.User.Contracts.AppServices;
using Core.User.Contracts.Repositories;
using Core.User.Contracts.Services;
using Core.User.Entities;
using EF.Product;
using EF.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service.Product;
using Service.User;
using System.Text.Json.Serialization;

namespace NadinSoftTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DI
            builder.Services.AddScoped<IPersonRepo, PersonRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPersonAppService, PersonAppService>();
            builder.Services.AddScoped<IProductAppService, ProductAppService>();
            builder.Services.AddScoped<IAppUserAppService, AppUserAppService>();
            #endregion

            #region SiteSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var sitesetting = config.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            builder.Services.AddSingleton(sitesetting);
            #endregion

            #region EF Config
            builder.Services.AddDbContext<DBContext>(o => o.UseSqlServer(sitesetting.SqlConfig.ConnectionString));
            #endregion

            #region Log Config
           // builder.Logging.ClearProviders();
            builder.Host.ConfigureLogging(loggingbuilder =>
            {
                loggingbuilder.ClearProviders();
            }).UseSerilog((context, config) =>
            {
                config.WriteTo.Seq("http://localhost:5341", Serilog.Events.LogEventLevel.Information);
            });
            #endregion

            #region Identity Config
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(o =>
            {
                o.SignIn.RequireConfirmedAccount = false;
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            }
            ).AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<DBContext>();
            #endregion

            #region Json
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                }
                );
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors(Option =>
            {
                Option.AllowAnyMethod();
                Option.AllowAnyHeader();
                Option.AllowAnyOrigin();
            });

            app.Run();
        }
    }
}
