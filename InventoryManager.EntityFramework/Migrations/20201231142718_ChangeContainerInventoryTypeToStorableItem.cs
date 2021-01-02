using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.EntityFramework.Migrations
{
    public partial class ChangeContainerInventoryTypeToStorableItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainerItems");

            migrationBuilder.DropColumn(
                name: "CurrentCarryCapacity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "MaximumCarryCapacity",
                table: "Items",
                newName: "MaximumCarryWeight");

            migrationBuilder.AddColumn<Guid>(
                name: "Containerid",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRootContainer",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Containerid",
                table: "Items",
                column: "Containerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_Containerid",
                table: "Items",
                column: "Containerid",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_Containerid",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Containerid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Containerid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsRootContainer",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MaximumCarryWeight",
                table: "Items",
                newName: "MaximumCarryCapacity");

            migrationBuilder.AddColumn<double>(
                name: "CurrentCarryCapacity",
                table: "Items",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Items",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ContainerItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Containerid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Itemid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
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
    }
}
