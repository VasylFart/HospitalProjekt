using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V_Project.Infrastructure.Migrations
{
    public partial class Init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Statuses_StatusId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Patients",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_StatusId",
                table: "Patients",
                newName: "IX_Patients_DepartmentId");

            migrationBuilder.CreateTable(
                name: "Depatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatisticId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depatments_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Depatments",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 1, new Guid("00000000-0000-0000-0000-000000000000"), null, "Yellow" });

            migrationBuilder.InsertData(
                table: "Depatments",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 2, new Guid("00000000-0000-0000-0000-000000000000"), null, "Orange" });

            migrationBuilder.InsertData(
                table: "Depatments",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 3, new Guid("00000000-0000-0000-0000-000000000000"), null, "Green" });

            migrationBuilder.CreateIndex(
                name: "IX_Depatments_StatisticId",
                table: "Depatments",
                column: "StatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Depatments_DepartmentId",
                table: "Patients",
                column: "DepartmentId",
                principalTable: "Depatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Depatments_DepartmentId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Depatments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Patients",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_DepartmentId",
                table: "Patients",
                newName: "IX_Patients_StatusId");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatisticId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 1, new Guid("00000000-0000-0000-0000-000000000000"), null, "Yellow" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 2, new Guid("00000000-0000-0000-0000-000000000000"), null, "Orange" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "PatientId", "StatisticId", "Value" },
                values: new object[] { 3, new Guid("00000000-0000-0000-0000-000000000000"), null, "Green" });

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_StatisticId",
                table: "Statuses",
                column: "StatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Statuses_StatusId",
                table: "Patients",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
