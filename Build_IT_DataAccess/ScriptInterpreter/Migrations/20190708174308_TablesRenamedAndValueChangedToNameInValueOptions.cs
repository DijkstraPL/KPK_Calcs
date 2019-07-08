using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    public partial class TablesRenamedAndValueChangedToNameInValueOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFigures_Figures_FigureId",
                table: "ParameterFigures");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFigures_Parameters_ParameterId",
                table: "ParameterFigures");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Scripts_ScriptId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersTranslations_Parameters_ParameterId",
                table: "ParametersTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptsTranslations_Scripts_ScriptId",
                table: "ScriptsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptTags_Scripts_ScriptId",
                table: "ScriptTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptTags_Tags_TagId",
                table: "ScriptTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ValueOptions_Parameters_ParameterId",
                table: "ValueOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ValueOptionsTranslations_ValueOptions_ValueOptionId",
                table: "ValueOptionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueOptionsTranslations",
                table: "ValueOptionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueOptions",
                table: "ValueOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptTags",
                table: "ScriptTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptsTranslations",
                table: "ScriptsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts",
                table: "Scripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParametersTranslations",
                table: "ParametersTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParameterFigures",
                table: "ParameterFigures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Figures",
                table: "Figures");

            migrationBuilder.RenameTable(
                name: "ValueOptionsTranslations",
                newName: "Scripts_ValueOptionsTranslations");

            migrationBuilder.RenameTable(
                name: "ValueOptions",
                newName: "Scripts_ValueOptions");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Scripts_Tags");

            migrationBuilder.RenameTable(
                name: "ScriptTags",
                newName: "Scripts_ScriptTags");

            migrationBuilder.RenameTable(
                name: "ScriptsTranslations",
                newName: "Scripts_ScriptsTranslations");

            migrationBuilder.RenameTable(
                name: "Scripts",
                newName: "Scripts_Scripts");

            migrationBuilder.RenameTable(
                name: "ParametersTranslations",
                newName: "Scripts_ParametersTranslations");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Scripts_Parameters");

            migrationBuilder.RenameTable(
                name: "ParameterFigures",
                newName: "Scripts_ParameterFigures");

            migrationBuilder.RenameTable(
                name: "Figures",
                newName: "Scripts_Figures");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Scripts_ValueOptionsTranslations",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_ValueOptionsTranslations_ValueOptionId",
                table: "Scripts_ValueOptionsTranslations",
                newName: "IX_Scripts_ValueOptionsTranslations_ValueOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ValueOptions_ParameterId",
                table: "Scripts_ValueOptions",
                newName: "IX_Scripts_ValueOptions_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptTags_TagId",
                table: "Scripts_ScriptTags",
                newName: "IX_Scripts_ScriptTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptsTranslations_ScriptId",
                table: "Scripts_ScriptsTranslations",
                newName: "IX_Scripts_ScriptsTranslations_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_ParametersTranslations_ParameterId",
                table: "Scripts_ParametersTranslations",
                newName: "IX_Scripts_ParametersTranslations_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_ScriptId",
                table: "Scripts_Parameters",
                newName: "IX_Scripts_Parameters_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_ParameterFigures_FigureId",
                table: "Scripts_ParameterFigures",
                newName: "IX_Scripts_ParameterFigures_FigureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ValueOptionsTranslations",
                table: "Scripts_ValueOptionsTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ValueOptions",
                table: "Scripts_ValueOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_Tags",
                table: "Scripts_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ScriptTags",
                table: "Scripts_ScriptTags",
                columns: new[] { "ScriptId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ScriptsTranslations",
                table: "Scripts_ScriptsTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_Scripts",
                table: "Scripts_Scripts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ParametersTranslations",
                table: "Scripts_ParametersTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_Parameters",
                table: "Scripts_Parameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_ParameterFigures",
                table: "Scripts_ParameterFigures",
                columns: new[] { "ParameterId", "FigureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts_Figures",
                table: "Scripts_Figures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ParameterFigures_Scripts_Figures_FigureId",
                table: "Scripts_ParameterFigures",
                column: "FigureId",
                principalTable: "Scripts_Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ParameterFigures_Scripts_Parameters_ParameterId",
                table: "Scripts_ParameterFigures",
                column: "ParameterId",
                principalTable: "Scripts_Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Scripts_ScriptId",
                table: "Scripts_Parameters",
                column: "ScriptId",
                principalTable: "Scripts_Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ParametersTranslations_Scripts_Parameters_ParameterId",
                table: "Scripts_ParametersTranslations",
                column: "ParameterId",
                principalTable: "Scripts_Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ScriptsTranslations_Scripts_Scripts_ScriptId",
                table: "Scripts_ScriptsTranslations",
                column: "ScriptId",
                principalTable: "Scripts_Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ScriptTags_Scripts_Scripts_ScriptId",
                table: "Scripts_ScriptTags",
                column: "ScriptId",
                principalTable: "Scripts_Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ScriptTags_Scripts_Tags_TagId",
                table: "Scripts_ScriptTags",
                column: "TagId",
                principalTable: "Scripts_Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ValueOptions_Scripts_Parameters_ParameterId",
                table: "Scripts_ValueOptions",
                column: "ParameterId",
                principalTable: "Scripts_Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_ValueOptionsTranslations_Scripts_ValueOptions_ValueOptionId",
                table: "Scripts_ValueOptionsTranslations",
                column: "ValueOptionId",
                principalTable: "Scripts_ValueOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ParameterFigures_Scripts_Figures_FigureId",
                table: "Scripts_ParameterFigures");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ParameterFigures_Scripts_Parameters_ParameterId",
                table: "Scripts_ParameterFigures");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Parameters_Scripts_Scripts_ScriptId",
                table: "Scripts_Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ParametersTranslations_Scripts_Parameters_ParameterId",
                table: "Scripts_ParametersTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ScriptsTranslations_Scripts_Scripts_ScriptId",
                table: "Scripts_ScriptsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ScriptTags_Scripts_Scripts_ScriptId",
                table: "Scripts_ScriptTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ScriptTags_Scripts_Tags_TagId",
                table: "Scripts_ScriptTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ValueOptions_Scripts_Parameters_ParameterId",
                table: "Scripts_ValueOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_ValueOptionsTranslations_Scripts_ValueOptions_ValueOptionId",
                table: "Scripts_ValueOptionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ValueOptionsTranslations",
                table: "Scripts_ValueOptionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ValueOptions",
                table: "Scripts_ValueOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_Tags",
                table: "Scripts_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ScriptTags",
                table: "Scripts_ScriptTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ScriptsTranslations",
                table: "Scripts_ScriptsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_Scripts",
                table: "Scripts_Scripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ParametersTranslations",
                table: "Scripts_ParametersTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_Parameters",
                table: "Scripts_Parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_ParameterFigures",
                table: "Scripts_ParameterFigures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts_Figures",
                table: "Scripts_Figures");

            migrationBuilder.RenameTable(
                name: "Scripts_ValueOptionsTranslations",
                newName: "ValueOptionsTranslations");

            migrationBuilder.RenameTable(
                name: "Scripts_ValueOptions",
                newName: "ValueOptions");

            migrationBuilder.RenameTable(
                name: "Scripts_Tags",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Scripts_ScriptTags",
                newName: "ScriptTags");

            migrationBuilder.RenameTable(
                name: "Scripts_ScriptsTranslations",
                newName: "ScriptsTranslations");

            migrationBuilder.RenameTable(
                name: "Scripts_Scripts",
                newName: "Scripts");

            migrationBuilder.RenameTable(
                name: "Scripts_ParametersTranslations",
                newName: "ParametersTranslations");

            migrationBuilder.RenameTable(
                name: "Scripts_Parameters",
                newName: "Parameters");

            migrationBuilder.RenameTable(
                name: "Scripts_ParameterFigures",
                newName: "ParameterFigures");

            migrationBuilder.RenameTable(
                name: "Scripts_Figures",
                newName: "Figures");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ValueOptionsTranslations",
                newName: "Value");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ValueOptionsTranslations_ValueOptionId",
                table: "ValueOptionsTranslations",
                newName: "IX_ValueOptionsTranslations_ValueOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ValueOptions_ParameterId",
                table: "ValueOptions",
                newName: "IX_ValueOptions_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ScriptTags_TagId",
                table: "ScriptTags",
                newName: "IX_ScriptTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ScriptsTranslations_ScriptId",
                table: "ScriptsTranslations",
                newName: "IX_ScriptsTranslations_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ParametersTranslations_ParameterId",
                table: "ParametersTranslations",
                newName: "IX_ParametersTranslations_ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_Parameters_ScriptId",
                table: "Parameters",
                newName: "IX_Parameters_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_ParameterFigures_FigureId",
                table: "ParameterFigures",
                newName: "IX_ParameterFigures_FigureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueOptionsTranslations",
                table: "ValueOptionsTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueOptions",
                table: "ValueOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptTags",
                table: "ScriptTags",
                columns: new[] { "ScriptId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptsTranslations",
                table: "ScriptsTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts",
                table: "Scripts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParametersTranslations",
                table: "ParametersTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParameterFigures",
                table: "ParameterFigures",
                columns: new[] { "ParameterId", "FigureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Figures",
                table: "Figures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFigures_Figures_FigureId",
                table: "ParameterFigures",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFigures_Parameters_ParameterId",
                table: "ParameterFigures",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Scripts_ScriptId",
                table: "Parameters",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersTranslations_Parameters_ParameterId",
                table: "ParametersTranslations",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptsTranslations_Scripts_ScriptId",
                table: "ScriptsTranslations",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptTags_Scripts_ScriptId",
                table: "ScriptTags",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptTags_Tags_TagId",
                table: "ScriptTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueOptions_Parameters_ParameterId",
                table: "ValueOptions",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueOptionsTranslations_ValueOptions_ValueOptionId",
                table: "ValueOptionsTranslations",
                column: "ValueOptionId",
                principalTable: "ValueOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
