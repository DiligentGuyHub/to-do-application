using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.EntityFramework.Migrations
{
    public partial class foreign_key_mistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Tasks_UserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tasks_UserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTask_Tasks_UserId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_SubTask_UserId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SubTask");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Files");

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_TaskId",
                table: "SubTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TaskId",
                table: "Images",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TaskId",
                table: "Files",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Tasks_TaskId",
                table: "Files",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tasks_TaskId",
                table: "Images",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTask_Tasks_TaskId",
                table: "SubTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Tasks_TaskId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tasks_TaskId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTask_Tasks_TaskId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_SubTask_TaskId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_Images_TaskId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Files_TaskId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SubTask",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_UserId",
                table: "SubTask",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Tasks_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tasks_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTask_Tasks_UserId",
                table: "SubTask",
                column: "UserId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
