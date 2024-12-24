using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAL_Estate.Data.Migrations
{
    public partial class Realesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filee_Property_PropertyId1",
                table: "Filee");

            migrationBuilder.DropIndex(
                name: "IX_Filee_PropertyId1",
                table: "Filee");

            migrationBuilder.DropColumn(
                name: "PropertyId1",
                table: "Filee");

            migrationBuilder.AddColumn<int>(
                name: "propertyId",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "Filee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Filee_PropertyId",
                table: "Filee",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filee_Property_PropertyId",
                table: "Filee",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filee_Property_PropertyId",
                table: "Filee");

            migrationBuilder.DropIndex(
                name: "IX_Filee_PropertyId",
                table: "Filee");

            migrationBuilder.DropColumn(
                name: "propertyId",
                table: "Property");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Filee",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PropertyId1",
                table: "Filee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Filee_PropertyId1",
                table: "Filee",
                column: "PropertyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Filee_Property_PropertyId1",
                table: "Filee",
                column: "PropertyId1",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
