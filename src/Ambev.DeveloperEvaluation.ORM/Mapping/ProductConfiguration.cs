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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().UseIdentityColumn();            
            builder.Property(b => b.Description).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Price).IsRequired().HasPrecision(18, 2);

            builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);            
        }
    }
}
