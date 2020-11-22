using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem2.Migrations
{
    public partial class InquiryInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCount = table.Column<int>(nullable: false),
                    PerformanceRating = table.Column<int>(nullable: false),
                    WorkLifeBalance = table.Column<int>(nullable: false),
                    EnviromentSatisfaction = table.Column<int>(nullable: false),
                    RelationshipSatisfaction = table.Column<int>(nullable: false),
                    JobSatisfaction = table.Column<int>(nullable: false),
                    StockLevelOption = table.Column<int>(nullable: false),
                    RequestingEmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_AspNetUsers_RequestingEmployeeId",
                        column: x => x.RequestingEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_RequestingEmployeeId",
                table: "Inquiries",
                column: "RequestingEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");
        }
    }
}
