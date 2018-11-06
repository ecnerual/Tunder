using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MatchesAndMAtchesActionRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_LikedID",
                table: "UserMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_LikerID",
                table: "UserMatches");

            migrationBuilder.RenameColumn(
                name: "LikedID",
                table: "UserMatches",
                newName: "MatchId");

            migrationBuilder.RenameColumn(
                name: "LikerID",
                table: "UserMatches",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LikedID",
                table: "UserMatches",
                newName: "IX_Matches_MatchId");

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchActions",
                columns: table => new
                {
                    LikerID = table.Column<long>(nullable: false),
                    LikedID = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchActions", x => new { x.LikerID, x.LikedID });
                    table.ForeignKey(
                        name: "FK_MatchActions_Users_LikedID",
                        column: x => x.LikedID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MatchActions_Users_LikerID",
                        column: x => x.LikerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_LikedID",
                table: "MatchActions",
                column: "LikedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Match_MatchId",
                table: "UserMatches",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "UserMatches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Match_MatchId",
                table: "UserMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "UserMatches");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "MatchActions");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "UserMatches",
                newName: "LikedID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserMatches",
                newName: "LikerID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_MatchId",
                table: "UserMatches",
                newName: "IX_Matches_LikedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_LikedID",
                table: "UserMatches",
                column: "LikedID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_LikerID",
                table: "UserMatches",
                column: "LikerID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
