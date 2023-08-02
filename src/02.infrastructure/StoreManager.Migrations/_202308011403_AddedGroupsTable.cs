using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Migrations
{
    [Migration(202308011403)]
    public class _202308011403_AddedGroupsTable : Migration
    {
        public override void Down()
        {
            Delete
                .Table("Groups");
        }

        public override void Up()
        {
            Create
                .Table("Groups")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().Nullable();
        }
    }
}
