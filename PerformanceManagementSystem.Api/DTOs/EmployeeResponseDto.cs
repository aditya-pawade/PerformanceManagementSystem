namespace PerformanceManagementSystem.Api.DTOs;

public class EmployeeResponseDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string JobTitle { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public DateTime DateJoined { get; set; }

    public bool IsActive { get; set; }
}