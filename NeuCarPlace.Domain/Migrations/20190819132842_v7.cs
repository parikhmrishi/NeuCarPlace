using Microsoft.EntityFrameworkCore.Migrations;

namespace NeuCarPlace.Domain.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarSpecs_CarId",
                table: "CarSpecs");

            migrationBuilder.CreateIndex(
                name: "IX_CarSpecs_CarId",
                table: "CarSpecs",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarSpecs_CarId",
                table: "CarSpecs");

            migrationBuilder.CreateIndex(
                name: "IX_CarSpecs_CarId",
                table: "CarSpecs",
                column: "CarId");
        }
    }
}
