using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialEmployeesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsContractPermanent = table.Column<bool>(type: "bit", nullable: false),
                    ContractDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualLeaveDays = table.Column<int>(type: "int", nullable: true),
                    DaysOff = table.Column<int>(type: "int", nullable: true),
                    DaysOfPaidLeave = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
