using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class ChangeColumnNameRoleLEvelRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_rolelevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_skilllevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "skilllevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_skilllevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_rolelevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "rolelevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
