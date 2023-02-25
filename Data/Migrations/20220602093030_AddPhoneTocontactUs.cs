using Microsoft.EntityFrameworkCore.Migrations;

namespace KhadimiEssa.Data.Migrations
{
    public partial class AddPhoneTocontactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ContactUs");
        }
    }
}
