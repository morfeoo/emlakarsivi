using Microsoft.EntityFrameworkCore.Migrations;

namespace RemDijital.EmlakTakip.Migrations
{
    public partial class EstateTable_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstateTypeId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Estates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleTypeId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "EstateTypeId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "SaleTypeId",
                table: "Estates");
        }
    }
}
