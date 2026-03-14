using MarkDemo.Domain.Entities;

namespace MarkDemo.Domain.Interfaces;

public interface ISalesOrderRepository
{
    // get all sales order headers
    Task<IEnumerable<SalesOrderHeader>> GetSalesOrderHeadersAsync(CancellationToken cancellationToken = default);

    // get sales order header by id
    Task<SalesOrderHeader?> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default);

    SalesOrderHeader? AddSalesOrderHeader(SalesOrderHeader entityForCreation);
    SalesOrderHeader? UpdateSalesOrderHeader(SalesOrderHeader entity);
    void DeleteSalesOrderHeader(SalesOrderHeader entityForDeletion);

    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}