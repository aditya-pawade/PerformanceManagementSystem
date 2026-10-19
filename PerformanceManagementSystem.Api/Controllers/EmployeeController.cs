
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Api.DTOs;
using PerformanceManagementSystem.Api.Services.Interfaces;

namespace PerformanceManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee is null)
        {
            return NotFound(new { message = "Employee not found" });
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeResponseDto>> CreateEmployee(
        CreateEmployeeDto dto)
    {
        var employee = await _employeeService.CreateEmployeeAsync(dto);

        if (employee is null)
        {
            return BadRequest(new
            {
                message = $"Department with ID {dto.DepartmentId} does not exist."
            });
        }

        return CreatedAtAction(
            nameof(GetEmployeeById),
            new { id = employee.Id },
            employee);
    }
}
