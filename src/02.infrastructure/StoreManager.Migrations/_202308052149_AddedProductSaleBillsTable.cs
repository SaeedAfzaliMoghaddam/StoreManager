using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Migrations
{
    [Migration(202308052149)]
    public class _202308052149_AddedProductSaleBillsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("ProductSaleBills");
        }

        public override void Up()
        {
            Create.Table("ProductSaleBills")
                .WithColumn("Id")
                .AsInt32().PrimaryKey().Identity()
                .WithColumn("CustomerName").AsString().NotNullable()
                .WithColumn("ProductName").AsString().NotNullable()
                .WithColumn("UnitPrice").AsInt32().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("BillNumber").AsGuid().NotNullable()
                .WithColumn("DateTime").AsString().NotNullable()
                .WithColumn("ProductEntranceId").AsInt32().NotNullable()
                .ForeignKey("FK_ProductSaleBills_ProductEntrances", "ProductEntrances", "Id");

        }
    }
}
