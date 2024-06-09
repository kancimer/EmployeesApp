using EmployeesApp.Models.Domain;

namespace EmployeesApp.Models.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAsc = true,
            int pageNumber = 1, int pageSize = 20);

        //Task<Employee?> GetByIdAsync(Guid id);
        Task<Employee> CreateAsync(Employee employee);

        Task<Employee?> UpdateAsync(Guid id, Employee employee);

        Task<Employee?> DeleteAsync(Guid id);
    }
}
