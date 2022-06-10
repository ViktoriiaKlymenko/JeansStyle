
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Services;
using JeansStyle.DAL;
using JeansStyle.DAL.Data.Repositories;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using JeansStyle.BLL.Mapping;
using JeansStyle.WEB.Mapping;

namespace JeansStyle.WEB
{
    public static class StartupConfigurations
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();


            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<ProductSize>, BaseRepository<ProductSize>>();
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<Season>, BaseRepository<Season>>();
            services.AddScoped<IBaseRepository<Gender>, BaseRepository<Gender>>();
            services.AddScoped<IBaseRepository<Size>, BaseRepository<Size>>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();

            return services;
        }

        public static IServiceCollection SetMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new BllMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}