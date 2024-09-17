using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dream_Reserve_Back.Migrations
{
    /// <inheritdoc />
    public partial class FlightTypeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "flight_type_id",
                table: "flights",
                type: "int(11)",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_flights_flight_type_id",
                table: "flights",
                column: "flight_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_flight_flight_type1",
                table: "flights",
                column: "flight_type_id",
                principalTable: "flight_types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_flight_flight_type1",
                table: "flights");

            migrationBuilder.DropIndex(
                name: "IX_flights_flight_type_id",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "flight_type_id",
                table: "flights");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "tours",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "rooms",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "reserves",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "foods",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "flight_types",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);
        }
    }
}
