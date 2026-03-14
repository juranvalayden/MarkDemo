using MarkDemo.Domain.Entities;
using MarkDemo.Domain.Interfaces;
using MarkDemo.Infrastructure.Configurations.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarkDemo.Infrastructure.Repositories;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly ILogger<SalesOrderRepository> _logger;
    private readonly SalesDbContext _salesDbContext;

    public SalesOrderRepository(ILogger<SalesOrderRepository> logger, SalesDbContext salesDbContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesDbContext = salesDbContext ?? throw new ArgumentNullException(nameof(salesDbContext));
    }

    public async Task<IEnumerable<SalesOrderHeader>> GetSalesOrderHeadersAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _salesDbContext.SalesOrderHeaders
                .Include(soh => soh.SalesOrderDetails)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return entities;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetSalesOrderHeadersAsync getting sale.");
            return [];
        }
    }

    public async Task<SalesOrderHeader?> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _salesDbContext.SalesOrderHeaders
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            return entity;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetSalesOrderHeaderByIdAsync getting {Id}.", id);
            return null;
        }
    }

    public SalesOrderHeader? AddSalesOrderHeader(SalesOrderHeader entity)
    {
        _salesDbContext.SalesOrderHeaders.Add(entity);
        return entity;
    }

    public SalesOrderHeader? UpdateSalesOrderHeader(SalesOrderHeader entity)
    {
        _salesDbContext.SalesOrderHeaders.Update(entity);
        return entity;
    }

    public void DeleteSalesOrderHeader(SalesOrderHeader entityForDeletion)
    {
        _salesDbContext.SalesOrderHeaders.Remove(entityForDeletion);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _salesDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred SaveChangesAsync.");
            return false;
        }
    }
}
