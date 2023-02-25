using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class addRelationBetweencarsAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarBrandId",
                table: "Orders",
                column: "CarBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CarBrands_CarBrandId",
                table: "Orders",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CarBrands_CarBrandId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarBrandId",
                table: "Orders");
        }
    }
}
