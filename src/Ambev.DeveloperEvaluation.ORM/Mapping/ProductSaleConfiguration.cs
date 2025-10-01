using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.ToTable("ProductSales");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().UseIdentityColumn();            
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property(b => b.UnitPrice).IsRequired().HasPrecision(18, 2);
            builder.Property(b => b.Discount).HasPrecision(18, 2);

            builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

            builder.HasOne(ps => ps.Product)
              .WithMany(p => p.ProductsSales)
              .HasForeignKey(ps => ps.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
