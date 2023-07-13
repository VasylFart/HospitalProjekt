using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V_Project.Infrastructure.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberHome",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "HomeNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeNumber",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "NumberHome",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
