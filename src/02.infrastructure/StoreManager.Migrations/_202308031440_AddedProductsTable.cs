﻿using FluentMigrator;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Migrations
{
    [Migration(202308031440)]
    public class _202308031440_AddedProductsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create
                .Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("MinimumInventory").AsInt32().NotNullable()
                .WithColumn("Inventory").AsInt32().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .ForeignKey("FK_Products_Groups", "Groups", "Id");
                
        }

    }
}
