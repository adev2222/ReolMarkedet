using Application.Common.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        
        
        services.AddScoped(typeof(IGenericInterface<>), typeof(GenericRepository<>));
        services.AddScoped<IShelfRepository, ShelfRepository>();
        services.AddScoped<IShelfRenterRepository, ShelfRenterRepository>();
        services.AddScoped<ILeaseAgreementRepository, LeaseAgreementRepository>();       
        return services;

    }
}