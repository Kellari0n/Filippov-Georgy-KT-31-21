using Filippov_Georgy_KT_31_21.Context.Helpers;
using Filippov_Georgy_KT_31_21.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher> {
        private const string _tableName = "cd_teachers";
        public void Configure(EntityTypeBuilder<Teacher> builder) {
            builder.HasKey(e => e.Id)
                .HasName($"pk_{_tableName}_teacher_id");

            builder.Property(e => e.Id)
                .HasColumnName("teacher_id")
                .HasColumnType(ColumnType.Int)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.SecondName)
                .HasColumnName("c_second_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasColumnName("c_first_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("c_last_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("c_email")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasColumnName("c_phone")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(15);

            builder.Property(e => e.Birthdate)
                .HasColumnName("d_birthdate")
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();

            builder.Property(e => e.EmploymentDate)
                .HasColumnName("d_employment_date")
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();

            builder.Property(e => e.PostId)
                .HasColumnName("f_post_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(e => e.DegreeId)
                .HasColumnName("f_degree_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired(false);

            builder.ToTable(_tableName)
                .HasOne(e => e.Post)
                .WithMany()
                .HasForeignKey(e => e.PostId)
                .HasConstraintName("fk_f_post_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(_tableName)
                .HasOne(e => e.Degree)
                .WithMany()
                .HasForeignKey(e => e.DegreeId)
                .HasConstraintName("fk_f_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(_tableName)
                .HasIndex(e => e.PostId, $"idx_{_tableName}_fk_f_post_id");

            builder.ToTable(_tableName)
                .HasIndex(e => e.DegreeId, $"idx_{_tableName}_fk_f_degree_id");

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
