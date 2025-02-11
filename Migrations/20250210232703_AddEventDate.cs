using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace echa_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddEventDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "list",
                type: "timestamp",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "list");
        }
    }
}
