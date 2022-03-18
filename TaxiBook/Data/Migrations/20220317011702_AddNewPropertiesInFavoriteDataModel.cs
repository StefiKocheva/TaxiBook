using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiBook.Data.Migrations
{
    public partial class AddNewPropertiesInFavoriteDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Favorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "OneКilometerМileageDailyPrice",
                table: "Favorites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OneКilometerМileageNightPrice",
                table: "Favorites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "OneКilometerМileageDailyPrice",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "OneКilometerМileageNightPrice",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Favorites");
        }
    }
}
