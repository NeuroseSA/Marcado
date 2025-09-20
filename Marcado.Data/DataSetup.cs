using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marcado.Data;

public static class DataSetup
{
    public static IServiceCollection AddMarcadoData(this IServiceCollection services, IConfiguration cfg)
    {
        var cs = cfg.GetConnectionString("MarcadoDb")!;
        services.AddDbContext<MarcadoDbContext>(opt => opt.UseSqlite(cs));
        return services;
    }
}
