using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.DeadLoads.Migrations
{
    public partial class UnitsAndCommentsNameForMaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdditionalComments",
                table: "Materials",
                newName: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "Materials",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Materials",
                newName: "AdditionalComments");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Materials",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
