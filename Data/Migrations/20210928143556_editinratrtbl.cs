using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class editinratrtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "RateDelget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "RateDelget");
        }
    }
}
