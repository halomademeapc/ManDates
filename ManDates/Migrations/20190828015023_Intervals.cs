using Microsoft.EntityFrameworkCore.Migrations;

namespace ManDates.Migrations
{
    public partial class Intervals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationInWeeks",
                table: "Groups",
                nullable: false,
                defaultValue: 1)
                .Annotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInWeeks",
                table: "Groups");
        }
    }
}
