using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAL_Estate.Data.Migrations
{
    public partial class updateLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Property");
        }
    }
}
