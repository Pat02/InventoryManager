using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.EntityFramework.Migrations
{
    public partial class UpdatedDatabaseSchemaToNewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Items",
                newName: "Discriminator");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "CurrentCarryCapacity",
                table: "Items",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaximumCarryCapacity",
                table: "Items",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "id");

            migrationBuilder.CreateTable(
                name: "ContainerItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Itemid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Containerid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContainerItems_Items_Containerid",
                        column: x => x.Containerid,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerItems_Items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerItems_Containerid",
                table: "ContainerItems",
                column: "Containerid");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerItems_Itemid",
                table: "ContainerItems",
                column: "Itemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainerItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CurrentCarryCapacity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MaximumCarryCapacity",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Items",
                newName: "_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "_id");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentCarryCapacity = table.Column<double>(type: "REAL", nullable: false),
                    Inventoryid = table.Column<int>(type: "INTEGER", nullable: true),
                    MaximumCarryCapacity = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false)
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inventoryid = table.Column<int>(type: "INTEGER", nullable: true),
                    Item_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
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
    }
}
