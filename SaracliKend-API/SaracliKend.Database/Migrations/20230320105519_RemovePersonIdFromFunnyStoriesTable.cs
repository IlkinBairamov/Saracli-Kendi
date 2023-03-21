using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaracliKend.Database.Migrations
{
    public partial class RemovePersonIdFromFunnyStoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FunnyStories_People_PersonId",
                table: "FunnyStories");

            migrationBuilder.DropIndex(
                name: "IX_FunnyStories_PersonId",
                table: "FunnyStories");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "FunnyStories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "FunnyStories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FunnyStories_PersonId",
                table: "FunnyStories",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FunnyStories_People_PersonId",
                table: "FunnyStories",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
