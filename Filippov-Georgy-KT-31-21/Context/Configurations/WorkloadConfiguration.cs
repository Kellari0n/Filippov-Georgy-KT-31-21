using Filippov_Georgy_KT_31_21.Context.Helpers;
using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload> {
        private const string _tableName = "cd_workload";
        public void Configure(EntityTypeBuilder<Workload> builder) {
            builder
                .HasKey(e => e.Id)
                .HasName($"pk_{_tableName}_workload_id");

            builder.Property(e => e.Id)
                .HasColumnName("workload_id")
                .HasColumnType(ColumnType.Int)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.StudyHoursCount)
                .HasColumnName("n_study_hours_count")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(e => e.TeacherId)
                .HasColumnName("f_teacher_id")
                .HasColumnType(ColumnType.Int);

            builder.Property(e => e.DisciplineId)
                .HasColumnName("f_discipline_id")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(_tableName)
                .HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId)
                .HasConstraintName("fk_f_teacher_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(_tableName)
                .HasOne(e => e.Discipline)
                .WithMany()
                .HasForeignKey(e => e.DisciplineId)
                .HasConstraintName("fk_f_discipline_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(_tableName)
                .HasIndex(e => e.TeacherId, $"idx_{_tableName}_fk_f_teacher_id");

            builder.ToTable(_tableName)
                .HasIndex(e => e.DisciplineId, $"idx_{_tableName}_fk_f_discipline_id");

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
