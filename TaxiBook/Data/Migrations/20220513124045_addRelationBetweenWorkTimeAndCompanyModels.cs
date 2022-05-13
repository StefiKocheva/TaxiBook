namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class addRelationBetweenWorkTimeAndCompanyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Companyid",
                table: "WorkTimes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_Companyid",
                table: "WorkTimes",
                column: "Companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Companies_Companyid",
                table: "WorkTimes",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Companies_Companyid",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_Companyid",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "Companyid",
                table: "WorkTimes");
        }
    }
}
