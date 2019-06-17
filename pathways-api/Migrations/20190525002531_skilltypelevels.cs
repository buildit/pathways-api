using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pathways_api.Migrations
{
    public partial class skilltypelevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "skills",
                table: "skilllevel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "skills",
                table: "skilllevel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "skilltypelevel",
                schema: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SkillTypeId = table.Column<int>(nullable: false),
                    SkillLevelId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skilltypelevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_skilltypelevel_skilllevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalSchema: "skills",
                        principalTable: "skilllevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skilltypelevel_skilltype_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalSchema: "skills",
                        principalTable: "skilltype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_skilltypelevel_SkillLevelId",
                schema: "skills",
                table: "skilltypelevel",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_skilltypelevel_SkillTypeId",
                schema: "skills",
                table: "skilltypelevel",
                column: "SkillTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "skilltypelevel",
                schema: "skills");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "skills",
                table: "skilllevel");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "skills",
                table: "skilllevel");
        }
    }
}
