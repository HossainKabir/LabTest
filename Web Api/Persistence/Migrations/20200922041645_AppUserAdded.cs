using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AppUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTasks_UserTaskId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTaskId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTaskId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AppUserId",
                table: "UserTasks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_AppUserId",
                table: "UserTasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_AppUserId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_AppUserId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserTasks");

            migrationBuilder.AddColumn<int>(
                name: "UserTaskId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTaskId",
                table: "AspNetUsers",
                column: "UserTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTasks_UserTaskId",
                table: "AspNetUsers",
                column: "UserTaskId",
                principalTable: "UserTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
