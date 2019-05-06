using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class RenameRoleLevelRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleLevelRules");

            migrationBuilder.CreateTable(
                name: "RoleLevelRule",
                columns: table => new
                {
                    RoleTypeId = table.Column<int>(nullable: false),
                    RoleLevelId = table.Column<int>(nullable: false),
                    SkillTypeId = table.Column<int>(nullable: false),
                    SkillLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLevelRule", x => new { x.RoleTypeId, x.RoleLevelId, x.SkillTypeId, x.SkillLevelId });
                    table.ForeignKey(
                        name: "FK_RoleLevelRule_rolelevels_RoleLevelId",
                        column: x => x.RoleLevelId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRule_rolestypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "rolestypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRule_rolelevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRule_rolelevels_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRule_RoleLevelId",
                table: "RoleLevelRule",
                column: "RoleLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRule_SkillLevelId",
                table: "RoleLevelRule",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRule_SkillTypeId",
                table: "RoleLevelRule",
                column: "SkillTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleLevelRule");

            migrationBuilder.CreateTable(
                name: "RoleLevelRules",
                columns: table => new
                {
                    RoleTypeId = table.Column<int>(nullable: false),
                    RoleLevelId = table.Column<int>(nullable: false),
                    SkillTypeId = table.Column<int>(nullable: false),
                    SkillLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLevelRules", x => new { x.RoleTypeId, x.RoleLevelId, x.SkillTypeId, x.SkillLevelId });
                    table.ForeignKey(
                        name: "FK_RoleLevelRules_rolelevels_RoleLevelId",
                        column: x => x.RoleLevelId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRules_rolestypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "rolestypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRules_rolelevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleLevelRules_rolelevels_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRules_RoleLevelId",
                table: "RoleLevelRules",
                column: "RoleLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRules_SkillLevelId",
                table: "RoleLevelRules",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLevelRules_SkillTypeId",
                table: "RoleLevelRules",
                column: "SkillTypeId");
        }
    }
}
