using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class EmployeeHistoryInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCompaniesWorked = table.Column<int>(nullable: false),
                    YearsAtCompany = table.Column<int>(nullable: false),
                    YearsInCurrentRole = table.Column<int>(nullable: false),
                    YearsSinceLastPromotion = table.Column<int>(nullable: false),
                    YearsWithCurrManager = table.Column<int>(nullable: false),
                    TotalWorkingYears = table.Column<int>(nullable: false),
                    TrainingTimesLastYear = table.Column<int>(nullable: false),
                    RequestingEmployeeId = table.Column<string>(nullable: true),
                    EmployeeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeHistories_EmployeeTypeDetails_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeHistories_AspNetUsers_RequestingEmployeeId",
                        column: x => x.RequestingEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_EmployeeTypeId",
                table: "EmployeeHistories",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_RequestingEmployeeId",
                table: "EmployeeHistories",
                column: "RequestingEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHistories");
        }
    }
}
