using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beatributos.Migrations.LocalServer
{
    /// <inheritdoc />
    public partial class LogsUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLog",
                table: "AppLog");

            migrationBuilder.RenameTable(
                name: "AppLog",
                newName: "appLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appLogs",
                table: "appLogs",
                column: "AppLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appLogs",
                table: "appLogs");

            migrationBuilder.RenameTable(
                name: "appLogs",
                newName: "AppLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLog",
                table: "AppLog",
                column: "AppLogId");
        }
    }
}
