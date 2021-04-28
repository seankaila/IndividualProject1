using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroApp.Migrations
{
    public partial class updatedbheros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    HeroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Rival = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Power = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateOfBirth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Photo = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.HeroID);
                    table.ForeignKey(
                        name: "FK_Heros_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heros_TeamID",
                table: "Heros",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heros");
        }
    }
}
