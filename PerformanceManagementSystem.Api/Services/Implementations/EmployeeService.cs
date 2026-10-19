
using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Api.Data;
using PerformanceManagementSystem.Api.DTOs;
using PerformanceManagementSystem.Api.Models;
using PerformanceManagementSystem.Api.Services.Interfaces;

namespace PerformanceManagementSystem.Api.Services.Implementations;

public class EmployeeService : IEmployeeService
{
	private readonly AppDbContext _context;

	public EmployeeService(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync()
	{
		return await _context.Employees
			.AsNoTracking()
			.Select(employee => new EmployeeResponseDto
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Email = employee.Email,
				JobTitle = employee.JobTitle,
				DepartmentId = employee.DepartmentId,
				DateJoined = employee.DateJoined,
				IsActive = employee.IsActive
			})
			.ToListAsync();
	}

	public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
	{
		return await _context.Employees
			.AsNoTracking()
			.Where(employee => employee.Id == id)
			.Select(employee => new EmployeeResponseDto
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Email = employee.Email,
				JobTitle = employee.JobTitle,
				DepartmentId = employee.DepartmentId,
				DateJoined = employee.DateJoined,
				IsActive = employee.IsActive
			})
			.FirstOrDefaultAsync();
	}

    public async Task<EmployeeResponseDto?> CreateEmployeeAsync(
    CreateEmployeeDto dto)
    {
        var departmentExists = await _context.Departments
            .AnyAsync(department => department.Id == dto.DepartmentId);

        if (!departmentExists)
        {
            return null;
        }

        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            JobTitle = dto.JobTitle,
            DepartmentId = dto.DepartmentId,
            DateJoined = dto.DateJoined,
            IsActive = true
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            JobTitle = employee.JobTitle,
            DepartmentId = employee.DepartmentId,
            DateJoined = employee.DateJoined,
            IsActive = employee.IsActive
        };
    }
}
