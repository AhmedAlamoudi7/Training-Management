using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvisor_TrainigProgrammeing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "TrainingPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_AdvisorId",
                table: "TrainingPrograms",
                column: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_Advisors_AdvisorId",
                table: "TrainingPrograms",
                column: "AdvisorId",
                principalTable: "Advisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_Advisors_AdvisorId",
                table: "TrainingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPrograms_AdvisorId",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "TrainingPrograms");
        }
    }
}
