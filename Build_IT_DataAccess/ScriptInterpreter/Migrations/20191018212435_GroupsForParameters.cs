using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class GroupsForParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "Scripts_Parameters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Scripts_Groups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    VisibilityValidator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scripts_GroupTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_GroupTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_GroupTranslations_Scripts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Scripts_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Parameters_GroupId",
                table: "Scripts_Parameters",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_GroupTranslations_GroupId",
                table: "Scripts_GroupTranslations",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Groups_GroupId",
                table: "Scripts_Parameters",
                column: "GroupId",
                principalTable: "Scripts_Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Groups_GroupId",
                table: "Scripts_Parameters");

            migrationBuilder.DropTable(
                name: "Scripts_GroupTranslations");

            migrationBuilder.DropTable(
                name: "Scripts_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Scripts_Parameters_GroupId",
                table: "Scripts_Parameters");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Scripts_Parameters");
        }
    }
}
