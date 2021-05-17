using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.EntityFramework.Migrations
{
    public partial class addedexplicitforeighkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AccountId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AccountId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AccountId",
                table: "Tasks",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AccountId",
                table: "Tasks",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
