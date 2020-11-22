using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class AdjustedEmployeeTypeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeTypeDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeTypeDetails");
        }
    }
}
