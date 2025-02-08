using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddListImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "list",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "list",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
