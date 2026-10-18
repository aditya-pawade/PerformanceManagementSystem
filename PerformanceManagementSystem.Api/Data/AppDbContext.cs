using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Api.Models;

namespace PerformanceManagementSystem.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
}