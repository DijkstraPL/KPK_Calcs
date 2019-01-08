using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_Web.Migrations
{
    public partial class ApplyingConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeScript_Parameter_ParameterId",
                table: "AlternativeScript");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_Scripts_ScriptId",
                table: "Parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Scripts_ScriptId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_ValueOption_Parameter_ParameterId",
                table: "ValueOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueOption",
                table: "ValueOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlternativeScript",
                table: "AlternativeScript");

            migrationBuilder.RenameTable(
                name: "ValueOption",
                newName: "ValueOptions");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Parameter",
                newName: "Parameters");

            migrationBuilder.RenameTable(
                name: "AlternativeScript",
                newName: "AlternativeScripts");

            migrationBuilder.RenameIndex(
                name: "IX_ValueOption_ParameterId",
                table: "ValueOptions",
                newName: "IX_ValueOptions_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ScriptId",
                table: "Tags",
                newName: "IX_Tags_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_ScriptId",
                table: "Parameters",
                newName: "IX_Parameters_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_AlternativeScript_ParameterId",
                table: "AlternativeScripts",
                newName: "IX_AlternativeScripts_ParameterId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Scripts",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Scripts",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Scripts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Scripts",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccordingTo",
                table: "Scripts",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ValueOptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parameters",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScriptName",
                table: "AlternativeScripts",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueOptions",
                table: "ValueOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlternativeScripts",
                table: "AlternativeScripts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeScripts_Parameters_ParameterId",
                table: "AlternativeScripts",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Scripts_ScriptId",
                table: "Parameters",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueOptions_Parameters_ParameterId",
                table: "ValueOptions",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Scripts_ScriptId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Scripts_ScriptId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_ValueOptions_Parameters_ParameterId",
                table: "ValueOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueOptions",
                table: "ValueOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlternativeScripts",
                table: "AlternativeScripts");

            migrationBuilder.RenameTable(
                name: "ValueOptions",
                newName: "ValueOption");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Parameter");

            migrationBuilder.RenameTable(
                name: "AlternativeScripts",
                newName: "AlternativeScript");

            migrationBuilder.RenameIndex(
                name: "IX_ValueOptions_ParameterId",
                table: "ValueOption",
                newName: "IX_ValueOption_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ScriptId",
                table: "Tag",
                newName: "IX_Tag_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_ScriptId",
                table: "Parameter",
                newName: "IX_Parameter_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_AlternativeScripts_ParameterId",
                table: "AlternativeScript",
                newName: "IX_AlternativeScript_ParameterId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccordingTo",
                table: "Scripts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ValueOption",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parameter",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ScriptName",
                table: "AlternativeScript",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueOption",
                table: "ValueOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlternativeScript",
                table: "AlternativeScript",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeScript_Parameter_ParameterId",
                table: "AlternativeScript",
                column: "ParameterId",
                principalTable: "Parameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_Scripts_ScriptId",
                table: "Parameter",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Scripts_ScriptId",
                table: "Tag",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueOption_Parameter_ParameterId",
                table: "ValueOption",
                column: "ParameterId",
                principalTable: "Parameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
