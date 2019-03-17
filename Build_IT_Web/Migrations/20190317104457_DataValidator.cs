using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class DataValidator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataValidator",
                table: "Parameters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValidator",
                table: "Parameters");
        }
    }
}
