namespace MarkDemo.Domain.Entities;

public class SalesOrderDetail
{
    public int Id { get; set; } // maps to SalesOrderDetailID
    public int SalesOrderHeaderId { get; set; } // FK to SalesOrderHeader
    public short OrderQty { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal UnitPriceDiscount { get; set; }
    public decimal? LineTotal { get; set; } // computed
    public Guid RowGuid { get; set; }
    public DateTime ModifiedDate { get; set; }

    // Navigation
    public SalesOrderHeader SalesOrderHeader { get; set; } = null!;
}