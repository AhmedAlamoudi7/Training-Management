using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shawrney.Data.Migrations
{
    public partial class AddRoles : Migration
    {
  

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Roles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "SuperAdmin", "SuperAdmin".ToUpper(), Guid.NewGuid().ToString() },
               schema: "security"
           ); migrationBuilder.InsertData(
               table: "Roles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Manager", "Manager".ToUpper(), Guid.NewGuid().ToString() },
               schema: "security"
           ); migrationBuilder.InsertData(
               table: "Roles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Trainee", "Trainee".ToUpper(), Guid.NewGuid().ToString() },
               schema: "security"
           );
            migrationBuilder.InsertData(
               table: "Roles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Adviser", "Adviser".ToUpper(), Guid.NewGuid().ToString() },
               schema: "security"
           );
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Roles]");

        }
    }
}
