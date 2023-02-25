using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class Editinusertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OilStations_OilStationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "OilStationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OilStations_OilStationId",
                table: "AspNetUsers",
                column: "OilStationId",
                principalTable: "OilStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OilStations_OilStationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "OilStationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OilStations_OilStationId",
                table: "AspNetUsers",
                column: "OilStationId",
                principalTable: "OilStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
