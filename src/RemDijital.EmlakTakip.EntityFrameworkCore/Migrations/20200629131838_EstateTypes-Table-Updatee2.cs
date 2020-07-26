using Microsoft.EntityFrameworkCore.Migrations;

namespace RemDijital.EmlakTakip.Migrations
{
    public partial class EstateTypesTableUpdatee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EstateTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EstateTypes");
        }
    }
}
