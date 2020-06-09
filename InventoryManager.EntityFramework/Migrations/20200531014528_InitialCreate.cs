using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    MaximumCarryCapacity = table.Column<double>(nullable: false),
                    CurrentCarryCapacity = table.Column<double>(nullable: false),
                    Inventoryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x._id);
                    table.ForeignKey(
                        name: "FK_Containers_Inventories_Inventoryid",
                        column: x => x.Inventoryid,
                        principalTable: "Inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item_id = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Inventoryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_Inventoryid",
                        column: x => x.Inventoryid,
                        principalTable: "Inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Items_Item_id",
                        column: x => x.Item_id,
                        principalTable: "Items",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_Inventoryid",
                table: "Containers",
                column: "Inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_Inventoryid",
                table: "InventoryItems",
                column: "Inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_Item_id",
                table: "InventoryItems",
                column: "Item_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
