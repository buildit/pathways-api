using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class RoleTypesAndLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "skills",
                table: "roletype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "skills",
                table: "rolelevel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "skills",
                table: "rolelevel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "skills",
                table: "roletype");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "skills",
                table: "rolelevel");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "skills",
                table: "rolelevel");
        }
    }
}
