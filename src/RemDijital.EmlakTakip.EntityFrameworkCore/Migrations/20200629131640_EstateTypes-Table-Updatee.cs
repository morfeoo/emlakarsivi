using Microsoft.EntityFrameworkCore.Migrations;

namespace RemDijital.EmlakTakip.Migrations
{
    public partial class EstateTypesTableUpdatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EstateTypes");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "EstateTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "EstateTypes");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "EstateTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
