namespace TaxiBook.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddEmployeeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Employeetype",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employeetype",
                table: "AspNetUsers");
        }
    }
}
