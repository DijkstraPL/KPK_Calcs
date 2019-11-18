using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class GroupNameRemovedFromParameterScriptIdAddedToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Scripts_Parameters");

            migrationBuilder.AddColumn<long>(
                name: "ScriptId",
                table: "Scripts_Groups",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScriptId",
                table: "Scripts_Groups");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Scripts_Parameters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
