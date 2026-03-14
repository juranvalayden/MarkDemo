using MarkDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarkDemo.Infrastructure.Configurations;

public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
{
    public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
    {
        builder.ToTable("SalesOrderDetail", "SalesLT");

        builder.HasKey(d => d.Id)
            .HasName("PK_SalesOrderDetail");

        builder.Property(d => d.Id)
            .IsRequired()
            .HasColumnName("SalesOrderDetailID")
            .HasColumnType("int");

        builder.Property(d => d.SalesOrderHeaderId)
            .IsRequired()
            .HasColumnName("SalesOrderID")
            .HasColumnType("int");

        builder.Property(d => d.OrderQty)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(d => d.ProductId)
            .IsRequired()
            .HasColumnName("ProductID")
            .HasColumnType("int");

        builder.Property(d => d.UnitPrice)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(d => d.UnitPriceDiscount)
            .IsRequired()
            .HasColumnType("money");

        // Computed column: LineTotal
        builder.Property(d => d.LineTotal)
            .HasColumnType("numeric(38,6)")
            .ValueGeneratedOnAddOrUpdate()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(d => d.RowGuid)
            .IsRequired()
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier");

        builder.Property(d => d.ModifiedDate)
            .IsRequired()
            .HasColumnType("datetime")
            .HasPrecision(7);

        // Relationship back to SalesOrderHeader
        builder.HasOne(d => d.SalesOrderHeader)
            .WithMany(h => h.SalesOrderDetails)
            .HasForeignKey(d => d.SalesOrderHeaderId);
    }
}