using Microsoft.EntityFrameworkCore.Migrations;

namespace TourAgency.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Austia'), ('Bulgaria'), ('Germany'), ('Belarus'), ('Poland'), ('Norway'), ('Italy');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Countries WHERE Name IN ('Austia', 'Bulgaria', 'Germany', 'Belarus', 'Poland', 'Norway', 'Italy')");
       
        }
    }
}
