using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pathways_api.Migrations
{
    public partial class auditfields_and_AD_userdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "assessment",
                table: "userskills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "assessment",
                table: "userskills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                schema: "admin",
                table: "users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrganizationId",
                schema: "admin",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "admin",
                table: "rolelevelrule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EssentialSkill",
                schema: "admin",
                table: "rolelevelrule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "admin",
                table: "rolelevelrule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "assessment",
                table: "userskills");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                schema: "admin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "admin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropColumn(
                name: "EssentialSkill",
                schema: "admin",
                table: "rolelevelrule");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "admin",
                table: "rolelevelrule");
        }
    }
}
