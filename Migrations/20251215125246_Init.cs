using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtDecoMebel.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furnitures_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furnitures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogFurniture",
                columns: table => new
                {
                    CatalogsId = table.Column<int>(type: "int", nullable: false),
                    FurnituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogFurniture", x => new { x.CatalogsId, x.FurnituresId });
                    table.ForeignKey(
                        name: "FK_CatalogFurniture_Catalogs_CatalogsId",
                        column: x => x.CatalogsId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogFurniture_Furnitures_FurnituresId",
                        column: x => x.FurnituresId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorFurniture",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    FurnituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorFurniture", x => new { x.ColorsId, x.FurnituresId });
                    table.ForeignKey(
                        name: "FK_ColorFurniture_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorFurniture_Furnitures_FurnituresId",
                        column: x => x.FurnituresId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterial",
                columns: table => new
                {
                    FurnituresId = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterial", x => new { x.FurnituresId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_FurnitureMaterial_Furnitures_FurnituresId",
                        column: x => x.FurnituresId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterial_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IKEA" },
                    { 2, "JYSK" },
                    { 3, "Leroy Merlin" },
                    { 4, "HomeMax" },
                    { 5, "Bauhaus" },
                    { 6, "Mr. Bricolage" },
                    { 7, "Praktiker" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Бял" },
                    { 2, "Черен" },
                    { 3, "Сив" },
                    { 4, "Червен" },
                    { 5, "Син" },
                    { 6, "Зелен" },
                    { 7, "Жълт" },
                    { 8, "Кафяв" },
                    { 9, "Оранжев" },
                    { 10, "Лилав" },
                    { 11, "Розов" },
                    { 12, "Бежов" },
                    { 13, "Други" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Дърво" },
                    { 2, "Метал" },
                    { 3, "Пластмаса" },
                    { 4, "Стъкло" },
                    { 5, "Текстил" },
                    { 6, "Кожа" },
                    { 7, "Мрамор" },
                    { 8, "Гранитогрес" },
                    { 9, "Други" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Всекидневна" },
                    { 2, "Спалня" },
                    { 3, "Кухня" },
                    { 4, "Трапезария" },
                    { 5, "Баня" },
                    { 6, "Офис" },
                    { 7, "Детска стая" },
                    { 8, "Градина" },
                    { 9, "Други" }
                });

            migrationBuilder.InsertData(
                table: "Furnitures",
                columns: new[] { "Id", "BrandId", "Height", "Length", "Name", "Photo", "ProductionYear", "RoomId", "Width" },
                values: new object[,]
                {
                    { 1, 4, 100.8, 227.30000000000001, "Диван 'Виктория'", "furniture1.png", 2018, 9, 120.3 },
                    { 2, 7, 111.40000000000001, 288.69999999999999, "Маса 'Овал'", "furniture2.png", 2016, 8, 63.799999999999997 },
                    { 3, 1, 120.5, 100.09999999999999, "Стол 'Класик'", "furniture3.png", 2021, 2, 60.100000000000001 },
                    { 4, 6, 105.09999999999999, 230.09999999999999, "Легло 'Елеганс'", "furniture4.png", 2022, 2, 110.5 },
                    { 5, 1, 210.09999999999999, 150.5, "Секция 'Модерн'", "furniture5.png", 2020, 4, 40.5 },
                    { 6, 3, 75.0, 140.19999999999999, "Бюро 'Работно'", "furniture6.png", 2024, 6, 70.099999999999994 },
                    { 7, 5, 180.30000000000001, 80.0, "Шкаф 'Компакт'", "furniture7.png", 2019, 7, 45.5 },
                    { 8, 2, 110.09999999999999, 90.5, "Кресло 'Релакс'", "furniture8.png", 2021, 1, 95.5 },
                    { 9, 7, 60.0, 120.0, "Полица 'Минимал'", "furniture9.png", 2022, 9, 25.0 },
                    { 10, 1, 80.0, 80.0, "Огледало 'Кръг'", "furniture10.png", 2023, 5, 3.0 },
                    { 11, 2, 45.0, 40.0, "Табуретка 'Пуф'", "furniture11.png", 2024, 1, 40.0 },
                    { 12, 3, 220.0, 200.0, "Гардероб 'Сити'", "furniture12.png", 2017, 2, 60.0 },
                    { 13, 4, 85.0, 100.0, "Кухненски шкаф", "furniture13.png", 2020, 3, 50.0 },
                    { 14, 1, 100.0, 45.0, "Бар стол", "furniture14.png", 2021, 3, 45.0 },
                    { 15, 5, 75.0, 160.0, "Трапезен комплект", "furniture15.png", 2022, 4, 90.0 },
                    { 16, 6, 55.0, 50.0, "Нощно шкафче", "furniture16.png", 2023, 2, 40.0 },
                    { 17, 7, 50.0, 180.0, "TV Шкаф", "furniture17.png", 2019, 1, 45.0 },
                    { 18, 1, 45.0, 100.0, "Холна маса", "furniture18.png", 2020, 1, 60.0 },
                    { 19, 2, 200.0, 80.0, "Библиотека", "furniture19.png", 2021, 6, 30.0 },
                    { 20, 3, 180.0, 50.0, "Закачалка", "furniture20.png", 2022, 9, 50.0 },
                    { 21, 4, 70.0, 140.0, "Градинска маса", "furniture21.png", 2023, 8, 80.0 },
                    { 22, 5, 35.0, 190.0, "Шезлонг", "furniture22.png", 2024, 8, 70.0 },
                    { 23, 6, 60.0, 160.0, "Детско легло", "furniture23.png", 2020, 7, 80.0 },
                    { 24, 7, 80.0, 120.0, "Скрин", "furniture24.png", 2021, 2, 45.0 },
                    { 25, 1, 120.0, 60.0, "Компютърен стол", "furniture25.png", 2022, 6, 60.0 },
                    { 26, 2, 180.0, 80.0, "Офис шкаф", "furniture26.png", 2023, 6, 40.0 },
                    { 27, 3, 85.0, 280.0, "Ъглов диван", "furniture27.png", 2018, 1, 180.0 },
                    { 28, 4, 150.0, 100.0, "Рафт", "furniture28.png", 2019, 9, 20.0 },
                    { 29, 5, 45.0, 120.0, "Пейка", "furniture29.png", 2020, 8, 40.0 },
                    { 30, 6, 140.0, 90.0, "Тоалетка", "furniture30.png", 2021, 2, 40.0 }
                });

            migrationBuilder.InsertData(
                table: "ColorFurniture",
                columns: new[] { "ColorsId", "FurnituresId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 6 },
                    { 1, 8 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 15 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 23 },
                    { 1, 26 },
                    { 1, 27 },
                    { 1, 28 },
                    { 1, 30 },
                    { 2, 3 },
                    { 2, 13 },
                    { 2, 25 },
                    { 3, 3 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 8 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 22 },
                    { 3, 25 },
                    { 3, 27 },
                    { 3, 30 },
                    { 5, 19 },
                    { 5, 22 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 7 },
                    { 8, 9 },
                    { 8, 13 },
                    { 8, 14 },
                    { 8, 17 },
                    { 8, 20 },
                    { 8, 24 },
                    { 8, 26 },
                    { 8, 27 },
                    { 8, 29 },
                    { 11, 11 },
                    { 11, 23 },
                    { 12, 1 },
                    { 12, 4 },
                    { 12, 7 },
                    { 12, 8 },
                    { 12, 9 },
                    { 12, 11 },
                    { 12, 15 },
                    { 12, 16 },
                    { 12, 19 },
                    { 12, 21 },
                    { 12, 22 },
                    { 12, 23 },
                    { 12, 24 },
                    { 12, 27 },
                    { 12, 28 },
                    { 12, 29 },
                    { 12, 30 }
                });

            migrationBuilder.InsertData(
                table: "FurnitureMaterial",
                columns: new[] { "FurnituresId", "MaterialsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 7 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 9 },
                    { 5, 1 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 7 },
                    { 8, 1 },
                    { 8, 6 },
                    { 9, 1 },
                    { 9, 5 },
                    { 10, 3 },
                    { 10, 4 },
                    { 11, 1 },
                    { 11, 5 },
                    { 12, 1 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 6 },
                    { 14, 2 },
                    { 14, 6 },
                    { 15, 1 },
                    { 15, 4 },
                    { 15, 8 },
                    { 16, 1 },
                    { 16, 3 },
                    { 17, 1 },
                    { 17, 2 },
                    { 18, 1 },
                    { 18, 9 },
                    { 19, 1 },
                    { 19, 5 },
                    { 20, 1 },
                    { 20, 2 },
                    { 21, 1 },
                    { 21, 8 },
                    { 22, 1 },
                    { 22, 6 },
                    { 23, 1 },
                    { 23, 5 },
                    { 24, 1 },
                    { 25, 2 },
                    { 25, 3 },
                    { 26, 1 },
                    { 26, 2 },
                    { 27, 1 },
                    { 27, 2 },
                    { 27, 5 },
                    { 28, 1 },
                    { 28, 4 },
                    { 29, 1 },
                    { 29, 7 },
                    { 30, 1 },
                    { 30, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogFurniture_FurnituresId",
                table: "CatalogFurniture",
                column: "FurnituresId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_UserId",
                table: "Catalogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorFurniture_FurnituresId",
                table: "ColorFurniture",
                column: "FurnituresId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterial_MaterialsId",
                table: "FurnitureMaterial",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_BrandId",
                table: "Furnitures",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_RoomId",
                table: "Furnitures",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CatalogFurniture");

            migrationBuilder.DropTable(
                name: "ColorFurniture");

            migrationBuilder.DropTable(
                name: "FurnitureMaterial");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
