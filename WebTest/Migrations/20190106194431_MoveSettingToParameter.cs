using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTest.Migrations
{
    public partial class MoveSettingToParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ValueOptionSetting",
                table: "ValueOptions");

            migrationBuilder.AlterColumn<long>(
                name: "ScriptId",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueOptionSetting",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ValueOptionSetting",
                table: "Parameters");

            migrationBuilder.AddColumn<int>(
                name: "ValueOptionSetting",
                table: "ValueOptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ScriptId",
                table: "Tags",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
