using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class HaneYonetimi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPersons_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyPersonId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_FamilyPersons_FamilyPersonId",
                        column: x => x.FamilyPersonId,
                        principalTable: "FamilyPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyPersonId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_FamilyPersons_FamilyPersonId",
                        column: x => x.FamilyPersonId,
                        principalTable: "FamilyPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketItemPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketItemId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketItemPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketItemPhotos_MarketItems_MarketItemId",
                        column: x => x.MarketItemId,
                        principalTable: "MarketItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    MarketItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseItems_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseItems_MarketItems_MarketItemId",
                        column: x => x.MarketItemId,
                        principalTable: "MarketItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gıda" },
                    { 2, "Temizlik" },
                    { 3, "Elektronik" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adet" },
                    { 2, "Kg" },
                    { 3, "Litre" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_ExpenseId",
                table: "ExpenseItems",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_MarketItemId",
                table: "ExpenseItems",
                column: "MarketItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_FamilyPersonId",
                table: "Expenses",
                column: "FamilyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPersons_RoleId",
                table: "FamilyPersons",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_FamilyPersonId",
                table: "Incomes",
                column: "FamilyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketItemPhotos_MarketItemId",
                table: "MarketItemPhotos",
                column: "MarketItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketItems_CategoryId",
                table: "MarketItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketItems_UnitId",
                table: "MarketItems",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseItems");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "MarketItemPhotos");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "MarketItems");

            migrationBuilder.DropTable(
                name: "FamilyPersons");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
