namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ReferenceTheAbsenceWithCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CompanyId",
                table: "Absences",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Companies_CompanyId",
                table: "Absences",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Companies_CompanyId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_CompanyId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Absences");
        }
    }
}
