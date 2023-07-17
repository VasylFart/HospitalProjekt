using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V_Project.Infrastructure.Migrations
{
    public partial class Init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Doctors_DoctorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DoctorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OccupiedSlots",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmetId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmetId",
                table: "Doctors",
                column: "DepartmetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Depatments_DepartmetId",
                table: "Doctors",
                column: "DepartmetId",
                principalTable: "Depatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Depatments_DepartmetId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DepartmetId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OccupiedSlots",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DepartmetId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "Pesel",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DoctorId",
                table: "Comments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Doctors_DoctorId",
                table: "Comments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
