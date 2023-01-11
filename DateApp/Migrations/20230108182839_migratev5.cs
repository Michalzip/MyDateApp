using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class migratev5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ByUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_UserProfiles_ToUserId",
                table: "UserLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike");

            migrationBuilder.RenameTable(
                name: "UserLike",
                newName: "UserLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ToUserId",
                table: "UserLikes",
                newName: "IX_UserLikes_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_ByUserId",
                table: "UserLikes",
                newName: "IX_UserLikes_ByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_UserProfiles_ByUserId",
                table: "UserLikes",
                column: "ByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_UserProfiles_ToUserId",
                table: "UserLikes",
                column: "ToUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_UserProfiles_ByUserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_UserProfiles_ToUserId",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.RenameTable(
                name: "UserLikes",
                newName: "UserLike");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_ToUserId",
                table: "UserLike",
                newName: "IX_UserLike_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_ByUserId",
                table: "UserLike",
                newName: "IX_UserLike_ByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike",
                column: "Id");

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
        }
    }
}
