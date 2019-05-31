using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class UserTableIndexHardening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_DomoIdentifier",
                schema: "admin",
                table: "users",
                column: "DomoIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Username",
                schema: "admin",
                table: "users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_DomoIdentifier",
                schema: "admin",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Username",
                schema: "admin",
                table: "users");
        }
    }
}
