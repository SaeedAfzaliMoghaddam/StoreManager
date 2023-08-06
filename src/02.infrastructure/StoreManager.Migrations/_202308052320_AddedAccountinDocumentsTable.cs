using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Migrations
{
    [Migration(202308052320)]
    public class _202308052320_AddedAccountinDocumentsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("AccountingDocuments");
        }

        public override void Up()
        {
            Create.Table("AccountingDocuments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BillNumber").AsGuid().NotNullable()
                .WithColumn("DocumentNumber").AsInt32().NotNullable()
                .WithColumn("DateTime").AsString().NotNullable()
                .WithColumn("BillPrice").AsInt32().NotNullable()
                .WithColumn("ProductSaleBillId").AsInt32().NotNullable()
                .ForeignKey("FK_AccountingDocuments_ProductSaleBills", "ProductSaleBills", "Id");
        }
    }
}
