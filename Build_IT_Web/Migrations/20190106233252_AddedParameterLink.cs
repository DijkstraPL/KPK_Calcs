using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class AddedParameterLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts");

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "AlternativeScripts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts");

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "AlternativeScripts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
