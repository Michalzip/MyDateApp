using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class migratev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageId",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageId",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "ToUserMessageId",
                table: "UserMessages",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "ByUserMessageId",
                table: "UserMessages",
                newName: "ByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserMessageId",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserMessageId",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserId",
                table: "UserLike",
                column: "ByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserId",
                table: "UserLike",
                column: "ToUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserId",
                table: "UserMessages",
                column: "ByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserId",
                table: "UserMessages",
                column: "ToUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserId",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserId",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "UserMessages",
                newName: "ToUserMessageId");

            migrationBuilder.RenameColumn(
                name: "ByUserId",
                table: "UserMessages",
                newName: "ByUserMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserId",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserId",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserId",
                table: "UserLike",
                column: "ByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserId",
                table: "UserLike",
                column: "ToUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageId",
                table: "UserMessages",
                column: "ByUserMessageId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageId",
                table: "UserMessages",
                column: "ToUserMessageId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
