using FluentMigrator;
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
                .WithColumn("GroupId").AsInt32().ForeignKey("FK_Products_Groups", "Groups", "Id");
        }
    }
}
