using Microsoft.EntityFrameworkCore.Migrations;

namespace NeuCarPlace.Domain.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases");
        }
    }
}
