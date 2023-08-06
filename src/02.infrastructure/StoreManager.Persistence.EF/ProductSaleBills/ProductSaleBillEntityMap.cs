using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.ProductSaleBills
{
    public class ProductSaleBillEntityMap : IEntityTypeConfiguration<ProductSaleBill>
    {
        public void Configure(EntityTypeBuilder<ProductSaleBill> entity)
        {
            entity.ToTable("ProductSaleBills");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.CustomerName).IsRequired();
            entity.Property(_ => _.ProductName).IsRequired();
            entity.Property(_ => _.UnitPrice).IsRequired();
            entity.Property(_ => _.Count).IsRequired();
            entity.Property(_ => _.BillNumber).IsRequired();
            entity.Property(_ => _.DateTime).IsRequired();
            entity.Property(_ => _.ProductId).IsRequired();
            entity.HasOne(_ => _.Product)
                  .WithMany(_ => _.ProductSaleBills)
                  .HasForeignKey(_ => _.ProductId);
            entity.HasOne(_ => _.AccountingDocument)
                  .WithOne(_ => _.ProductSaleBill)
                  .HasForeignKey<AccountingDocument>(_ => _.ProductSaleBillId);

        }
    }
}
