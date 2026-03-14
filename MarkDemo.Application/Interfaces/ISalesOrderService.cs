using MarkDemo.Application.Dtos;

namespace MarkDemo.Application.Interfaces;

public interface ISalesOrderService
{
    // get all sales order headers
    Task<IEnumerable<SalesOrderHeaderDto>> GetSalesOrderHeadersAsync(CancellationToken cancellationToken = default);

    // get sales order header by id
    Task<SalesOrderHeaderDto?> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default);

    // add
    // void AddSalesOrderHeader(SalesOrderHeader entityForCreation);
    // update
    // void UpdateSalesOrderHeader(int id, SalesOrderHeader entityForUpdate);
    // delete
    // void DeleteSalesOrderHeader(int id);

    // this should go into your unit of work
    // Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}