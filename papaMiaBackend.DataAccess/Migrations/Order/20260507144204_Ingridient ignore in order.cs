using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace papaMiaBackend.DataAccess.Migrations.Order
{
    /// <inheritdoc />
    public partial class Ingridientignoreinorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderCustomPizzaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    CustomPizzaId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCustomPizzaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderCustomPizzaItems_CustomPizzas_CustomPizzaId",
                        column: x => x.CustomPizzaId,
                        principalTable: "CustomPizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCustomPizzaItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCustomPizzaItems_CustomPizzaId",
                table: "OrderCustomPizzaItems",
                column: "CustomPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCustomPizzaItems_OrderId",
                table: "OrderCustomPizzaItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCustomPizzaItems");
        }
    }
}
