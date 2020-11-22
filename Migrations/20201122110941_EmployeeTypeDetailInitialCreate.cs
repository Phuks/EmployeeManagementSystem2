using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class EmployeeTypeDetailInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTypeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationField = table.Column<string>(nullable: false),
                    Education = table.Column<int>(nullable: false),
                    BusinessTravel = table.Column<string>(nullable: true),
                    DistanceFromHome = table.Column<int>(nullable: false),
                    JobRole = table.Column<string>(nullable: true),
                    JobInvolvement = table.Column<int>(nullable: false),
                    JobLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypeDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTypeDetails");
        }
    }
}
