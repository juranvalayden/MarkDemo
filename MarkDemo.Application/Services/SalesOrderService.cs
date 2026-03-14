using MarkDemo.Application.Dtos;
using MarkDemo.Application.Interfaces;
using MarkDemo.Application.Mappers;
using MarkDemo.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace MarkDemo.Application.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly ILogger<SalesOrderService> _logger;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public SalesOrderService(ILogger<SalesOrderService> logger, ISalesOrderRepository salesOrderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesOrderRepository = salesOrderRepository ?? throw new ArgumentNullException(nameof(salesOrderRepository));
    }

    public async Task<IEnumerable<SalesOrderHeaderDto>> GetSalesOrderHeadersAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _salesOrderRepository.GetAllAsync(cancellationToken);
            // business logic applied here
            return Mapper.MapFromEntitiesToDtos(entities);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetAllAsync");
            return new List<SalesOrderHeaderDto>();
        }
    }

    public async Task<SalesOrderHeaderDto?> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _salesOrderRepository.GetByIdAsync(id, cancellationToken);
            // business logic applied here
            return entity == null
                ? null
                : Mapper.MapFromEntityToDto(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetAllAsync");
            return null;
        }
    }

    public async Task<SalesOrderHeaderDto?> AddSalesOrderHeaderAsync(SalesOrderHeaderForCreationDto salesOrderHeaderForCreationDto,
        CancellationToken cancellationToken = default)
    {
        var entityToBeCreated = Mapper.MapFromDtoToEntity(salesOrderHeaderForCreationDto);

        var createdEntity = _salesOrderRepository.Add(entityToBeCreated);

        var hasSaved = await _salesOrderRepository.SaveChangesAsync(cancellationToken);

        if (!hasSaved)
        {
            _logger.LogError("Error creating SalesOrderHeader. AddSalesOrderHeaderAsync.");
            return null;
        }

        var mappedDto = Mapper.MapFromEntityToDto(createdEntity);
        return mappedDto;
    }

    public async Task<SalesOrderHeaderDto?> UpdateSalesOrderHeaderAsync(int id, SalesOrderHeaderForUpdateDto salesOrderHeaderForUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var entity = await _salesOrderRepository.GetByIdAsync(id, cancellationToken);

        if (entity == null)
        {
            _logger.LogError("Not found SalesOrderHeader with {Id}.... UpdateSalesOrderHeaderAsync", id);
            return null;
        }

        var updatedEntity = Mapper.UpdateEntityWithDto(entity, salesOrderHeaderForUpdateDto);

        var dbUpdatedEntity = _salesOrderRepository.Update(updatedEntity);

        var hasSaved = await _salesOrderRepository.SaveChangesAsync(cancellationToken);

        if (!hasSaved)
        {
            _logger.LogError("Error updating SalesOrderHeader with {Id}.... UpdateSalesOrderHeaderAsync", id);
            return null;
        }

        var mappedDto = Mapper.MapFromEntityToDto(dbUpdatedEntity);
        return mappedDto;
    }

    public async Task<bool> DeleteSalesOrderHeaderAsync(int id, CancellationToken cancellationToken = default)
    {
        var entityToBeDeleted = await _salesOrderRepository.GetByIdAsync(id, cancellationToken);

        if (entityToBeDeleted == null)
        {
            _logger.LogError("Not found SalesOrderHeader with {Id}.... DeleteSalesOrderHeaderAsync", id);
            return false;
        }

        _salesOrderRepository.Delete(entityToBeDeleted);

        var hasDeleted = await _salesOrderRepository.SaveChangesAsync(cancellationToken);

        if (!hasDeleted)
        {
            _logger.LogError("Error deleting SalesOrderHeader with {Id}.... DeleteSalesOrderHeaderAsync", id);
        }

        return hasDeleted;
    }
}
