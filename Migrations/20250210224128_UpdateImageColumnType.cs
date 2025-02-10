using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<String>(
                name: "profile_image",
                table: "user",
                type: "text",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "list",
                type: "text",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "item",
                type: "text",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<String>(
                name: "profile_image",
                table: "user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<String>(
                name: "profile_image",
                table: "list",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "item",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );
        }
    }
}
