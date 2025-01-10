using Filippov_Georgy_KT_31_21.Services.Shared.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.TeacherService.Entities.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post> {
    private const string _tableName = "cs_post";
    public void Configure(EntityTypeBuilder<Post> builder) {
        builder.ToTable(_tableName)
            .HasKey(e => e.Id)
            .HasName($"pk_{_tableName}_post_id");

        builder.Property(e => e.Id)
            .HasColumnName("post_id")
            .HasColumnType(PostgresColumnType.Int)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasColumnName("c_name")
            .HasColumnType(PostgresColumnType.String)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new Post { Id = 1, Name = "Преподаватель" },
            new Post { Id = 2, Name = "Старший преподаватель" },
            new Post { Id = 3, Name = "Доцент" },
            new Post { Id = 4, Name = "Профессор" },
            new Post { Id = 5, Name = "Ассистент" },
            new Post { Id = 6, Name = "Заведующий кафедрой" },
            new Post { Id = 7, Name = "Научный сотрудник" },
            new Post { Id = 8, Name = "Главный научный сотрудник" },
            new Post { Id = 9, Name = "Декан" },
            new Post { Id = 10, Name = "Проректор" }
        );
    }
}