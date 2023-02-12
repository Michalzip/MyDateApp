using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class MigratioV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ByUserId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ByUserId",
                table: "Transactions",
                column: "ByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserProfiles_ByUserId",
                table: "Transactions",
                column: "ByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserProfiles_ByUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ByUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ByUserId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
