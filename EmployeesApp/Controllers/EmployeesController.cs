using AutoMapper;
using EmployeesApp.Data;
using EmployeesApp.Models.Domain;
using EmployeesApp.Models.DTOs;
using EmployeesApp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace EmployeesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesAppDbContext dbContext;
        private readonly IEmployeesRepository employeesRepository;
        private readonly IMapper mapper;

        public EmployeesController(EmployeesAppDbContext dbContext,
            IEmployeesRepository employeesRepository
            ,IMapper mapper
            )
        {
            
            this.dbContext = dbContext;
            this.employeesRepository = employeesRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAsc,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20) {

            var employeesDomain=await employeesRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAsc ?? true, pageNumber, pageSize);
            var employeesDto=mapper.Map<List<EmployeeDto>>(employeesDomain);

            return Ok(employeesDto);
            //api/employees
        }

        /*[HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employeeDomain = await employeesRepository.GetByIdAsync(id);
            if(employeeDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EmployeeDto>(employeeDomain));
        }
        */
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeDomainModel=mapper.Map<Employee>(updateEmployeeDto);
            employeeDomainModel = await employeesRepository.UpdateAsync(id, employeeDomainModel);
            if(employeeDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EmployeeDto> (employeeDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto addEmployeeDto)
        {
            var employeeDomainModel = mapper.Map<Employee>(addEmployeeDto);
            employeeDomainModel = await employeesRepository.CreateAsync(employeeDomainModel);
            var employeeDto=mapper.Map<EmployeeDto>(employeeDomainModel);
            //return CreatedAtAction(nameof(GetById), new {id= employeeDto .Id}, employeeDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employeeDomainModel= await employeesRepository.DeleteAsync(id);
            if (employeeDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }
    }
}
