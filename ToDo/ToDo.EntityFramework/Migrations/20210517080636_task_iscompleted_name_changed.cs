using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.EntityFramework.Migrations
{
    public partial class task_iscompleted_name_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCompleted",
                table: "Tasks",
                newName: "IsCompleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Tasks",
                newName: "isCompleted");
        }
    }
}
