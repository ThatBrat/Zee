using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Zee.Migrations
{
    public partial class SellerDispatchRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_Sellers_SellerId",
                table: "Dispatches");

            migrationBuilder.DropIndex(
                name: "IX_Dispatches_SellerId",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Dispatches");

            migrationBuilder.CreateTable(
                name: "SellerDispatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    DispatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerDispatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerDispatches_Dispatches_DispatchId",
                        column: x => x.DispatchId,
                        principalTable: "Dispatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerDispatches_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SellerDispatches_DispatchId",
                table: "SellerDispatches",
                column: "DispatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerDispatches_SellerId",
                table: "SellerDispatches",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerDispatches");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dispatches_SellerId",
                table: "Dispatches",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_Sellers_SellerId",
                table: "Dispatches",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
