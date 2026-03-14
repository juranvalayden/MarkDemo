using MarkDemo.Application.Dtos;
using MarkDemo.Domain.Entities;

namespace MarkDemo.Application.Mappers;

public static class Mapper
{
    public static SalesOrderHeader MapFromDtoToEntity(SalesOrderHeaderDto dto)
    {
        return new SalesOrderHeader
        {
            Id = dto.Id,
            RevisionNumber = dto.RevisionNumber,
            OrderDate = dto.OrderDate,
            DueDate = dto.DueDate,
            ShipDate = dto.ShipDate,
            Status = dto.Status,
            OnlineOrderFlag = dto.OnlineOrderFlag,
            SalesOrderNumber = dto.SalesOrderNumber,
            PurchaseOrderNumber = dto.PurchaseOrderNumber,
            AccountNumber = dto.AccountNumber,
            CustomerId = dto.CustomerId,
            ShipToAddressId = dto.ShipToAddressId,
            BillToAddressId = dto.BillToAddressId,
            ShipMethod = dto.ShipMethod,
            CreditCardApprovalCode = dto.CreditCardApprovalCode,
            SubTotal = dto.SubTotal,
            TaxAmt = dto.TaxAmt,
            Freight = dto.Freight,
            TotalDue = dto.TotalDue,
            Comment = dto.Comment,
            RowGuid = dto.RowGuid,
            ModifiedDate = dto.ModifiedDate
        };
    }

    public static SalesOrderHeaderDto MapFromEntityToDto(SalesOrderHeader entity)
    {
        return new SalesOrderHeaderDto
        {
            Id = entity.Id,
            RevisionNumber = entity.RevisionNumber,
            OrderDate = entity.OrderDate,
            DueDate = entity.DueDate,
            ShipDate = entity.ShipDate,
            Status = entity.Status,
            OnlineOrderFlag = entity.OnlineOrderFlag,
            SalesOrderNumber = entity.SalesOrderNumber,
            PurchaseOrderNumber = entity.PurchaseOrderNumber,
            AccountNumber = entity.AccountNumber,
            CustomerId = entity.CustomerId,
            ShipToAddressId = entity.ShipToAddressId,
            BillToAddressId = entity.BillToAddressId,
            ShipMethod = entity.ShipMethod,
            CreditCardApprovalCode = entity.CreditCardApprovalCode,
            SubTotal = entity.SubTotal,
            TaxAmt = entity.TaxAmt,
            Freight = entity.Freight,
            TotalDue = entity.TotalDue,
            Comment = entity.Comment,
            RowGuid = entity.RowGuid,
            ModifiedDate = entity.ModifiedDate,
            SalesOrderDetails = entity.SalesOrderDetails.Select(s => new SalesOrderDetailDto
            {
                Id = s.Id,
                OrderQty = s.OrderQty,
                ProductId = s.ProductId,
                UnitPrice = s.UnitPrice,
                UnitPriceDiscount = s.UnitPriceDiscount,
                LineTotal = s.LineTotal,
                RowGuid = s.RowGuid,
                ModifiedDate = s.ModifiedDate,
                SalesOrderHeaderId = s.SalesOrderHeaderId
            }).ToList()
        };
    }

    public static IEnumerable<SalesOrderHeaderDto> MapFromEntitiesToDtos(IEnumerable<SalesOrderHeader> entities)
    {
        return entities.Select(entity => new SalesOrderHeaderDto
        {
            Id = entity.Id,
            RevisionNumber = entity.RevisionNumber,
            OrderDate = entity.OrderDate,
            DueDate = entity.DueDate,
            ShipDate = entity.ShipDate,
            Status = entity.Status,
            OnlineOrderFlag = entity.OnlineOrderFlag,
            SalesOrderNumber = entity.SalesOrderNumber,
            PurchaseOrderNumber = entity.PurchaseOrderNumber,
            AccountNumber = entity.AccountNumber,
            CustomerId = entity.CustomerId,
            ShipToAddressId = entity.ShipToAddressId,
            BillToAddressId = entity.BillToAddressId,
            ShipMethod = entity.ShipMethod,
            CreditCardApprovalCode = entity.CreditCardApprovalCode,
            SubTotal = entity.SubTotal,
            TaxAmt = entity.TaxAmt,
            Freight = entity.Freight,
            TotalDue = entity.TotalDue,
            Comment = entity.Comment,
            RowGuid = entity.RowGuid,
            ModifiedDate = entity.ModifiedDate,
            SalesOrderDetails = entity.SalesOrderDetails.Select(s => new SalesOrderDetailDto
            {
                Id = s.Id,
                OrderQty = s.OrderQty,
                ProductId = s.ProductId,
                UnitPrice = s.UnitPrice,
                UnitPriceDiscount = s.UnitPriceDiscount,
                LineTotal = s.LineTotal,
                RowGuid = s.RowGuid,
                ModifiedDate = s.ModifiedDate,
                SalesOrderHeaderId = s.SalesOrderHeaderId
            })
                    .ToList()
        })
            .ToList();
    }

    public static IEnumerable<SalesOrderHeader> MapFromDtosToEntities(IEnumerable<SalesOrderHeaderDto> dtos)
    {
        return dtos.Select(dto => new SalesOrderHeader
        {
            Id = dto.Id,
            RevisionNumber = dto.RevisionNumber,
            OrderDate = dto.OrderDate,
            DueDate = dto.DueDate,
            ShipDate = dto.ShipDate,
            Status = dto.Status,
            OnlineOrderFlag = dto.OnlineOrderFlag,
            SalesOrderNumber = dto.SalesOrderNumber,
            PurchaseOrderNumber = dto.PurchaseOrderNumber,
            AccountNumber = dto.AccountNumber,
            CustomerId = dto.CustomerId,
            ShipToAddressId = dto.ShipToAddressId,
            BillToAddressId = dto.BillToAddressId,
            ShipMethod = dto.ShipMethod,
            CreditCardApprovalCode = dto.CreditCardApprovalCode,
            SubTotal = dto.SubTotal,
            TaxAmt = dto.TaxAmt,
            Freight = dto.Freight,
            TotalDue = dto.TotalDue,
            Comment = dto.Comment,
            RowGuid = dto.RowGuid,
            ModifiedDate = dto.ModifiedDate,
            SalesOrderDetails = dto.SalesOrderDetails.Select(s => new SalesOrderDetail
            {
                Id = s.Id,
                OrderQty = s.OrderQty,
                ProductId = s.ProductId,
                UnitPrice = s.UnitPrice,
                UnitPriceDiscount = s.UnitPriceDiscount,
                LineTotal = s.LineTotal,
                RowGuid = s.RowGuid,
                ModifiedDate = s.ModifiedDate,
                SalesOrderHeaderId = s.SalesOrderHeaderId
            }).ToList()
        }).ToList();
    }
}
