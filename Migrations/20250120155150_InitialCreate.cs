using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "authentication_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "font",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status_contribution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status_transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "type_notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    authentication_method_id = table.Column<int>(type: "int(11)", nullable: false),
                    status_user_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    pix_key = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    contact_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true, defaultValueSql: null),
                    profile_image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: null),
                    external_auth_id = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "user_ibfk_1",
                        column: x => x.authentication_method_id,
                        principalTable: "authentication_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_ibfk_2",
                        column: x => x.status_user_id,
                        principalTable: "status_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "error_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    error_level = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    error_message = table.Column<string>(type: "text", nullable: false),
                    error_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: null),
                    user_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    occurrence_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    stack_trace = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    request_data = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    additional_info = table.Column<string>(type: "text", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "error_log_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    font_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    status_list_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    highlight_color = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true, defaultValueSql: "'#609558'"),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "list_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "list_ibfk_2",
                        column: x => x.font_id,
                        principalTable: "font",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "list_ibfk_3",
                        column: x => x.status_list_id,
                        principalTable: "status_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    type_notification_id = table.Column<int>(type: "int(11)", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    notification_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    read = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "notification_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "notification_ibfk_2",
                        column: x => x.type_notification_id,
                        principalTable: "type_notification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "password_recovery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    token = table.Column<string>(type: "varchar(255)", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    utilization_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "password_recovery_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    list_id = table.Column<int>(type: "int(11)", nullable: false),
                    category_id = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    status_item_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    total_value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: null),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "item_ibfk_1",
                        column: x => x.list_id,
                        principalTable: "list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "item_ibfk_2",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "item_ibfk_3",
                        column: x => x.status_item_id,
                        principalTable: "status_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contribution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(type: "int(11)", nullable: false),
                    value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    contributor_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    contributor_email = table.Column<string>(type: "varchar(255)", nullable: false),
                    message = table.Column<string>(type: "text", nullable: true, defaultValueSql: null),
                    status_contribution_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "contribution_ibfk_1",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contribution_ibfk_2",
                        column: x => x.status_contribution_id,
                        principalTable: "status_contribution",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contribution_id = table.Column<int>(type: "int(11)", nullable: false),
                    payment_method_id = table.Column<int>(type: "int(11)", nullable: false),
                    status_transaction_id = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    transaction_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    transaction_reference = table.Column<string>(type: "varchar(255)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "transaction_ibfk_1",
                        column: x => x.contribution_id,
                        principalTable: "contribution",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "transaction_ibfk_2",
                        column: x => x.payment_method_id,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "transaction_ibfk_3",
                        column: x => x.status_transaction_id,
                        principalTable: "status_transaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "name",
                table: "authentication_method",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_contribution_email",
                table: "contribution",
                column: "contributor_email");

            migrationBuilder.CreateIndex(
                name: "idx_contribution_item_id",
                table: "contribution",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "idx_contribution_status_contribution_id",
                table: "contribution",
                column: "status_contribution_id");

            migrationBuilder.CreateIndex(
                name: "idx_error_log_user_id",
                table: "error_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "name1",
                table: "font",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_item_category_id",
                table: "item",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "idx_item_list_id",
                table: "item",
                column: "list_id");

            migrationBuilder.CreateIndex(
                name: "idx_item_status_item_id",
                table: "item",
                column: "status_item_id");

            migrationBuilder.CreateIndex(
                name: "idx_list_font_id",
                table: "list",
                column: "font_id");

            migrationBuilder.CreateIndex(
                name: "idx_list_status_list_id",
                table: "list",
                column: "status_list_id");

            migrationBuilder.CreateIndex(
                name: "idx_list_user_id",
                table: "list",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_notification_type_notification_id",
                table: "notification",
                column: "type_notification_id");

            migrationBuilder.CreateIndex(
                name: "idx_notification_user_id",
                table: "notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_password_recovery_user_id",
                table: "password_recovery",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "token",
                table: "password_recovery",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name2",
                table: "payment_method",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name3",
                table: "status_contribution",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name4",
                table: "status_item",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name5",
                table: "status_list",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name6",
                table: "status_transaction",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name7",
                table: "status_user",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_transaction_contribution_id",
                table: "transaction",
                column: "contribution_id");

            migrationBuilder.CreateIndex(
                name: "idx_transaction_payment_method_id",
                table: "transaction",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "idx_transaction_status_transaction_id",
                table: "transaction",
                column: "status_transaction_id");

            migrationBuilder.CreateIndex(
                name: "transaction_reference",
                table: "transaction",
                column: "transaction_reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name8",
                table: "type_notification",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "cpf",
                table: "user",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "external_auth_id",
                table: "user",
                column: "external_auth_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_user_authentication_method_id",
                table: "user",
                column: "authentication_method_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_status_user_id",
                table: "user",
                column: "status_user_id");

            migrationBuilder.CreateIndex(
                name: "pix_key",
                table: "user",
                column: "pix_key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "error_log");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "password_recovery");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "type_notification");

            migrationBuilder.DropTable(
                name: "contribution");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropTable(
                name: "status_transaction");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "status_contribution");

            migrationBuilder.DropTable(
                name: "list");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "status_item");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "font");

            migrationBuilder.DropTable(
                name: "status_list");

            migrationBuilder.DropTable(
                name: "authentication_method");

            migrationBuilder.DropTable(
                name: "status_user");
        }
    }
}
