using System.ComponentModel.DataAnnotations;

namespace PerformanceManagementSystem.Api.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string JobTitle { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public DateTime DateJoined { get; set; }

    public bool IsActive { get; set; } = true;
}