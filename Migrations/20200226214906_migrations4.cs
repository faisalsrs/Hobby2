using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam3.Migrations
{
    public partial class migrations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Join_Hobbies_PostJOINHobbyId",
                table: "Join");

            migrationBuilder.DropIndex(
                name: "IX_Join_PostJOINHobbyId",
                table: "Join");

            migrationBuilder.DropColumn(
                name: "PostJOINHobbyId",
                table: "Join");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Join",
                newName: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Join_HobbyId",
                table: "Join",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Join_Hobbies_HobbyId",
                table: "Join",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Join_Hobbies_HobbyId",
                table: "Join");

            migrationBuilder.DropIndex(
                name: "IX_Join_HobbyId",
                table: "Join");

            migrationBuilder.RenameColumn(
                name: "HobbyId",
                table: "Join",
                newName: "EventId");

            migrationBuilder.AddColumn<int>(
                name: "PostJOINHobbyId",
                table: "Join",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Join_PostJOINHobbyId",
                table: "Join",
                column: "PostJOINHobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Join_Hobbies_PostJOINHobbyId",
                table: "Join",
                column: "PostJOINHobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
