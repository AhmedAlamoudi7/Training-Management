using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_new_Mode_And_Fix_issues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Trainees_TraineeId",
                table: "Document");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "TraineeTrainingProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Advisors");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TrainingPrograms",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Trainees",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Document_TraineeId",
                table: "Documents",
                newName: "IX_Documents_TraineeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TrainingPrograms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "TrainingPrograms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "TrainingPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "TrainingPrograms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderType",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Meeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeetings_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeetings_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraingProgrameTrainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    TrainingProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraingProgrameTrainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraingProgrameTrainees_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraingProgrameTrainees_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeetings_AdvisorId",
                table: "Meeetings",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeetings_TraineeId",
                table: "Meeetings",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_TraingProgrameTrainees_TraineeId",
                table: "TraingProgrameTrainees",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_TraingProgrameTrainees_TrainingProgramId",
                table: "TraingProgrameTrainees",
                column: "TrainingProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Trainees_TraineeId",
                table: "Documents",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Trainees_TraineeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Meeetings");

            migrationBuilder.DropTable(
                name: "TraingProgrameTrainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "End",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "GenderType",
                table: "Trainees");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TrainingPrograms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Trainees",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_TraineeId",
                table: "Document",
                newName: "IX_Document_TraineeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Trainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discipline",
                table: "Advisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Advisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeTrainingProgram",
                columns: table => new
                {
                    TraineesId = table.Column<int>(type: "int", nullable: false),
                    TrainingProgramsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeTrainingProgram", x => new { x.TraineesId, x.TrainingProgramsId });
                    table.ForeignKey(
                        name: "FK_TraineeTrainingProgram_Trainees_TraineesId",
                        column: x => x.TraineesId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeTrainingProgram_TrainingPrograms_TrainingProgramsId",
                        column: x => x.TrainingProgramsId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AdvisorId",
                table: "Appointment",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TraineeId",
                table: "Appointment",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTrainingProgram_TrainingProgramsId",
                table: "TraineeTrainingProgram",
                column: "TrainingProgramsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Trainees_TraineeId",
                table: "Document",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
