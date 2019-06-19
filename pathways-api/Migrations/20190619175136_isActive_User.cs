using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class isActive_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "admin",
                table: "users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "admin",
                table: "users");
        }
    }
}
