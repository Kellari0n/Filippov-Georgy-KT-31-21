﻿using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

using Filippov_Georgy_KT_31_21.Services.Shared.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline> {
    private const string _tableName = "cd_discipline";
    public void Configure(EntityTypeBuilder<Discipline> builder) {
        builder.ToTable(_tableName)
            .HasKey(e => e.Id)
            .HasName($"pk_{_tableName}_discipline_id");

        builder.Property(e => e.Id)
            .HasColumnName("discipline_id")
            .HasColumnType(MsSqlColumnType.Int)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("c_name")
            .HasColumnType(MsSqlColumnType.String)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.DepartmentId)
            .HasColumnName("f_department_id")
            .HasColumnType(MsSqlColumnType.Int);

        builder.HasIndex(e => e.DepartmentId, $"idx_{_tableName}_fk_f_department_id");

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