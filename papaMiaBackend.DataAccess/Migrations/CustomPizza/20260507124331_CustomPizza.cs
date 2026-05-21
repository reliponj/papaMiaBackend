using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace papaMiaBackend.DataAccess.Migrations.CustomPizza
{
    /// <inheritdoc />
    public partial class CustomPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomPizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomPizzaIngridients",
                columns: table => new
                {
                    CustomPizzasId = table.Column<int>(type: "integer", nullable: false),
                    IngridientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPizzaIngridients", x => new { x.CustomPizzasId, x.IngridientsId });
                    table.ForeignKey(
                        name: "FK_CustomPizzaIngridients_CustomPizzas_CustomPizzasId",
                        column: x => x.CustomPizzasId,
                        principalTable: "CustomPizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomPizzaIngridients_Ingridients_IngridientsId",
                        column: x => x.IngridientsId,
                        principalTable: "Ingridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPizzaIngridients_IngridientsId",
                table: "CustomPizzaIngridients",
                column: "IngridientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomPizzaIngridients");

            migrationBuilder.DropTable(
                name: "CustomPizzas");
        }
    }
}
