using Microsoft.EntityFrameworkCore.Migrations;

namespace RemDijital.EmlakTakip.Migrations
{
    public partial class EstateTableUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MahalleId",
                table: "Estates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "MahalleId",
                table: "Estates");
        }
    }
}
