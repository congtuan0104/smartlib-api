using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLibApi.Models.Entity;
using SmartLibApi.Repository;
using SmartLibApi.Repository.Implement;
using SmartLibApi.Repository.Interface;
using SmartLibApi.Services.Implement;
using SmartLibApi.Services.Interface;

namespace SmartLibApi.Extensions;

public static class ServiceExtension
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<RepositoryContext>(configuration.GetConnectionString("DbConnection"));
        // services.AddDbContext<RepositoryContext>(
        //     opts => opts.UseNpgsql(configuration.GetConnectionString("DbConnection")));
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthorService, AuthorService>();
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(option =>
        {
            option.Password.RequireDigit = true;
            option.Password.RequireLowercase = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequiredLength = 10;

            option.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }
}