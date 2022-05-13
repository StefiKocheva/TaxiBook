namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class addYearPropertyToWorkTimeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "WorkTimes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "WorkTimes");
        }
    }
}
