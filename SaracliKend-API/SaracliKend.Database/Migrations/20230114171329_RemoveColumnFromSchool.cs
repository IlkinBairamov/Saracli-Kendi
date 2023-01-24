using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaracliKend.Database.Migrations
{
    public partial class RemoveColumnFromSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Schools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Schools",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
