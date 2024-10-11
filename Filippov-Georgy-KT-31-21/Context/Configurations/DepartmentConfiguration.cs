using Filippov_Georgy_KT_31_21.Context.Helpers;
using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department> {
        private const string _tableName = "cs_department";
        public void Configure(EntityTypeBuilder<Department> builder) {
            builder.HasKey(e => e.Id)
                .HasName($"pk_{_tableName}_department_id");

            builder.Property(e => e.Id)
                .HasColumnName($"degree_id")
                .HasColumnType(ColumnType.Int)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName($"c_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.HeadId)
                .HasColumnName($"f_head_id")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(_tableName)
                .HasOne(e => e.Head)
                .WithOne()
                .HasForeignKey<Department>(e => e.HeadId)
                .HasConstraintName($"fk_f_head_id")
                .OnDelete(DeleteBehavior.Cascade);

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
