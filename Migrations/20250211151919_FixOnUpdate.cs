using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class FixOnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total_value",
                table: "item",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "contribution",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "authentication_method",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "category",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "contribution",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "font",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "item",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "list",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "notification",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "password_recovery",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "payment_method",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_contribution",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_item",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_list",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_transaction",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_user",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "transaction",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "type_notification",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "user",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "NULL"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total_value",
                table: "item",
                type: "decimal(10,2)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "contribution",
                type: "decimal(10,2)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "authentication_method",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "category",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "contribution",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "font",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "item",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "list",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "notification",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "password_recovery",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "payment_method",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_contribution",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_item",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_list",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_transaction",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "status_user",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "transaction",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "type_notification",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "user",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: false,
                oldDefaultValueSql: "NULL ON UPDATE CURRENT_TIMESTAMP"
            );
        }
    }
}
