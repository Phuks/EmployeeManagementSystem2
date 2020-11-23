using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class AddedPeriodAttributeToEmployeeWageRateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "EmployeeWageRates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeTypeDetails",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "EmployeeTypeDetailVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationField = table.Column<string>(nullable: false),
                    Education = table.Column<int>(nullable: false),
                    BusinessTravel = table.Column<string>(nullable: false),
                    DistanceFromHome = table.Column<int>(nullable: false),
                    JobRole = table.Column<string>(nullable: false),
                    JobInvolvement = table.Column<int>(nullable: false),
                    JobLevel = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypeDetailVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTypeDetailVM");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "EmployeeWageRates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeTypeDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
