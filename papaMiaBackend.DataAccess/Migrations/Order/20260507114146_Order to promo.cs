using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace papaMiaBackend.DataAccess.Migrations.Order
{
    /// <inheritdoc />
    public partial class Ordertopromo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocodeId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Percent = table.Column<int>(type: "integer", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders",
                column: "PromocodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "Orders");
        }
    }
}
