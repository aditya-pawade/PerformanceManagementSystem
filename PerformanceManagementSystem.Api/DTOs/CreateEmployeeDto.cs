using System.ComponentModel.DataAnnotations;

namespace PerformanceManagementSystem.Api.DTOs;

public class CreateEmployeeDto
{
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

	[Range(1, int.MaxValue)]
	public int DepartmentId { get; set; }

	public DateTime DateJoined { get; set; } = DateTime.UtcNow;
}