using EmployeesApp.Data;
using EmployeesApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Models.Repositories
{
    public class SQLEmployeeRepository :IEmployeesRepository
    {
        private readonly EmployeesAppDbContext dbContext;

        public SQLEmployeeRepository(EmployeesAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteAsync(Guid id)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }
            dbContext.Employees.Remove(existingEmployee);
            await dbContext.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<List<Employee>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAsc = true,
            int pageNumber = 1, int pageSize = 20)
        {
            var employees = dbContext.Employees.AsQueryable();
            //filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Department", StringComparison.OrdinalIgnoreCase))
                {
                    employees = employees.Where(x => x.Department.Contains(filterQuery));
                }

            }
            //sorting:

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Surname", StringComparison.OrdinalIgnoreCase))
                {
                    employees = isAsc ? employees.OrderBy(x => x.Surname) : employees.OrderByDescending(x => x.Surname);
                }
                if (sortBy.Equals("StartDateOfEmployment", StringComparison.OrdinalIgnoreCase))
                {
                    employees = isAsc ? employees.OrderBy(x => x.StartDateOfEmployment) : employees.OrderByDescending(x => x.StartDateOfEmployment);
                }
            }

            //pagination:
            var skipResults = (pageNumber - 1) * pageSize;


            return await employees.Skip(skipResults).Take(pageSize).ToListAsync();
            // return await dbContext.Employees.ToListAsync();
        }

        /*public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x=>x.Id== id);
           
        }*/

        public async Task<Employee?> UpdateAsync(Guid id, Employee employee)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }
            
            existingEmployee.Name = employee.Name;
            existingEmployee.Surname=employee.Surname;
            existingEmployee.DaysOff=employee.DaysOff;
            existingEmployee.EmployeeImageUrl = employee.EmployeeImageUrl;
            existingEmployee.DaysOfPaidLeave=employee.DaysOfPaidLeave;
            existingEmployee.DateOfBirth=employee.DateOfBirth;
            existingEmployee.ContractDuration=employee.ContractDuration;
            existingEmployee.Gender=employee.Gender;
            existingEmployee.IsContractPermanent = employee.IsContractPermanent;
            existingEmployee.AnnualLeaveDays=employee.AnnualLeaveDays;
            existingEmployee.Department=employee.Department;
            existingEmployee.StartDateOfEmployment=employee.StartDateOfEmployment;
            existingEmployee.DaysOfPaidLeave=employee.DaysOfPaidLeave;

            await dbContext.SaveChangesAsync();
            return existingEmployee;
        }
    }
}
