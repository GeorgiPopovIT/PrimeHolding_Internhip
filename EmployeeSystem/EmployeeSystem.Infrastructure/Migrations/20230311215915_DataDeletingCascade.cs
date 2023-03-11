using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataDeletingCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AssigneeId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AssigneeId",
                table: "Tasks",
                column: "AssigneeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AssigneeId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AssigneeId",
                table: "Tasks",
                column: "AssigneeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
