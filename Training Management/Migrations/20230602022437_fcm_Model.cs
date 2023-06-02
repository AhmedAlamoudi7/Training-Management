using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Management.Migrations
{
    /// <inheritdoc />
    public partial class fcm_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FCMToken",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FCMToken",
                schema: "security",
                table: "Users");
        }
    }
}
