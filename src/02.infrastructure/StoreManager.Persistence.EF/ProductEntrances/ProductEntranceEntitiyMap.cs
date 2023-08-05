using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.ProductEntrances
{
    internal class ProductEntranceEntitiyMap : IEntityTypeConfiguration<ProductEntrance>
    {
        public void Configure(EntityTypeBuilder<ProductEntrance> entity)
        {
            entity.ToTable("ProductEntrances");
            entity.HasKey(_ => _.Id);
            entity.Property(_=>_.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.ProductId).IsRequired();
            entity.Property(_=>_.DateTime).IsRequired();
            entity.Property(_=>_.Count).IsRequired();
            entity.Property(_=>_.ProductCompanyName).IsRequired();
            entity.Property(_=>_.FactorNumber).IsRequired();
            entity
                .HasOne(_ => _.Product)
                .WithMany(_ => _.ProductEntrances)
                .HasForeignKey(_=>_.ProductId);
        }
    }
}
