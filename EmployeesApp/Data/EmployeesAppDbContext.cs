using EmployeesApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Data
{
    public class EmployeesAppDbContext:DbContext
    {
        public EmployeesAppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var employees = new List<Employee>
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Ivan",
                Surname = "Horvat",
                EmployeeImageUrl = "https://cdn10.picryl.com/photo/2014/09/25/jp-henderson-staff-photo-with-american-flag-in-background-4ef34f-1024.jpg",
                Gender = "M",
                DateOfBirth = new DateTime(1990, 1, 1),
                StartDateOfEmployment = new DateTime(2020, 1, 1),
                IsContractPermanent = true,
                ContractDuration = new DateTime(2025, 1, 1),
                Department = "IT",
                AnnualLeaveDays = 15,
                DaysOff = 5,
                DaysOfPaidLeave = 10
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Jana",
                Surname = "Janić",
                EmployeeImageUrl = "https://i.stack.imgur.com/Dm7uG.jpg",
                Gender = "F",
                DateOfBirth = new DateTime(1985, 5, 15),
                StartDateOfEmployment = new DateTime(2019, 3, 10),
                IsContractPermanent = false,
                ContractDuration = new DateTime(2024, 3, 10),
                Department = "HR",
                AnnualLeaveDays = 20,
                DaysOff = 3,
                DaysOfPaidLeave = 15
            },
            // Add more employees as needed
        };

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
