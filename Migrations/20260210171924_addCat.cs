using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtDecoMebel.Migrations
{
    /// <inheritdoc />
    public partial class addCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Types_TypeId",
                table: "Furnitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "FTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FTypes",
                table: "FTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_FTypes_TypeId",
                table: "Furnitures",
                column: "TypeId",
                principalTable: "FTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_FTypes_TypeId",
                table: "Furnitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FTypes",
                table: "FTypes");

            migrationBuilder.RenameTable(
                name: "FTypes",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Types_TypeId",
                table: "Furnitures",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
