using Microsoft.EntityFrameworkCore.Migrations;

namespace Build_IT_DataAccess.DeadLoads.Migrations
{
    public partial class TablesRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAdditions_Additions_AdditionId",
                table: "MaterialAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAdditions_Materials_MaterialId",
                table: "MaterialAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Subcategories_SubcategoryId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialAdditions",
                table: "MaterialAdditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Additions",
                table: "Additions");

            migrationBuilder.RenameTable(
                name: "Subcategories",
                newName: "DeadLoads_Subcategories");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "DeadLoads_Materials");

            migrationBuilder.RenameTable(
                name: "MaterialAdditions",
                newName: "DeadLoads_MaterialAdditions");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "DeadLoads_Categories");

            migrationBuilder.RenameTable(
                name: "Additions",
                newName: "DeadLoads_Additions");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoryId",
                table: "DeadLoads_Subcategories",
                newName: "IX_DeadLoads_Subcategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_SubcategoryId",
                table: "DeadLoads_Materials",
                newName: "IX_DeadLoads_Materials_SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialAdditions_AdditionId",
                table: "DeadLoads_MaterialAdditions",
                newName: "IX_DeadLoads_MaterialAdditions_AdditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadLoads_Subcategories",
                table: "DeadLoads_Subcategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadLoads_Materials",
                table: "DeadLoads_Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadLoads_MaterialAdditions",
                table: "DeadLoads_MaterialAdditions",
                columns: new[] { "MaterialId", "AdditionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadLoads_Categories",
                table: "DeadLoads_Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadLoads_Additions",
                table: "DeadLoads_Additions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeadLoads_MaterialAdditions_DeadLoads_Additions_AdditionId",
                table: "DeadLoads_MaterialAdditions",
                column: "AdditionId",
                principalTable: "DeadLoads_Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeadLoads_MaterialAdditions_DeadLoads_Materials_MaterialId",
                table: "DeadLoads_MaterialAdditions",
                column: "MaterialId",
                principalTable: "DeadLoads_Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeadLoads_Materials_DeadLoads_Subcategories_SubcategoryId",
                table: "DeadLoads_Materials",
                column: "SubcategoryId",
                principalTable: "DeadLoads_Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeadLoads_Subcategories_DeadLoads_Categories_CategoryId",
                table: "DeadLoads_Subcategories",
                column: "CategoryId",
                principalTable: "DeadLoads_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeadLoads_MaterialAdditions_DeadLoads_Additions_AdditionId",
                table: "DeadLoads_MaterialAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DeadLoads_MaterialAdditions_DeadLoads_Materials_MaterialId",
                table: "DeadLoads_MaterialAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DeadLoads_Materials_DeadLoads_Subcategories_SubcategoryId",
                table: "DeadLoads_Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_DeadLoads_Subcategories_DeadLoads_Categories_CategoryId",
                table: "DeadLoads_Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadLoads_Subcategories",
                table: "DeadLoads_Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadLoads_Materials",
                table: "DeadLoads_Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadLoads_MaterialAdditions",
                table: "DeadLoads_MaterialAdditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadLoads_Categories",
                table: "DeadLoads_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadLoads_Additions",
                table: "DeadLoads_Additions");

            migrationBuilder.RenameTable(
                name: "DeadLoads_Subcategories",
                newName: "Subcategories");

            migrationBuilder.RenameTable(
                name: "DeadLoads_Materials",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "DeadLoads_MaterialAdditions",
                newName: "MaterialAdditions");

            migrationBuilder.RenameTable(
                name: "DeadLoads_Categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "DeadLoads_Additions",
                newName: "Additions");

            migrationBuilder.RenameIndex(
                name: "IX_DeadLoads_Subcategories_CategoryId",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DeadLoads_Materials_SubcategoryId",
                table: "Materials",
                newName: "IX_Materials_SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DeadLoads_MaterialAdditions_AdditionId",
                table: "MaterialAdditions",
                newName: "IX_MaterialAdditions_AdditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialAdditions",
                table: "MaterialAdditions",
                columns: new[] { "MaterialId", "AdditionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Additions",
                table: "Additions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAdditions_Additions_AdditionId",
                table: "MaterialAdditions",
                column: "AdditionId",
                principalTable: "Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAdditions_Materials_MaterialId",
                table: "MaterialAdditions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Subcategories_SubcategoryId",
                table: "Materials",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
