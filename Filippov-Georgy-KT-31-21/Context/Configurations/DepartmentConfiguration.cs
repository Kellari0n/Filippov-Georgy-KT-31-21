using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department> {
        public void Configure(EntityTypeBuilder<Department> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Head)
                .WithOne()
                .HasForeignKey<Department>(e => e.HeadId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Department {
                    Id = 1,
                    Name = "Кафедра математики",
                    HeadId = 1  // Руководитель: Иванов Алексей Петрович (Teacher с Id = 1)
                },
                new Department {
                    Id = 2,
                    Name = "Кафедра физики",
                    HeadId = 2  // Руководитель: Смирнова Елена Васильевна (Teacher с Id = 2)
                },
                new Department {
                    Id = 3,
                    Name = "Кафедра информатики",
                    HeadId = 3  // Руководитель: Кузнецов Дмитрий Иванович (Teacher с Id = 3)
                },
                new Department {
                    Id = 4,
                    Name = "Кафедра философии",
                    HeadId = 4  // Руководитель: Петрова Мария Андреевна (Teacher с Id = 4)
                }
            );
        }
    }
}
