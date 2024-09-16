using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dream_Reserve_Back.Migrations
{
    /// <inheritdoc />
    public partial class TablesFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.RenameTable(
                name: "tour",
                newName: "tours");

            migrationBuilder.RenameTable(
                name: "room",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "review",
                newName: "reviews");

            migrationBuilder.RenameTable(
                name: "reserve",
                newName: "reserves");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "people");

            migrationBuilder.RenameTable(
                name: "hotel",
                newName: "hotels");

            migrationBuilder.RenameTable(
                name: "food",
                newName: "foods");

            migrationBuilder.RenameTable(
                name: "flight",
                newName: "flights");

            migrationBuilder.RenameTable(
                name: "document_type",
                newName: "document_types");

            migrationBuilder.RenameIndex(
                name: "IX_review_person_id",
                table: "reviews",
                newName: "IX_reviews_person_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "tours",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AddColumn<string>(
                name: "urlImages",
                table: "tours",
                type: "mediumtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "rooms",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AddColumn<string>(
                name: "urlImages",
                table: "rooms",
                type: "mediumtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "reserves",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AddColumn<string>(
                name: "urlAvatar",
                table: "people",
                type: "mediumtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "hotels",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "hotels",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "urlImages",
                table: "hotels",
                type: "mediumtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "foods",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "flights",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviews",
                table: "reviews",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "urlImages",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "urlImages",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "urlAvatar",
                table: "people");

            migrationBuilder.DropColumn(
                name: "city",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "urlImages",
                table: "hotels");

            migrationBuilder.RenameTable(
                name: "tours",
                newName: "tour");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "room");

            migrationBuilder.RenameTable(
                name: "reviews",
                newName: "review");

            migrationBuilder.RenameTable(
                name: "reserves",
                newName: "reserve");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "person");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "hotel");

            migrationBuilder.RenameTable(
                name: "foods",
                newName: "food");

            migrationBuilder.RenameTable(
                name: "flights",
                newName: "flight");

            migrationBuilder.RenameTable(
                name: "document_types",
                newName: "document_type");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_person_id",
                table: "review",
                newName: "IX_review_person_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "tour",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "room",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "reserve",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "food",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "flight",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                column: "id");
        }
    }
}
