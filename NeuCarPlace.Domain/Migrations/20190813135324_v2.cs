using Microsoft.EntityFrameworkCore.Migrations;

namespace NeuCarPlace.Domain.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "Make");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Cars",
                newName: "Name");
        }
    }
}
