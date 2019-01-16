using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class ManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ScriptId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ScriptId",
                table: "Tags");

            migrationBuilder.AddColumn<float>(
                name: "Version",
                table: "Scripts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "AlternativeScripts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScriptTags",
                columns: table => new
                {
                    ScriptId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptTags", x => new { x.ScriptId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ScriptTags_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScriptTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptTags_TagId",
                table: "ScriptTags",
                column: "TagId");

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

            migrationBuilder.DropTable(
                name: "ScriptTags");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Scripts");

            migrationBuilder.AddColumn<long>(
                name: "ScriptId",
                table: "Tags",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "AlternativeScripts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ScriptId",
                table: "Tags",
                column: "ScriptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
