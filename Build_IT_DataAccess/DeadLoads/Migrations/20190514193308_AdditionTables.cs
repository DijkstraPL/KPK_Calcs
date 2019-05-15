using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.DeadLoads.Migrations
{
    public partial class AdditionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 124, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialAdditions",
                columns: table => new
                {
                    AdditionId = table.Column<long>(nullable: false),
                    MaterialId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAdditions", x => new { x.MaterialId, x.AdditionId });
                    table.ForeignKey(
                        name: "FK_MaterialAdditions_Additions_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialAdditions_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAdditions_AdditionId",
                table: "MaterialAdditions",
                column: "AdditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialAdditions");

            migrationBuilder.DropTable(
                name: "Additions");
        }
    }
}
