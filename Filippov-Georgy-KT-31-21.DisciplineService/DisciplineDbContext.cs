using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

using Filippov_Georgy_KT_31_21.Context.Configurations;

using Microsoft.EntityFrameworkCore;

namespace DisciplineService;

public class DisciplineDbContext : DbContext {
    public DbSet<Discipline> Disciplines { get; set; }

    public DisciplineDbContext(DbContextOptions<DisciplineDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
    }
}