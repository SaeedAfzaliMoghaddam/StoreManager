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
            entity.HasKey(_=>_.Id);
            entity
                .Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            entity
                .Property(_ => _.Title)
                .HasMaxLength(50)
                .IsRequired();
            entity
                .Property(_=>_.GroupId)
                .HasMaxLength(50)
                .IsRequired();

                
        }
    }
}
