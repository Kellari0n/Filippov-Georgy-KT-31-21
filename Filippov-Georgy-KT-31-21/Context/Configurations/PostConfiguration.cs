using Filippov_Georgy_KT_31_21.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class PostConfiguration : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.Name)
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
}
