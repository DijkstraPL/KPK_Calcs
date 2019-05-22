using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class NameColumnForValueOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ValueOptions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ValueOptions");
        }
    }
}
