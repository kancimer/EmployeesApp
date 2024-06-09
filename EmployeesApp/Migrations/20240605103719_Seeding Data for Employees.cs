using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeesApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AnnualLeaveDays", "ContractDuration", "DateOfBirth", "DaysOfPaidLeave", "DaysOff", "Department", "EmployeeImageUrl", "Gender", "IsContractPermanent", "Name", "StartDateOfEmployment", "Surname" },
                values: new object[,]
                {
                    { new Guid("c6338ed5-4ea1-4ceb-9bd6-f7675817f046"), 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, "IT", "https://cdn10.picryl.com/photo/2014/09/25/jp-henderson-staff-photo-with-american-flag-in-background-4ef34f-1024.jpg", "M", true, "Ivan", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horvat" },
                    { new Guid("c828772b-96db-42ad-9fca-b62ae4f9720a"), 20, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, "HR", "https://i.stack.imgur.com/Dm7uG.jpg", "F", false, "Jana", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janić" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c6338ed5-4ea1-4ceb-9bd6-f7675817f046"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c828772b-96db-42ad-9fca-b62ae4f9720a"));

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
