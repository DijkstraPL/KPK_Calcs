using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class ValidateVisibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataValidator",
                table: "Parameters",
                newName: "VisibilityValidator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisibilityValidator",
                table: "Parameters",
                newName: "DataValidator");
        }
    }
}
