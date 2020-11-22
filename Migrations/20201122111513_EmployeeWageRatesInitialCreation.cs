using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class EmployeeWageRatesInitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeWageRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyIncome = table.Column<int>(nullable: false),
                    MonthlyRate = table.Column<int>(nullable: false),
                    DailyRate = table.Column<int>(nullable: false),
                    HourlyRate = table.Column<int>(nullable: false),
                    StandardHours = table.Column<int>(nullable: false),
                    Overtime = table.Column<string>(nullable: false),
                    PercentSalaryHike = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWageRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWageRates_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeWageRates_EmployeeTypeDetails_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWageRates_EmployeeId",
                table: "EmployeeWageRates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWageRates_EmployeeTypeId",
                table: "EmployeeWageRates",
                column: "EmployeeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWageRates");
        }
    }
}
