using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    AvalibleQuantity = table.Column<int>(nullable: false),
                    UnavalibleQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    SectorType = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 30, nullable: true),
                    Column = table.Column<string>(maxLength: 30, nullable: true),
                    Level = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Availability = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    StockSectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPosition_StockSector_StockSectorId",
                        column: x => x.StockSectorId,
                        principalTable: "StockSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    StockPositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMovement_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMovement_StockPosition_StockPositionId",
                        column: x => x.StockPositionId,
                        principalTable: "StockPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockBalance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    StockPositionId = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockBalance_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockBalance_StockPosition_StockPositionId",
                        column: x => x.StockPositionId,
                        principalTable: "StockPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_ProductId",
                table: "InventoryMovement",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_StockPositionId",
                table: "InventoryMovement",
                column: "StockPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBalance_ProductId",
                table: "StockBalance",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBalance_StockPositionId",
                table: "StockBalance",
                column: "StockPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPosition_StockSectorId",
                table: "StockPosition",
                column: "StockSectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMovement");

            migrationBuilder.DropTable(
                name: "StockBalance");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "StockPosition");

            migrationBuilder.DropTable(
                name: "StockSector");
        }
    }
}
