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
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().UseIdentityColumn();            
            builder.Property(b => b.BranchId).IsRequired();
            builder.Property(b => b.CustomerId).IsRequired();
            builder.Property(b => b.SaleDate).IsRequired();
            builder.Property(b => b.TotalAmount).IsRequired().HasPrecision(18, 2);
            builder.Property(b => b.TotalQuantities).IsRequired().HasPrecision(18, 2);
            builder.Property(b => b.TotalDiscounts).HasPrecision(18, 2);

            builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

            builder.HasMany(b => b.ProductsSales)
               .WithOne(s => s.Sale)
               .HasForeignKey(s => s.SaleId)
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
