using PerformanceManagementSystem.Api.DTOs;

namespace PerformanceManagementSystem.Api.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();

    Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id);

    Task<EmployeeResponseDto?> CreateEmployeeAsync(CreateEmployeeDto dto);
}