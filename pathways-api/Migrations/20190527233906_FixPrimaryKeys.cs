using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pathways_api.Migrations
{
    public partial class FixPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userskills",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "assessment",
                table: "userskills",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "admin",
                table: "rolelevelrule",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userskills",
                schema: "assessment",
                table: "userskills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_userskills_UserId_SkillTypeId",
                schema: "assessment",
                table: "userskills",
                columns: new[] { "UserId", "SkillTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rolelevelrule_RoleTypeId_RoleLevelId_SkillTypeId_SkillLevel~",
                schema: "admin",
                table: "rolelevelrule",
                columns: new[] { "RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userskills",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropIndex(
                name: "IX_userskills_UserId_SkillTypeId",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropIndex(
                name: "IX_rolelevelrule_RoleTypeId_RoleLevelId_SkillTypeId_SkillLevel~",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "admin",
                table: "rolelevelrule",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userskills",
                schema: "assessment",
                table: "userskills",
                columns: new[] { "UserId", "SkillTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolelevelrule",
                schema: "admin",
                table: "rolelevelrule",
                columns: new[] { "RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId" });
        }
    }
}
