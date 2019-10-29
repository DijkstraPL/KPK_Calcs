using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class TestDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripts_TestDatas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_TestDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_TestDatas_Scripts_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts_Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scripts_Assertions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    TestDataId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_Assertions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_Assertions_Scripts_TestDatas_TestDataId",
                        column: x => x.TestDataId,
                        principalTable: "Scripts_TestDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scripts_TestParameters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterId = table.Column<long>(nullable: false),
                    TestDataId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_TestParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_TestParameters_Scripts_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Scripts_Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scripts_TestParameters_Scripts_TestDatas_TestDataId",
                        column: x => x.TestDataId,
                        principalTable: "Scripts_TestDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Assertions_TestDataId",
                table: "Scripts_Assertions",
                column: "TestDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_TestDatas_ScriptId",
                table: "Scripts_TestDatas",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_TestParameters_ParameterId",
                table: "Scripts_TestParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_TestParameters_TestDataId",
                table: "Scripts_TestParameters",
                column: "TestDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scripts_Assertions");

            migrationBuilder.DropTable(
                name: "Scripts_TestParameters");

            migrationBuilder.DropTable(
                name: "Scripts_TestDatas");
        }
    }
}
