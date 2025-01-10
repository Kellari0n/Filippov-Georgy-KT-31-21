using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.WorkloadService;

public class WorkloadDbContext : DbContext {
    public DbSet<Workload> Workloads { get; set; }

    public WorkloadDbContext(DbContextOptions<WorkloadDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
    }
}