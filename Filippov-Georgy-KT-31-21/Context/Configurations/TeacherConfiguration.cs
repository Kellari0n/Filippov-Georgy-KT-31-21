using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher> {
        public void Configure(EntityTypeBuilder<Teacher> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Post)
                .WithMany()
                .HasForeignKey(e => e.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Degree)
                .WithMany()
                .HasForeignKey(e => e.DegreeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Teacher {
                    Id = 1,
                    SecondName = "Иванов",
                    FirstName = "Алексей",
                    LastName = "Петрович",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 3,    // Доцент
                },
                new Teacher {
                    Id = 2,
                    SecondName = "Смирнова",
                    FirstName = "Елена",
                    LastName = "Васильевна",
                    DegreeId = 2,  // Доктор наук
                    PostId = 4,    // Профессор
                },
                new Teacher {
                    Id = 3,
                    SecondName = "Кузнецов",
                    FirstName = "Дмитрий",
                    LastName = "Иванович",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 2,    // Старший преподаватель
                },
                new Teacher {
                    Id = 4,
                    SecondName = "Петрова",
                    FirstName = "Мария",
                    LastName = "Андреевна",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 1,    // Преподаватель
                },
                new Teacher {
                    Id = 5,
                    SecondName = "Воробьёв",
                    FirstName = "Сергей",
                    LastName = "Николаевич",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 2,    // Старший преподаватель
                },
                new Teacher {
                    Id = 6,
                    SecondName = "Фёдорова",
                    FirstName = "Ольга",
                    LastName = "Сергеевна",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 1,    // Преподаватель
                },
                new Teacher {
                    Id = 7,
                    SecondName = "Сидоров",
                    FirstName = "Андрей",
                    LastName = "Владимирович",
                    DegreeId = 2,  // Доктор наук
                    PostId = 4,    // Профессор
                },
                new Teacher {
                    Id = 8,
                    SecondName = "Николаева",
                    FirstName = "Людмила",
                    LastName = "Александровна",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 5,    // Ассистент
                }
            );
        }
    }
}
