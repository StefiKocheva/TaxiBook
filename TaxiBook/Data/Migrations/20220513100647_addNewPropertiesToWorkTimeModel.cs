namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class addNewPropertiesToWorkTimeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "WorkTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "WorkTimes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "WorkTimes");
        }
    }
}
