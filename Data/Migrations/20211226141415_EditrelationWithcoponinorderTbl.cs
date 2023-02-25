using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class EditrelationWithcoponinorderTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CoponId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders",
                column: "CoponId",
                principalTable: "Copon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CoponId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders",
                column: "CoponId",
                principalTable: "Copon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
