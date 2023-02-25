using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class deleteProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "paymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OilStations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Copon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "paymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OilStations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Copon");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarBrands");
        }
    }
}
