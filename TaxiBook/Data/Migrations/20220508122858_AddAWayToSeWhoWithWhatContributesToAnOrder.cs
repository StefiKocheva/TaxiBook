namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddAWayToSeWhoWithWhatContributesToAnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefusedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnacceptedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnprocessedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AcceptedById",
                table: "Orders",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProcessedById",
                table: "Orders",
                column: "ProcessedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RefusedById",
                table: "Orders",
                column: "RefusedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnacceptedById",
                table: "Orders",
                column: "UnacceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnprocessedById",
                table: "Orders",
                column: "UnprocessedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AcceptedById",
                table: "Orders",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ProcessedById",
                table: "Orders",
                column: "ProcessedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_RefusedById",
                table: "Orders",
                column: "RefusedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UnacceptedById",
                table: "Orders",
                column: "UnacceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UnprocessedById",
                table: "Orders",
                column: "UnprocessedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AcceptedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ProcessedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_RefusedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UnacceptedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UnprocessedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AcceptedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProcessedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RefusedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UnacceptedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UnprocessedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProcessedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RefusedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnacceptedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnprocessedById",
                table: "Orders");
        }
    }
}
