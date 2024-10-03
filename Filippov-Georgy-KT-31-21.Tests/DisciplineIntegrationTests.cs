using Filippov_Georgy_KT_31_21.Context;
using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Models;
using Filippov_Georgy_KT_31_21.Services.Implementation;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Filippov_Georgy_KT_31_21.Tests {
    public class DisciplineIntegrationTests {
        private readonly DbContextOptions<StudyDbContext> _contextOptions;

        public DisciplineIntegrationTests() {
            _contextOptions = new DbContextOptionsBuilder<StudyDbContext>()
                .UseInMemoryDatabase("temp_test_db")
                .Options;
        }

        [Fact]
        public async Task GetDisciplinesByTeacherId_2_TwoObjects() {
            var contextFactory = new PooledDbContextFactory<StudyDbContext>(_contextOptions);
            using (var context = await contextFactory.CreateDbContextAsync()) {
                var teachers = new List<Teacher> {
                    new Teacher
                    {
                        Id = 1,
                        SecondName = "Михайлов",
                        FirstName = "Игорь",
                        LastName = "Александрович",
                        Birthdate = new DateTime(1977, 8, 14),
                        EmploymentDate = new DateTime(2008, 9, 1),
                        Email = "mikhailov.igor@university.com",
                        Phone = "+7-900-666-7788",
                        DegreeId = 1,  // Кандидат наук
                        PostId = 3  // Доцент
                    },
                    new Teacher
                    {
                        Id = 2,
                        SecondName = "Ковалева",
                        FirstName = "Анна",
                        LastName = "Ивановна",
                        Birthdate = new DateTime(1983, 2, 3),
                        EmploymentDate = new DateTime(2012, 9, 1),
                        Email = "kovaleva.anna@university.com",
                        Phone = "+7-900-888-9900",
                        DegreeId = null,  // Ученая степень отсутствует
                        PostId = 2  // Старший преподаватель
                    }
                };
                await context.Teachers.AddRangeAsync(teachers);

                var department = new Department {
                    Id = 1,
                    Name = "Кафедра математики",
                    HeadId = 1  // Руководитель: Иванов Алексей Петрович (Teacher с Id = 1)
                };
                await context.Departments.AddAsync(department);

                var disciplines = new List<Discipline> {
                    new Discipline
                    {
                        Id = 1,
                        Name = "Дифференциальные уравнения",
                        DepartmentId = 1  // Кафедра математики
                    },
                    new Discipline
                    {
                        Id = 2,
                        Name = "Линейная алгебра",
                        DepartmentId = 1  // Кафедра математики
                    },
                    new Discipline
                    {
                        Id = 3,
                        Name = "Теория вероятностей",
                        DepartmentId = 1  // Кафедра математики
                    },
                    new Discipline
                    {
                        Id = 4,
                        Name = "Математическая логика",
                        DepartmentId = 1  // Кафедра математики
                    },
                    new Discipline
                    {
                        Id = 5,
                        Name = "Численные методы",
                        DepartmentId = 1  // Кафедра математики
                    }
                };
                await context.Disciplines.AddRangeAsync(disciplines);

                var workloads = new List<Workload> {
                    new Workload
                    {
                        Id = 1,
                        StudyHoursCount = 80,
                        TeacherId = 1,  // Игорь Александрович Михайлов
                        DisciplineId = 1  // Дифференциальные уравнения
                    },
                    new Workload
                    {
                        Id = 2,
                        StudyHoursCount = 70,
                        TeacherId = 1,  // Игорь Александрович Михайлов
                        DisciplineId = 2  // Линейная алгебра
                    },
                    new Workload
                    {
                        Id = 3,
                        StudyHoursCount = 90,
                        TeacherId = 2,  // Анна Ивановна Ковалева
                        DisciplineId = 3  // Теория вероятностей
                    },
                    new Workload
                    {
                        Id = 4,
                        StudyHoursCount = 75,
                        TeacherId = 2,  // Анна Ивановна Ковалева
                        DisciplineId = 4  // Математическая логика
                    },
                    new Workload
                    {
                        Id = 5,
                        StudyHoursCount = 100,
                        TeacherId = 1,  // Игорь Александрович Михайлов
                        DisciplineId = 5  // Численные методы
                    }
                };
                await context.Workloads.AddRangeAsync(workloads);
                await context.SaveChangesAsync();
            }

            var service = new DisciplineService(contextFactory);

            var filter = new DisciplineFilterModel() {
                TeacherId = 2
            };

            var result = await service.GetAsync(filter, CancellationToken.None);

            Assert.Equal(2, result.Count());
        }
    }
}
