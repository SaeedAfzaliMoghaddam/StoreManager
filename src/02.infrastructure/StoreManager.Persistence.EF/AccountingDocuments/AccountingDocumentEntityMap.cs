using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.AccountingDocuments
{
    public class AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> entity)
        {
            entity.ToTable("AccountingDocuments");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.BillNumber).IsRequired();
            entity.Property(_ => _.DocumentNumber).IsRequired();
            entity.Property(_ => _.DateTime).IsRequired();
            entity.Property(_ => _.BillPrice).IsRequired();
            entity.Property(_ => _.ProductSaleBillId).IsRequired();

        }
    }
}
