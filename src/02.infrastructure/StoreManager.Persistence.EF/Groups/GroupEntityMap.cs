﻿using Microsoft.EntityFrameworkCore;
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
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.ToTable("Groups");
            entity.HasKey(_=>_.Id);
            entity
                .Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            entity
                .Property(_ => _.Name)
                .HasMaxLength(50)
                .IsRequired();
            entity
                .HasMany(_ => _.Products)
                .WithOne(_ => _.Group)
                .HasForeignKey(_ => _.GroupId);

            
        }
    }
}
