using Filippov_Georgy_KT_31_21.TeacherService.DTOs;
using Filippov_Georgy_KT_31_21.TeacherService.Entities;
using Filippov_Georgy_KT_31_21.TeacherService.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.TeacherService;

public sealed class TeachersDbContext : DbContext {
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Degree> Degrees { get; set; }

    public TeachersDbContext() {
        Database.EnsureCreated();
    }

    public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options) {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new DegreeConfiguration());
    }
}