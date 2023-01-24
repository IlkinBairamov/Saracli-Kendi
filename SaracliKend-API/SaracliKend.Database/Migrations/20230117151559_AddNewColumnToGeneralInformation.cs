using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaracliKend.Database.Migrations
{
    public partial class AddNewColumnToGeneralInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "GeneralInformation",
                newName: "DescriptionSecondPart");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFirstPart",
                table: "GeneralInformation",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionFirstPart",
                table: "GeneralInformation");

            migrationBuilder.RenameColumn(
                name: "DescriptionSecondPart",
                table: "GeneralInformation",
                newName: "Description");
        }
    }
}
