using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class addrelationbtweenorderandtimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExecutionTime",
                table: "Orders",
                column: "ExecutionTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AvailableTimes_ExecutionTime",
                table: "Orders",
                column: "ExecutionTime",
                principalTable: "AvailableTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AvailableTimes_ExecutionTime",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ExecutionTime",
                table: "Orders");
        }
    }
}
