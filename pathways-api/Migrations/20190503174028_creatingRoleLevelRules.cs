using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pathways_api.Migrations
{
    public partial class creatingRoleLevelRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userskills",
                table: "userskills");

            migrationBuilder.DropIndex(
                name: "IX_userskills_UserId",
                table: "userskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roletypes",
                table: "roletypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "userskills");

            migrationBuilder.RenameTable(
                name: "roletypes",
                newName: "rolestypes");

            migrationBuilder.RenameColumn(
                name: "Login_id",
                table: "users",
                newName: "UserLoginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userskills",
                table: "userskills",
                columns: new[] { "UserId", "SkillTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolestypes",
                table: "rolestypes",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "userlogins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Deactivated = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_UserLoginId",
                table: "users",
                column: "UserLoginId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_users_userlogins_UserLoginId",
                table: "users",
                column: "UserLoginId",
                principalTable: "userlogins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_userlogins_UserLoginId",
                table: "users");

            migrationBuilder.DropTable(
                name: "RoleLevelRules");

            migrationBuilder.DropTable(
                name: "userlogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userskills",
                table: "userskills");

            migrationBuilder.DropIndex(
                name: "IX_users_UserLoginId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolestypes",
                table: "rolestypes");

            migrationBuilder.RenameTable(
                name: "rolestypes",
                newName: "roletypes");

            migrationBuilder.RenameColumn(
                name: "UserLoginId",
                table: "users",
                newName: "Login_id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "userskills",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userskills",
                table: "userskills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roletypes",
                table: "roletypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleLevelId = table.Column<int>(nullable: false),
                    RoleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roles_rolelevels_RoleLevelId",
                        column: x => x.RoleLevelId,
                        principalTable: "rolelevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_roletypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "roletypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userskills_UserId",
                table: "userskills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_RoleLevelId",
                table: "roles",
                column: "RoleLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_RoleTypeId",
                table: "roles",
                column: "RoleTypeId");
        }
    }
}
