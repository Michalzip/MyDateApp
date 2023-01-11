using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class migratev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserLikedIdUser",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserLikedIdUser",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageIdUser",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageIdUser",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "UserProfiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ToUserMessageIdUser",
                table: "UserMessages",
                newName: "ToUserMessageId");

            migrationBuilder.RenameColumn(
                name: "ByUserMessageIdUser",
                table: "UserMessages",
                newName: "ByUserMessageId");

            migrationBuilder.RenameColumn(
                name: "IdMessage",
                table: "UserMessages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserMessageIdUser",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserMessageIdUser",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserMessageId");

            migrationBuilder.RenameColumn(
                name: "ToUserLikedIdUser",
                table: "UserLike",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "ByUserLikedIdUser",
                table: "UserLike",
                newName: "ByUserId");

            migrationBuilder.RenameColumn(
                name: "IdLike",
                table: "UserLike",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ToUserLikedIdUser",
                table: "UserLike",
                newName: "IX_UserLike_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ByUserLikedIdUser",
                table: "UserLike",
                newName: "IX_UserLike_ByUserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Id",
                table: "UserProfiles",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "ToUserMessageId",
                table: "UserMessages",
                newName: "ToUserMessageIdUser");

            migrationBuilder.RenameColumn(
                name: "ByUserMessageId",
                table: "UserMessages",
                newName: "ByUserMessageIdUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserMessages",
                newName: "IdMessage");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserMessageId",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserMessageIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserMessageId",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserMessageIdUser");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "UserLike",
                newName: "ToUserLikedIdUser");

            migrationBuilder.RenameColumn(
                name: "ByUserId",
                table: "UserLike",
                newName: "ByUserLikedIdUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLike",
                newName: "IdLike");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ToUserId",
                table: "UserLike",
                newName: "IX_UserLike_ToUserLikedIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ByUserId",
                table: "UserLike",
                newName: "IX_UserLike_ByUserLikedIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserLikedIdUser",
                table: "UserLike",
                column: "ByUserLikedIdUser",
                principalTable: "UserProfiles",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserLikedIdUser",
                table: "UserLike",
                column: "ToUserLikedIdUser",
                principalTable: "UserProfiles",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageIdUser",
                table: "UserMessages",
                column: "ByUserMessageIdUser",
                principalTable: "UserProfiles",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageIdUser",
                table: "UserMessages",
                column: "ToUserMessageIdUser",
                principalTable: "UserProfiles",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
