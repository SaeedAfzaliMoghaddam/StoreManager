using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.Groups
{
    public class GroupEntityMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> _)
        {
            _.ToTable("Groups");
            _.HasKey(_=>_.Id);
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
