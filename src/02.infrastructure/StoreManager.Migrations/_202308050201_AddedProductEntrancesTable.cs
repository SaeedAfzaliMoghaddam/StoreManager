using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Migrations
{
    [Migration(202308050201)]
    public class _202308050201_AddedProductEntrancesTable : Migration
    {
        public override void Down()
        {
            Delete.Table("ProductEntrances");
        }

        public override void Up()
        {
            Create.Table("ProductEntrances")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DateTime").AsString().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("FactorNumber").AsString().NotNullable()
                .WithColumn("ProductCompanyName").AsString().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_ProductEntrances_Products", "Products", "Id");
        }
    }
}
