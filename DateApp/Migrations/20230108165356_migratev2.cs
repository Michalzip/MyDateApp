using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class migratev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageUserId",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageUserId",
                table: "UserMessages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfiles",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "ToUserMessageUserId",
                table: "UserMessages",
                newName: "ToUserMessageIdUser");

            migrationBuilder.RenameColumn(
                name: "ByUserMessageUserId",
                table: "UserMessages",
                newName: "ByUserMessageIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserMessageUserId",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserMessageIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserMessageUserId",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserMessageIdUser");

            migrationBuilder.CreateTable(
                name: "UserLike",
                columns: table => new
                {
                    IdLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ByUserLikedIdUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToUserLikedIdUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLike", x => x.IdLike);
                    table.ForeignKey(
                        name: "FK_UserLike_UserProfiles_ByUserLikedIdUser",
                        column: x => x.ByUserLikedIdUser,
                        principalTable: "UserProfiles",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_UserLike_UserProfiles_ToUserLikedIdUser",
                        column: x => x.ToUserLikedIdUser,
                        principalTable: "UserProfiles",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_ByUserLikedIdUser",
                table: "UserLike",
                column: "ByUserLikedIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_ToUserLikedIdUser",
                table: "UserLike",
                column: "ToUserLikedIdUser");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageIdUser",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageIdUser",
                table: "UserMessages");

            migrationBuilder.DropTable(
                name: "UserLike");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "UserProfiles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ToUserMessageIdUser",
                table: "UserMessages",
                newName: "ToUserMessageUserId");

            migrationBuilder.RenameColumn(
                name: "ByUserMessageIdUser",
                table: "UserMessages",
                newName: "ByUserMessageUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ToUserMessageIdUser",
                table: "UserMessages",
                newName: "IX_UserMessages_ToUserMessageUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMessages_ByUserMessageIdUser",
                table: "UserMessages",
                newName: "IX_UserMessages_ByUserMessageUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ByUserMessageUserId",
                table: "UserMessages",
                column: "ByUserMessageUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_UserProfiles_ToUserMessageUserId",
                table: "UserMessages",
                column: "ToUserMessageUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
