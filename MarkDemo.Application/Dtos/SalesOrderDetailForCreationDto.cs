namespace MarkDemo.Application.Dtos;

public record SalesOrderDetailForCreationDto
{
    public short OrderQty { get; init; }
    public int ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal UnitPriceDiscount { get; init; }
    public Guid RowGuid { get; init; }
    public DateTime ModifiedDate { get; init; }
    public int SalesOrderHeaderId { get; init; }
}