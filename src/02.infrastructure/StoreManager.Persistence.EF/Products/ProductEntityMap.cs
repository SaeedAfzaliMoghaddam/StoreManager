using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(_ => _.Id);
            entity
                .Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            entity
                .Property(_ => _.Title)
                .IsRequired();
            entity
                .Property(_ => _.GroupId)
                .IsRequired();
            entity
                .Property(_ => _.MinimumInventory)
                .IsRequired();
            entity
                .Property(_ => _.Status)
                .IsRequired();
            
        }
    }
}
