namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbSetTheNewFavoriteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_AspNetUsers_ClientId",
                table: "Favorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite");

            migrationBuilder.RenameTable(
                name: "Favorite",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Favorite_ClientId",
                table: "Favorites",
                newName: "IX_Favorites_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_ClientId",
                table: "Favorites",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_ClientId",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorite");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_ClientId",
                table: "Favorite",
                newName: "IX_Favorite_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_AspNetUsers_ClientId",
                table: "Favorite",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
