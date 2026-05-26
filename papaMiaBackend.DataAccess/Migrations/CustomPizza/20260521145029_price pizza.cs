using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace papaMiaBackend.DataAccess.Migrations.CustomPizza
{
    /// <inheritdoc />
    public partial class pricepizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "CustomPizzas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CustomPizzas");
        }
    }
}
