using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices // this method is in program.cs
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container 
        services.AddDbContext<ApplicationDbContext>(opt => 
            opt.UseSqlServer(connectionString));

        return services; 
    }
}
