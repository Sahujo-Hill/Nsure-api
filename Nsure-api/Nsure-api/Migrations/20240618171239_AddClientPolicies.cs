using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nsure_api.Migrations
{
    public partial class AddClientPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "policies",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "carPolicy",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "homePolicy",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lifePolicy",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "carPolicy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "homePolicy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "lifePolicy",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "policies",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
