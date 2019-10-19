using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class ScriptInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Groups_ScriptId",
                table: "Scripts_Groups",
                column: "ScriptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Groups_Scripts_Scripts_ScriptId",
                table: "Scripts_Groups",
                column: "ScriptId",
                principalTable: "Scripts_Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Groups_Scripts_Scripts_ScriptId",
                table: "Scripts_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Scripts_Groups_ScriptId",
                table: "Scripts_Groups");
        }
    }
}
