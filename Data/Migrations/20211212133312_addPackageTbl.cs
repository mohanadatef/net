using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class addPackageTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Copon",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CoponId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CoponId",
                table: "Orders",
                column: "CoponId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackageId",
                table: "Orders",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders",
                column: "CoponId",
                principalTable: "Copon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packages_PackageId",
                table: "Orders",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Copon_CoponId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packages_PackageId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CoponId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PackageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CoponId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Copon",
                newName: "ID");
        }
    }
}
