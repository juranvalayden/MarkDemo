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

    public async Task<IEnumerable<SalesOrderHeader>> GetAllAsync(CancellationToken cancellationToken = default)
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
            _logger.LogError(e, "Error occurred GetAllAsync getting sale.");
            return [];
        }
    }

    public async Task<SalesOrderHeader?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _salesDbContext
                .Set<SalesOrderHeader>()
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetByIdAsync getting {Id}.", id);
            return null;
        }
    }

    public SalesOrderHeader Add(SalesOrderHeader entity)
    {
        return _salesDbContext
            .Set<SalesOrderHeader>()
            .Add(entity)
            .Entity;
    }

    public SalesOrderHeader Update(SalesOrderHeader entity)
    {
        return _salesDbContext
            .Set<SalesOrderHeader>()
            .Update(entity)
            .Entity;
    }

    public void Delete(SalesOrderHeader entityForDeletion)
    {
        _salesDbContext
            .Set<SalesOrderHeader>()
            .Remove(entityForDeletion);
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
