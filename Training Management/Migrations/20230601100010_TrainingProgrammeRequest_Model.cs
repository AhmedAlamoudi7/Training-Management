using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Management.Migrations
{
    /// <inheritdoc />
    public partial class TrainingProgrammeRequest_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TraingProgrameTrainees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TraingProgrameTrainees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TraingProgrameTrainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TraingProgrameTrainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TraingProgrameTrainees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TraingProgrameTrainees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TraingProgrameTrainees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TraingProgrameTrainees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TraingProgrameTrainees");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TraingProgrameTrainees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TraingProgrameTrainees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TraingProgrameTrainees");
        }
    }
}
