using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class addstationIdToOrderTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Orders",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StationId",
                table: "Orders",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OilStations_StationId",
                table: "Orders",
                column: "StationId",
                principalTable: "OilStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OilStations_StationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Orders");
        }
    }
}
