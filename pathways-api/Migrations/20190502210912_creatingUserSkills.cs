using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pathways_api.Migrations
{
    public partial class creatingUserSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skilllevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skilllevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "skilltypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skilltypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userskills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<int>(nullable: false),
                    SkillLevelId = table.Column<int>(nullable: false),
                    SkillTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userskills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userskills_skilllevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "skilllevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userskills_skilltypes_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "skilltypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userskills_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userskills_SkillLevelId",
                table: "userskills",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_userskills_SkillTypeId",
                table: "userskills",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_userskills_UserId",
                table: "userskills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userskills");

            migrationBuilder.DropTable(
                name: "skilllevel");

            migrationBuilder.DropTable(
                name: "skilltypes");
        }
    }
}
