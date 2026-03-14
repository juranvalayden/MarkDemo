namespace MarkDemo.Application.Dtos;

public record SalesOrderHeaderForCreationDto
{
    public byte RevisionNumber { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime DueDate { get; init; }
    public DateTime? ShipDate { get; init; }
    public byte Status { get; init; }
    public bool OnlineOrderFlag { get; init; }
    // SalesOrderNumber excluded (calculated by AdventureWorks)
    public string? PurchaseOrderNumber { get; init; }
    public string? AccountNumber { get; init; }
    public int CustomerId { get; init; }
    public int? ShipToAddressId { get; init; }
    public int? BillToAddressId { get; init; }
    public string ShipMethod { get; init; } = string.Empty;
    public string? CreditCardApprovalCode { get; init; }
    public decimal SubTotal { get; init; }
    public decimal TaxAmt { get; init; }
    public decimal Freight { get; init; }
    // TotalDue excluded (calculated by AdventureWorks)
    public string? Comment { get; init; }
    public Guid RowGuid { get; init; }
    public DateTime ModifiedDate { get; init; }

    public ICollection<SalesOrderDetailForCreationDto> SalesOrderDetails { get; init; } = new List<SalesOrderDetailForCreationDto>();
}