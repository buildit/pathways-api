using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pathways_api.Migrations
{
    public partial class CreateSchemasAndRearrangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleLevelRule_rolelevels_RoleLevelId",
                table: "RoleLevelRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleLevelRule_rolestypes_RoleTypeId",
                table: "RoleLevelRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleLevelRule_rolelevels_SkillLevelId",
                table: "RoleLevelRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleLevelRule_rolelevels_SkillTypeId",
                table: "RoleLevelRule");

            migrationBuilder.DropForeignKey(
                name: "FK_users_userlogins_UserLoginId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_userskills_skilllevel_SkillLevelId",
                table: "userskills");

            migrationBuilder.DropTable(
                name: "userlogins");

            migrationBuilder.DropIndex(
                name: "IX_users_UserLoginId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilllevel",
                table: "skilllevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleLevelRule",
                table: "RoleLevelRule");

            migrationBuilder.DropColumn(
                name: "UserLoginId",
                table: "users");

            migrationBuilder.EnsureSchema(
                name: "skills");

            migrationBuilder.EnsureSchema(
                name: "admin");

            migrationBuilder.EnsureSchema(
                name: "assessment");

            migrationBuilder.RenameTable(
                name: "userskills",
                newName: "userskills",
                newSchema: "assessment");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "admin");

            migrationBuilder.RenameTable(
                name: "skilltypes",
                newName: "skilltypes",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolestypes",
                newName: "rolestypes",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "rolelevels",
                newName: "rolelevels",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "skilllevel",
                newName: "skilllevels",
                newSchema: "skills");

            migrationBuilder.RenameTable(
                name: "RoleLevelRule",
                newName: "rolelevelrules",
                newSchema: "admin");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "admin",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "admin",
                table: "users",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_RoleLevelRule_SkillTypeId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_SkillTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleLevelRule_SkillLevelId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleLevelRule_RoleLevelId",
                schema: "admin",
                table: "rolelevelrules",
                newName: "IX_rolelevelrules_RoleLevelId");

            migrationBuilder.AddColumn<string>(
                name: "DirectoryName",
                schema: "admin",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomoIdentifier",
                schema: "admin",
                table: "users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilllevels",
                schema: "skills",
                table: "skilllevels",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_skilllevels",
                schema: "skills",
                table: "skilllevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevelrules",
                schema: "admin",
                table: "rolelevelrules");

            migrationBuilder.DropColumn(
                name: "DirectoryName",
                schema: "admin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DomoIdentifier",
                schema: "admin",
                table: "users");

            migrationBuilder.RenameTable(
                name: "skilltypes",
                schema: "skills",
                newName: "skilltypes");

            migrationBuilder.RenameTable(
                name: "rolestypes",
                schema: "skills",
                newName: "rolestypes");

            migrationBuilder.RenameTable(
                name: "rolelevels",
                schema: "skills",
                newName: "rolelevels");

            migrationBuilder.RenameTable(
                name: "userskills",
                schema: "assessment",
                newName: "userskills");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "admin",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "skilllevels",
                schema: "skills",
                newName: "skilllevel");

            migrationBuilder.RenameTable(
                name: "rolelevelrules",
                schema: "admin",
                newName: "RoleLevelRule");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_SkillTypeId",
                table: "RoleLevelRule",
                newName: "IX_RoleLevelRule_SkillTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_SkillLevelId",
                table: "RoleLevelRule",
                newName: "IX_RoleLevelRule_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_rolelevelrules_RoleLevelId",
                table: "RoleLevelRule",
                newName: "IX_RoleLevelRule_RoleLevelId");

            migrationBuilder.AddColumn<int>(
                name: "UserLoginId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_skilllevel",
                table: "skilllevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleLevelRule",
                table: "RoleLevelRule",
                columns: new[] { "RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId" });

            migrationBuilder.CreateTable(
                name: "userlogins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Deactivated = table.Column<bool>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_UserLoginId",
                table: "users",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleLevelRule_rolelevels_RoleLevelId",
                table: "RoleLevelRule",
                column: "RoleLevelId",
                principalTable: "rolelevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleLevelRule_rolestypes_RoleTypeId",
                table: "RoleLevelRule",
                column: "RoleTypeId",
                principalTable: "rolestypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleLevelRule_rolelevels_SkillLevelId",
                table: "RoleLevelRule",
                column: "SkillLevelId",
                principalTable: "rolelevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleLevelRule_rolelevels_SkillTypeId",
                table: "RoleLevelRule",
                column: "SkillTypeId",
                principalTable: "rolelevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_userlogins_UserLoginId",
                table: "users",
                column: "UserLoginId",
                principalTable: "userlogins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userskills_skilllevel_SkillLevelId",
                table: "userskills",
                column: "SkillLevelId",
                principalTable: "skilllevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
