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

            builder.Property(e => e.Email)
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasMaxLength(15);

            builder.Property(e => e.Birthdate)
                .IsRequired();

            builder.Property(e => e.EmploymentDate)
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
                    Birthdate = new DateTime(1980, 5, 15),
                    EmploymentDate = new DateTime(2010, 9, 1),
                    Email = "ivanov.aleksey@university.com",
                    Phone = "+7-900-123-4567",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 3  // Доцент
                },
                new Teacher {
                    Id = 2,
                    SecondName = "Смирнова",
                    FirstName = "Елена",
                    LastName = "Васильевна",
                    Birthdate = new DateTime(1975, 12, 20),
                    EmploymentDate = new DateTime(2005, 9, 1),
                    Email = "smirnova.elena@university.com",
                    Phone = "+7-900-987-6543",
                    DegreeId = 2,  // Доктор наук
                    PostId = 4  // Профессор
                },
                new Teacher {
                    Id = 3,
                    SecondName = "Кузнецов",
                    FirstName = "Дмитрий",
                    LastName = "Иванович",
                    Birthdate = new DateTime(1985, 3, 10),
                    EmploymentDate = new DateTime(2015, 9, 1),
                    Email = "kuznetsov.dmitriy@university.com",
                    Phone = "+7-900-222-3344",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 2  // Старший преподаватель
                },
                new Teacher {
                    Id = 4,
                    SecondName = "Петрова",
                    FirstName = "Мария",
                    LastName = "Андреевна",
                    Birthdate = new DateTime(1990, 7, 25),
                    EmploymentDate = new DateTime(2020, 9, 1),
                    Email = "petrova.maria@university.com",
                    Phone = "+7-900-555-6677",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 1  // Преподаватель
                },
                new Teacher {
                    Id = 5,
                    SecondName = "Воробьёв",
                    FirstName = "Сергей",
                    LastName = "Николаевич",
                    Birthdate = new DateTime(1982, 11, 5),
                    EmploymentDate = new DateTime(2012, 9, 1),
                    Email = "vorobyev.sergey@university.com",
                    Phone = "+7-900-333-4455",
                    DegreeId = 1,  // Кандидат наук
                    PostId = 2  // Старший преподаватель
                },
                new Teacher {
                    Id = 6,
                    SecondName = "Фёдорова",
                    FirstName = "Ольга",
                    LastName = "Сергеевна",
                    Birthdate = new DateTime(1988, 4, 17),
                    EmploymentDate = new DateTime(2018, 9, 1),
                    Email = "fedorova.olga@university.com",
                    Phone = "+7-900-111-2233",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 1  // Преподаватель
                },
                new Teacher {
                    Id = 7,
                    SecondName = "Сидоров",
                    FirstName = "Андрей",
                    LastName = "Владимирович",
                    Birthdate = new DateTime(1970, 9, 9),
                    EmploymentDate = new DateTime(2000, 9, 1),
                    Email = "sidorov.andrey@university.com",
                    Phone = "+7-900-444-5566",
                    DegreeId = 2,  // Доктор наук
                    PostId = 4  // Профессор
                },
                new Teacher {
                    Id = 8,
                    SecondName = "Николаева",
                    FirstName = "Людмила",
                    LastName = "Александровна",
                    Birthdate = new DateTime(1995, 6, 30),
                    EmploymentDate = new DateTime(2021, 9, 1),
                    Email = "nikolaeva.lyudmila@university.com",
                    Phone = "+7-900-777-8899",
                    DegreeId = null,  // Ученая степень отсутствует
                    PostId = 5  // Ассистент
                }
            );
        }
    }
}
