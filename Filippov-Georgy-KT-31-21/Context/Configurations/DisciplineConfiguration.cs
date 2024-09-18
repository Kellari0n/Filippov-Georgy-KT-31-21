using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline> {
        public void Configure(EntityTypeBuilder<Discipline> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Discipline {
                    Id = 1,
                    Name = "Математический анализ",
                    DepartmentId = 1,  // Кафедра математики
                },
                new Discipline {
                    Id = 2,
                    Name = "Теоретическая механика",
                    DepartmentId = 2,  // Кафедра физики
                },
                new Discipline {
                    Id = 3,
                    Name = "Программирование",
                    DepartmentId = 3,  // Кафедра информатики
                },
                new Discipline {
                    Id = 4,
                    Name = "История философии",
                    DepartmentId = 4,  // Кафедра философии
                }
            );
        }
    }
}
