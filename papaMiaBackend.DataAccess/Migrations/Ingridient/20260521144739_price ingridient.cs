using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace papaMiaBackend.DataAccess.Migrations.Ingridient
{
    /// <inheritdoc />
    public partial class priceingridient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Ingridients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Ingridients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ingridients");
        }
    }
}
