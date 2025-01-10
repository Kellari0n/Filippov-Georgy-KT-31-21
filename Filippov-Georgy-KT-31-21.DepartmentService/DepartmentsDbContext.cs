using Filippov_Georgy_KT_31_21.DepartmentService.Entity;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService;

public sealed class DepartmentsDbContext : DbContext {
    public DbSet<Department> Departments { get; set; }

    public DepartmentsDbContext() {
        Database.EnsureCreated();
    }

    public DepartmentsDbContext(DbContextOptions<DepartmentsDbContext> options) : base(options) { 
        Database.EnsureCreated();
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
    }
}