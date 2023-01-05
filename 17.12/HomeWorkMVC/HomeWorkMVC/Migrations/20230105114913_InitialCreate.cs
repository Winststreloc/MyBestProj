using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWorkMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportSpecialists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportSpecialists_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SupportRequestStatus = table.Column<string>(nullable: true),
                    SupportSpecialistId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_SupportSpecialists_SupportSpecialistId",
                        column: x => x.SupportSpecialistId,
                        principalTable: "SupportSpecialists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_SupportSpecialistId",
                table: "SupportRequests",
                column: "SupportSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSpecialists_DepartmentId",
                table: "SupportSpecialists",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "SupportSpecialists");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
