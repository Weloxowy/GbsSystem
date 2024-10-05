using FluentMigrator;

namespace GbsSystem.Server.Persistence.Migrations;
[Migration(004)] 
public class _004_CreateTable : Migration
{
    public override void Up()
    {
        Create.Table("Planets")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(128).NotNullable()
            .WithColumn("Diameter").AsDouble().NotNullable()
            .WithColumn("Description1").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("Description2").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("Description3").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("Type").AsString(256).NotNullable();

        // Add any additional columns here if needed
    }
    public override void Down()
    {
        Delete.Table("Planets");
    }
}
