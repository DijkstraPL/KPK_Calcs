using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class ParameterTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametersTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParameterId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametersTranslations_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueOptionsTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueOptionId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueOptionsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueOptionsTranslations_ValueOptions_ValueOptionId",
                        column: x => x.ValueOptionId,
                        principalTable: "ValueOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParametersTranslations_ParameterId",
                table: "ParametersTranslations",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueOptionsTranslations_ValueOptionId",
                table: "ValueOptionsTranslations",
                column: "ValueOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametersTranslations");

            migrationBuilder.DropTable(
                name: "ValueOptionsTranslations");
        }
    }
}
