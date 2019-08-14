using Microsoft.EntityFrameworkCore.Migrations;

namespace NeuCarPlace.Domain.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelNumber",
                table: "Cars",
                newName: "ModelName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "Cars",
                newName: "ModelNumber");
        }
    }
}
