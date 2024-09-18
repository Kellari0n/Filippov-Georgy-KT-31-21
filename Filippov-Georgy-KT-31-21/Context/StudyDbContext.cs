using Filippov_Georgy_KT_31_21.Context.Configurations;
using Filippov_Georgy_KT_31_21.Entities;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.Context {
    public class StudyDbContext : DbContext {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Workload> Workloads { get; set; }

        public StudyDbContext(DbContextOptions<StudyDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());


        }
    }
}
