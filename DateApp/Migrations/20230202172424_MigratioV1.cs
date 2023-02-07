using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class MigratioV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentsStatus",
                table: "PaymentsStatus");

            migrationBuilder.RenameTable(
                name: "PaymentsStatus",
                newName: "StatusTransactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusTransactions",
                table: "StatusTransactions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusTransactions",
                table: "StatusTransactions");

            migrationBuilder.RenameTable(
                name: "StatusTransactions",
                newName: "PaymentsStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentsStatus",
                table: "PaymentsStatus",
                column: "Id");
        }
    }
}
