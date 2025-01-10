﻿using Filippov_Georgy_KT_31_21.Services.Shared.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.TeacherService.Entities.Configurations;

internal class DegreeConfiguration : IEntityTypeConfiguration<Degree> {
    private const string _tableName = "cs_degree";
    public void Configure(EntityTypeBuilder<Degree> builder) {
        builder.ToTable(_tableName)
            .HasKey(e => e.Id)
            .HasName($"pk_{_tableName}_degree_id");

        builder.Property(e => e.Id)
            .HasColumnName("degree_id")
            .HasColumnType(PostgresColumnType.Int)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("c_name")
            .HasColumnType(PostgresColumnType.String)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new Degree { Id = 1, Name = "Кандидат наук" },
            new Degree { Id = 2, Name = "Доктор наук" }
        );
    }
}