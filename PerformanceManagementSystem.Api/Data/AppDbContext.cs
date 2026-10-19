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

    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
    .HasOne(employee => employee.Department)
    .WithMany(department => department.Employees)
    .HasForeignKey(employee => employee.DepartmentId)
    .IsRequired()
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasIndex(employee => employee.Email)
            .IsUnique();
    }
}