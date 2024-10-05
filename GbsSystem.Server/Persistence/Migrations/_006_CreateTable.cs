using FluentMigrator;

namespace GbsSystem.Server.Persistence.Migrations;
[Migration(006)]
public class _006_CreateTable : Migration
{
    public override void Up()
    {
        // Create the 'Questions' table
        Create.Table("Questions")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Question").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("AnswerBad1").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("AnswerBad2").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("AnswerBad3").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("GoodAnswer").AsString(Int32.MaxValue).NotNullable()
            .WithColumn("Points").AsInt32().NotNullable()
            .WithColumn("Level").AsInt32().NotNullable()
            .WithColumn("PlanetId").AsGuid().NotNullable(); // Foreign Key reference to Planets table

        // Create foreign key relationship with 'Planets' table
        Create.ForeignKey("FK_Questions_Planets")
            .FromTable("Questions").ForeignColumn("PlanetId")
            .ToTable("Planets").PrimaryColumn("Id");
    }

    public override void Down()
    {
        // Drop the foreign key first
        Delete.ForeignKey("FK_Questions_Planets").OnTable("Questions");

        // Then drop the 'Questions' table
        Delete.Table("Questions");
    }
}