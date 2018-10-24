using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Match : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivited",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    LikerID = table.Column<long>(nullable: false),
                    LikedID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => new { x.LikerID, x.LikedID });
                    table.ForeignKey(
                        name: "FK_Matches_Users_LikedID",
                        column: x => x.LikedID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Users_LikerID",
                        column: x => x.LikerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LikedID",
                table: "Matches",
                column: "LikedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivited",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }
    }
}
