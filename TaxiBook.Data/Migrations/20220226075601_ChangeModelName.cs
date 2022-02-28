namespace TaxiBook.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EndLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentLocationDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EndLocationDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountOfPassengers = table.Column<int>(type: "int", nullable: false),
                    AdditionalRequirements = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaxiId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Taxies_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrentLocationId",
                table: "Orders",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EndLocationId",
                table: "Orders",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TaxiId",
                table: "Orders",
                column: "TaxiId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdditionalRequirements = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfPassengers = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentLocationDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CurrentLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EndLocationDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EndLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaxiId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Addresses_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Addresses_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Taxies_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CurrentLocationId",
                table: "Bookings",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EndLocationId",
                table: "Bookings",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TaxiId",
                table: "Bookings",
                column: "TaxiId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }
    }
}
