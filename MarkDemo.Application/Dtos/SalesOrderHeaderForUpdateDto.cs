namespace MarkDemo.Application.Dtos;

public record SalesOrderHeaderForUpdateDto
{
    public string AccountNumber { get; init; } = string.Empty;
    public string? CreditCardApprovalCode { get; init; }
    public string Comment { get; init; } = string.Empty;
    public DateTime ModifiedDate { get; init; }
}