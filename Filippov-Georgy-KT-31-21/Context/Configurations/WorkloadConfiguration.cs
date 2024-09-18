using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload> {
        public void Configure(EntityTypeBuilder<Workload> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.StudyHoursCount)
                .IsRequired();

            builder.HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Discipline)
                .WithMany()
                .HasForeignKey(e => e.DisciplineId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Workload {
                    Id = 1,
                    StudyHoursCount = 120,
                    TeacherId = 1,  // Иванов Алексей Петрович (Teacher с Id = 1)
                    DisciplineId = 1  // Математический анализ (Discipline с Id = 1)
                },
                new Workload {
                    Id = 2,
                    StudyHoursCount = 90,
                    TeacherId = 2,  // Смирнова Елена Васильевна (Teacher с Id = 2)
                    DisciplineId = 2  // Теоретическая механика (Discipline с Id = 2)
                },
                new Workload {
                    Id = 3,
                    StudyHoursCount = 150,
                    TeacherId = 3,  // Кузнецов Дмитрий Иванович (Teacher с Id = 3)
                    DisciplineId = 3  // Программирование (Discipline с Id = 3)
                },
                new Workload {
                    Id = 4,
                    StudyHoursCount = 60,
                    TeacherId = 4,  // Петрова Мария Андреевна (Teacher с Id = 4)
                    DisciplineId = 4  // История философии (Discipline с Id = 4)
                }
            );
        }
    }
}
