using Filippov_Georgy_KT_31_21.Services.Shared.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.DepartmentService.Entity;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department> {
    private const string _tableName = "cs_department";
    public void Configure(EntityTypeBuilder<Department> builder) {
        builder.ToTable(_tableName)
            .HasKey(e => e.Id)
            .HasName($"pk_{_tableName}_department_id");

        builder.Property(e => e.Id)
            .HasColumnName($"department_id")
            .HasColumnType(SqliteColumnType.Integer)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName($"c_name")
            .HasColumnType(SqliteColumnType.Text)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.HeadId)
            .HasColumnName($"f_head_id")
            .HasColumnType(SqliteColumnType.Integer);

        builder.HasData(
            new Department {
                Id = 1,
                Name = "Кафедра математики",
                HeadId = 1,  // Руководитель: Иванов Алексей Петрович (Teacher с Id = 1)
                FoundationDate = new DateTime(1900, 1, 1),
            },
            new Department {
                Id = 2,
                Name = "Кафедра физики",
                HeadId = 2,  // Руководитель: Смирнова Елена Васильевна (Teacher с Id = 2)
                FoundationDate = new DateTime(1900, 1, 1),
            },
            new Department {
                Id = 3,
                Name = "Кафедра информатики",
                HeadId = 3,  // Руководитель: Кузнецов Дмитрий Иванович (Teacher с Id = 3)
                FoundationDate = new DateTime(1950, 1, 1),
            },
            new Department {
                Id = 4,
                Name = "Кафедра философии",
                HeadId = 4,  // Руководитель: Петрова Мария Андреевна (Teacher с Id = 4)
                FoundationDate = new DateTime(1900, 1, 1),
            }
        );
    }
}