using MarkDemo.Application.Interfaces;
using MarkDemo.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarkDemo.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISalesOrderService, SalesOrderService>();
    }
}
