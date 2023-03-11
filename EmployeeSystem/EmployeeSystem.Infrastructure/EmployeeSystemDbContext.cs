using EmployeeSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeSystem.Infrastructure.Models.Task;

namespace EmployeeSystem.Infrastructure;

public class EmployeeSystemDbContext : DbContext
{
    public EmployeeSystemDbContext(){ }

    public EmployeeSystemDbContext(DbContextOptions<EmployeeSystemDbContext> options)
            : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=EmployeeSystem;Integrated Security=true;TrustServerCertificate=True");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(t => t.Tasks)
            .WithOne(e => e.Assignee)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Task>()
           .HasOne(e => e.Assignee)
           .WithMany(t => t.Tasks)
           .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}
