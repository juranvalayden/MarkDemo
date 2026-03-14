using MarkDemo.Infrastructure.Configurations.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarkDemo.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<SalesDbContext>((_, options) =>
        {
            options.UseSqlServer(connectionString, b =>
            {
                b.MigrationsAssembly(typeof(SalesDbContext).Assembly.FullName);
                b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "SalesLT");
            });
        });
    }
}