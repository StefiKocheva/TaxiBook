namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddNewNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChosenTaxiDriverId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChosenTaxiDriverId",
                table: "Orders",
                column: "ChosenTaxiDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ChosenTaxiDriverId",
                table: "Orders",
                column: "ChosenTaxiDriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ChosenTaxiDriverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ChosenTaxiDriverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ChosenTaxiDriverId",
                table: "Orders");
        }
    }
}
