using FluentMigrator;

namespace GbsSystem.Server.Persistence.Migrations;
[Migration(001)]
public class _001_CreateTable_AspNetUsers : Migration
{
    public override void Up()
    {
        Create.Table("AspNetUsers")
            .WithColumn("Id").AsString().NotNullable().PrimaryKey()
            .WithColumn("UserName").AsString().Nullable()
            .WithColumn("NormalizedUserName").AsString().Nullable()
            .WithColumn("Email").AsString().Nullable()
            .WithColumn("NormalizedEmail").AsString().Nullable()
            .WithColumn("EmailConfirmed").AsBoolean().Nullable()
            .WithColumn("PasswordHash").AsString().Nullable()
            .WithColumn("SecurityStamp").AsString().Nullable()
            .WithColumn("ConcurrencyStamp").AsString().Nullable()
            .WithColumn("PhoneNumber").AsString().Nullable().Nullable()
            .WithColumn("PhoneNumberConfirmed").AsBoolean().Nullable()
            .WithColumn("TwoFactorEnabled").AsBoolean().Nullable()
            .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
            .WithColumn("LockoutEnabled").AsBoolean().Nullable()
            .WithColumn("AccessFailedCount").AsInt32().Nullable()
            .WithColumn(nameof(Models.AspNetUsers.AspNetUsers.FirstName)).AsString().NotNullable()
            .WithColumn(nameof(Models.AspNetUsers.AspNetUsers.Lastname)).AsString().NotNullable()
            .WithColumn(nameof(Models.AspNetUsers.AspNetUsers.Birthday)).AsDate().NotNullable();
    }
    public override void Down()
    {
        if (Schema.Table("AspNetUsers").Exists())
        {
            Delete.Table("AspNetUsers");
        }
    }
}