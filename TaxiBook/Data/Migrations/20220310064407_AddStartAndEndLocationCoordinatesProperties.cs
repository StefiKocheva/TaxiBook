namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddStartAndEndLocationCoordinatesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinates",
                table: "Addresses",
                newName: "StartLocationCoordinates");

            migrationBuilder.AddColumn<string>(
                name: "EndLocationCoordinates",
                table: "Addresses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndLocationCoordinates",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "StartLocationCoordinates",
                table: "Addresses",
                newName: "Coordinates");
        }
    }
}
