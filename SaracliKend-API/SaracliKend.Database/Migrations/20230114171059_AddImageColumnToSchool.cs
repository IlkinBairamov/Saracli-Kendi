using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaracliKend.Database.Migrations
{
    public partial class AddImageColumnToSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Schools",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Schools");
        }
    }
}
