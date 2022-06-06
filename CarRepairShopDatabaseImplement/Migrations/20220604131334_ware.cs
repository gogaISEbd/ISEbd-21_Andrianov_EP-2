using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRepairShopDatabaseImplement.Migrations
{
    public partial class ware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsiblePersonFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouseComponents_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WareHouseComponents_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseComponents_ComponentId",
                table: "WareHouseComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseComponents_WareHouseId",
                table: "WareHouseComponents",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WareHouseComponents");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
