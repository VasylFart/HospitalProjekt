using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V_Project.Infrastructure.Migrations
{
    public partial class Init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depatments_Statistic_StatisticId",
                table: "Depatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Statistic_StatisticId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Statistic_StatisticId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Statistic_StatisticId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_StatisticId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Patients_StatisticId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_StatisticId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Depatments_StatisticId",
                table: "Depatments");

            migrationBuilder.DropColumn(
                name: "StatisticId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "StatisticId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "StatisticId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "StatisticId",
                table: "Depatments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatisticId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticId",
                table: "Depatments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StatisticId",
                table: "Rooms",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StatisticId",
                table: "Patients",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_StatisticId",
                table: "Doctors",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Depatments_StatisticId",
                table: "Depatments",
                column: "StatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depatments_Statistic_StatisticId",
                table: "Depatments",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Statistic_StatisticId",
                table: "Doctors",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Statistic_StatisticId",
                table: "Patients",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Statistic_StatisticId",
                table: "Rooms",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
