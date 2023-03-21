using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaracliKend.Database.Migrations
{
    public partial class RemoveImageColumnFromLegend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Legends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Legends",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
