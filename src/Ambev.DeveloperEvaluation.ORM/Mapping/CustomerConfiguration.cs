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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().UseIdentityColumn();            
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Email).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Phone).HasMaxLength(20);

            builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

            builder.HasMany(b => b.Sales)
               .WithOne(s => s.Customer)
               .HasForeignKey(s => s.CustomerId);
        }
    }
}
