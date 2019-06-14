using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class TweakSchemaAndModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrules_rolelevels_RoleLevelId",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrules_rolestypes_RoleTypeId",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrules_rolelevels_SkillLevelId",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrules_skilltypes_SkillTypeId",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.DropForeignKey(
                name: "FK_userskills_skilllevels_SkillLevelId",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropForeignKey(
                name: "FK_userskills_skilltypes_SkillTypeId",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilltypes",
                schema: "skills",
                table: "skilltypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilllevels",
                schema: "skills",
                table: "skilllevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolestypes",
                schema: "skills",
                table: "rolestypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevels",
                schema: "skills",
                table: "rolelevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevelrules",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.RenameTable(
                name: "skilltypes",
                schema: "skills",
                newName: "skilltype",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "skilllevels",
                schema: "skills",
                newName: "skilllevel",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolestypes",
                schema: "skills",
                newName: "roletype",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolelevels",
                schema: "skills",
                newName: "rolelevel",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolelevelrules",
                schema: "admin",
                newName: "rolelevelrule",
                newSchema: "admin");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "skills",
                table: "roletype",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_SkillTypeId",
                schema: "admin",
                table: "rolelevelrule",
                newName: "IX_rolelevelrule_SkillTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule",
                newName: "IX_rolelevelrule_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_RoleLevelId",
                schema: "admin",
                table: "rolelevelrule",
                newName: "IX_rolelevelrule_RoleLevelId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "skills",
                table: "skilltype",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "admin",
                table: "rolelevelrule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilltype",
                schema: "skills",
                table: "skilltype",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilllevel",
                schema: "skills",
                table: "skilllevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roletype",
                schema: "skills",
                table: "roletype",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevel",
                schema: "skills",
                table: "rolelevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule",
                columns: new[] { "RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_rolelevel_RoleLevelId",
                schema: "admin",
                table: "rolelevelrule",
                column: "RoleLevelId",
                principalSchema: "skills",
                principalTable: "rolelevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_roletype_RoleTypeId",
                schema: "admin",
                table: "rolelevelrule",
                column: "RoleTypeId",
                principalSchema: "skills",
                principalTable: "roletype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_rolelevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "rolelevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrule_skilltype_SkillTypeId",
                schema: "admin",
                table: "rolelevelrule",
                column: "SkillTypeId",
                principalSchema: "skills",
                principalTable: "skilltype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userskills_skilllevel_SkillLevelId",
                schema: "assessment",
                table: "userskills",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "skilllevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userskills_skilltype_SkillTypeId",
                schema: "assessment",
                table: "userskills",
                column: "SkillTypeId",
                principalSchema: "skills",
                principalTable: "skilltype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_rolelevel_RoleLevelId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_roletype_RoleTypeId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_rolelevel_SkillLevelId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropForeignKey(
                name: "FK_rolelevelrule_skilltype_SkillTypeId",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropForeignKey(
                name: "FK_userskills_skilllevel_SkillLevelId",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropForeignKey(
                name: "FK_userskills_skilltype_SkillTypeId",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilltype",
                schema: "skills",
                table: "skilltype");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilllevel",
                schema: "skills",
                table: "skilllevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roletype",
                schema: "skills",
                table: "roletype");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevel",
                schema: "skills",
                table: "rolelevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "skills",
                table: "skilltype");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.RenameTable(
                name: "skilltype",
                schema: "skills",
                newName: "skilltypes",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "skilllevel",
                schema: "skills",
                newName: "skilllevels",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "roletype",
                schema: "skills",
                newName: "rolestypes",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolelevel",
                schema: "skills",
                newName: "rolelevels",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolelevelrule",
                schema: "admin",
                newName: "rolelevelrules",
                newSchema: "admin");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "skills",
                table: "rolestypes",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrule_SkillTypeId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_SkillTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrule_SkillLevelId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrule_RoleLevelId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_RoleLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilltypes",
                schema: "skills",
                table: "skilltypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilllevels",
                schema: "skills",
                table: "skilllevels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolestypes",
                schema: "skills",
                table: "rolestypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevels",
                schema: "skills",
                table: "rolelevels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevelrules",
                schema: "admin",
                table: "rolelevelrules",
                columns: new[] { "RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrules_rolelevels_RoleLevelId",
                schema: "admin",
                table: "rolelevelrules",
                column: "RoleLevelId",
                principalSchema: "skills",
                principalTable: "rolelevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrules_rolestypes_RoleTypeId",
                schema: "admin",
                table: "rolelevelrules",
                column: "RoleTypeId",
                principalSchema: "skills",
                principalTable: "rolestypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrules_rolelevels_SkillLevelId",
                schema: "admin",
                table: "rolelevelrules",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "rolelevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolelevelrules_skilltypes_SkillTypeId",
                schema: "admin",
                table: "rolelevelrules",
                column: "SkillTypeId",
                principalSchema: "skills",
                principalTable: "skilltypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userskills_skilllevels_SkillLevelId",
                schema: "assessment",
                table: "userskills",
                column: "SkillLevelId",
                principalSchema: "skills",
                principalTable: "skilllevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userskills_skilltypes_SkillTypeId",
                schema: "assessment",
                table: "userskills",
                column: "SkillTypeId",
                principalSchema: "skills",
                principalTable: "skilltypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
