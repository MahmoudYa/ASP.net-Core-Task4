using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAL_Estate.Data.Migrations
{
    public partial class Reale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "EProperty",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)",
                oldPrecision: 15,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "EProperty",
                type: "decimal(15,2)",
                precision: 15,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
