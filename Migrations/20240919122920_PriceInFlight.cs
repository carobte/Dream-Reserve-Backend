using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dream_Reserve_Back.Migrations
{
    /// <inheritdoc />
    public partial class PriceInFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "flights",
                type: "decimal(10)",
                precision: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "flights");

        }
    }
}
