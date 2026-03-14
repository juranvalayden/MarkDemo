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
            var entities = await _salesOrderRepository.GetSalesOrderHeadersAsync(cancellationToken);
            // business logic applied here
            return Mapper.MapFromEntitiesToDtos(entities);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetSalesOrderHeadersAsync");
            return new List<SalesOrderHeaderDto>();
        }
    }

    public async Task<SalesOrderHeaderDto?> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _salesOrderRepository.GetSalesOrderHeaderByIdAsync(id, cancellationToken);
            // business logic applied here
            return entity == null
                ? null
                : Mapper.MapFromEntityToDto(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred GetSalesOrderHeadersAsync");
            return null;
        }
    }

    public async Task<SalesOrderHeaderDto> AddSalesOrderHeaderAsync(SalesOrderHeaderForCreationDto salesOrderHeaderForCreationDto,
        CancellationToken cancellationToken = default)
    {
        var entityToBeCreated = Mapper.MapFromDtoToEntity(salesOrderHeaderForCreationDto);

        var createdEntity = _salesOrderRepository.AddSalesOrderHeader(entityToBeCreated);

        var hasSaved = await _salesOrderRepository.SaveChangesAsync(cancellationToken);

        if (!hasSaved)
        {
            _logger.LogError("Has not saved.... AddSalesOrderHeaderAsync");
        }

        var mappedDto = Mapper.MapFromEntityToDto(createdEntity);
        return mappedDto;
    }

    public async Task<SalesOrderHeaderDto> UpdateSalesOrderHeaderAsync(int id, SalesOrderHeaderForUpdateDto salesOrderHeaderForUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var entityToBeUpdated = await _salesOrderRepository.GetSalesOrderHeaderByIdAsync(id, cancellationToken);

        if (entityToBeUpdated == null) return null;

        var updatedEntity = Mapper.UpdateEntityWithDto(entityToBeUpdated, salesOrderHeaderForUpdateDto);

        var dbUpdatedEntity = _salesOrderRepository.UpdateSalesOrderHeader(updatedEntity);

        var hasSaved = await _salesOrderRepository.SaveChangesAsync(cancellationToken);

        if (!hasSaved)
        {    
            _logger.LogError("Has not saved.... UpdateSalesOrderHeaderAsync");
        }

        var mappedDto = Mapper.MapFromEntityToDto(dbUpdatedEntity);
        return mappedDto;
    }

    public async Task<bool> DeleteSalesOrderHeaderAsync(int id, CancellationToken cancellationToken = default)
    {
        var entityToBeDeleted = await _salesOrderRepository.GetSalesOrderHeaderByIdAsync(id, cancellationToken);

        if (entityToBeDeleted == null) return false;

        _salesOrderRepository.DeleteSalesOrderHeader(entityToBeDeleted);

        return await _salesOrderRepository.SaveChangesAsync(cancellationToken);
    }
}
