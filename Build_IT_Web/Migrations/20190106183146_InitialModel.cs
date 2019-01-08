using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Added = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AccordingTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ValueType = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    DataValidator = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Context = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    AccordingTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ScriptId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ScriptId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeScript",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScriptName = table.Column<string>(nullable: true),
                    ParameterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeScript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeScript_Parameter_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValueOption",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ValueOptionSetting = table.Column<int>(nullable: false),
                    ParameterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueOption_Parameter_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeScript_ParameterId",
                table: "AlternativeScript",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_ScriptId",
                table: "Parameter",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ScriptId",
                table: "Tag",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueOption_ParameterId",
                table: "ValueOption",
                column: "ParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeScript");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "ValueOption");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Scripts");
        }
    }
}
