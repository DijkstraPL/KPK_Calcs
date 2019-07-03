using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class DefaultLanguageAndVersionTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "Scripts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguage",
                table: "Scripts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguage",
                table: "Scripts");

            migrationBuilder.AlterColumn<float>(
                name: "Version",
                table: "Scripts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
