using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class Versions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Scripts_Scripts");

            migrationBuilder.AddColumn<long>(
                name: "VersionId",
                table: "Scripts_Parameters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Scripts_Versions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    AccordingTo = table.Column<string>(maxLength: 255, nullable: true),
                    ScriptId = table.Column<long>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_Versions_Scripts_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts_Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scripts_VersionsTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<long>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts_VersionsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_VersionsTranslations_Scripts_Versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "Scripts_Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Parameters_VersionId",
                table: "Scripts_Parameters",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Versions_ScriptId",
                table: "Scripts_Versions",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_VersionsTranslations_VersionId",
                table: "Scripts_VersionsTranslations",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Versions_VersionId",
                table: "Scripts_Parameters",
                column: "VersionId",
                principalTable: "Scripts_Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Versions_VersionId",
                table: "Scripts_Parameters");

            migrationBuilder.DropTable(
                name: "Scripts_VersionsTranslations");

            migrationBuilder.DropTable(
                name: "Scripts_Versions");

            migrationBuilder.DropIndex(
                name: "IX_Scripts_Parameters_VersionId",
                table: "Scripts_Parameters");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Scripts_Parameters");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Scripts_Scripts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
