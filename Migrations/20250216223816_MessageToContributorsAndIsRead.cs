using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class MessageToContributorsAndIsRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "message_to_contributors",
                table: "list",
                type: "text",
                nullable: true,
                defaultValueSql: "NULL")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_value",
                table: "item",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "contribution",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "is_visible",
                table: "contribution",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValueSql: "'1'");

            migrationBuilder.AddColumn<bool>(
                name: "is_read",
                table: "contribution",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message_to_contributors",
                table: "list");

            migrationBuilder.DropColumn(
                name: "is_read",
                table: "contribution");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_value",
                table: "item",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "contribution",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "is_visible",
                table: "contribution",
                type: "tinyint(1)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);
        }
    }
}
