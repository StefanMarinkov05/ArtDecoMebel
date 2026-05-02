using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtDecoMebel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorFurniture_Colors_ColorsId",
                table: "ColorFurniture");

            migrationBuilder.DropForeignKey(
                name: "FK_FurnitureMaterial_Materials_MaterialsId",
                table: "FurnitureMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Brands_BrandId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Rooms_RoomId",
                table: "Furnitures");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Виктория'", 3 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Овал'", 1 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Класик'", 2 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Елеганс'", 4 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Модерн'", 5 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Работно'", 6 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Компакт'", 7 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Релакс'", 8 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Минимал'", 9 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Кръг'", 10 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Пуф'", 11 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "'Сити'", 12 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Стандарт", 13 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Висок", 14 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Лукс", 15 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Малко", 16 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Слим", 17 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Ниска", 18 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Класика", 19 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Стенна", 20 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Дървена", 21 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Плажен", 22 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Бебешко", 23 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Широк", 24 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Ергономичен", 25 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Метален", 26 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Голям", 27 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Висящ", 9 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "Градинска", 21 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "TypeId" },
                values: new object[] { "С огледало", 24 });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Маса" },
                    { 2, "Стол" },
                    { 3, "Диван" },
                    { 4, "Легло" },
                    { 5, "Секция" },
                    { 6, "Бюро" },
                    { 7, "Шкаф" },
                    { 8, "Кресло" },
                    { 9, "Полица" },
                    { 10, "Огледало" },
                    { 11, "Табуретка" },
                    { 12, "Гардероб" },
                    { 13, "Кухненски шкаф" },
                    { 14, "Бар стол" },
                    { 15, "Трапезен комплект" },
                    { 16, "Нощно шкафче" },
                    { 17, "TV Шкаф" },
                    { 18, "Холна маса" },
                    { 19, "Библиотека" },
                    { 20, "Закачалка" },
                    { 21, "Градинска маса" },
                    { 22, "Шезлонг" },
                    { 23, "Детско легло" },
                    { 24, "Скрин" },
                    { 25, "Компютърен стол" },
                    { 26, "Офис шкаф" },
                    { 27, "Ъглов диван" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_TypeId",
                table: "Furnitures",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorFurniture_Colors_ColorsId",
                table: "ColorFurniture",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FurnitureMaterial_Materials_MaterialsId",
                table: "FurnitureMaterial",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Brands_BrandId",
                table: "Furnitures",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Rooms_RoomId",
                table: "Furnitures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Types_TypeId",
                table: "Furnitures",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorFurniture_Colors_ColorsId",
                table: "ColorFurniture");

            migrationBuilder.DropForeignKey(
                name: "FK_FurnitureMaterial_Materials_MaterialsId",
                table: "FurnitureMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Brands_BrandId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Rooms_RoomId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Types_TypeId",
                table: "Furnitures");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_TypeId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Furnitures");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Диван 'Виктория'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Маса 'Овал'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Стол 'Класик'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Легло 'Елеганс'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Секция 'Модерн'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Бюро 'Работно'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Шкаф 'Компакт'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Кресло 'Релакс'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Полица 'Минимал'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Огледало 'Кръг'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Табуретка 'Пуф'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Гардероб 'Сити'");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Кухненски шкаф");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Бар стол");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Трапезен комплект");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Нощно шкафче");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "TV Шкаф");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Холна маса");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Библиотека");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Закачалка");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Градинска маса");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Шезлонг");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Детско легло");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Скрин");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Компютърен стол");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Офис шкаф");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Ъглов диван");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Рафт");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Пейка");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Тоалетка");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorFurniture_Colors_ColorsId",
                table: "ColorFurniture",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FurnitureMaterial_Materials_MaterialsId",
                table: "FurnitureMaterial",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Brands_BrandId",
                table: "Furnitures",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Rooms_RoomId",
                table: "Furnitures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
