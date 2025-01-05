using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filippov_Georgy_KT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cs_degree",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cs_post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_post_post_id", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_second_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    c_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    c_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    d_birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    d_employment = table.Column<DateTime>(type: "datetime", nullable: false),
                    c_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    c_phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    f_degree_id = table.Column<int>(type: "int", nullable: true),
                    f_post_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teachers_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_degree_id",
                        column: x => x.f_degree_id,
                        principalTable: "cs_degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_post_id",
                        column: x => x.f_post_id,
                        principalTable: "cs_post",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cs_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    f_head_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_department_department_id", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_f_head_id",
                        column: x => x.f_head_id,
                        principalTable: "cd_teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    f_department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.f_department_id,
                        principalTable: "cs_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    workload_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    n_study_hours_count = table.Column<int>(type: "int", nullable: false),
                    f_teacher_id = table.Column<int>(type: "int", nullable: false),
                    f_discipline_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_workload_id", x => x.workload_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.f_teacher_id,
                        principalTable: "cd_teachers",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.InsertData(
                table: "cs_degree",
                columns: new[] { "degree_id", "c_name" },
                values: new object[,]
                {
                    { 1, "Кандидат наук" },
                    { 2, "Доктор наук" }
                });

            migrationBuilder.InsertData(
                table: "cs_post",
                columns: new[] { "post_id", "c_name" },
                values: new object[,]
                {
                    { 1, "Преподаватель" },
                    { 2, "Старший преподаватель" },
                    { 3, "Доцент" },
                    { 4, "Профессор" },
                    { 5, "Ассистент" },
                    { 6, "Заведующий кафедрой" },
                    { 7, "Научный сотрудник" },
                    { 8, "Главный научный сотрудник" },
                    { 9, "Декан" },
                    { 10, "Проректор" }
                });

            migrationBuilder.InsertData(
                table: "cd_teachers",
                columns: new[] { "teacher_id", "d_birthdate", "f_degree_id", "c_email", "d_employment", "c_first_name", "c_last_name", "c_phone", "f_post_id", "c_second_name" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ivanov.aleksey@university.com", new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", "Петрович", "+7-900-123-4567", 3, "Иванов" },
                    { 2, new DateTime(1975, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "smirnova.elena@university.com", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Елена", "Васильевна", "+7-900-987-6543", 4, "Смирнова" },
                    { 3, new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "kuznetsov.dmitriy@university.com", new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитрий", "Иванович", "+7-900-222-3344", 2, "Кузнецов" },
                    { 4, new DateTime(1990, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "petrova.maria@university.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мария", "Андреевна", "+7-900-555-6677", 1, "Петрова" },
                    { 5, new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "vorobyev.sergey@university.com", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", "Николаевич", "+7-900-333-4455", 2, "Воробьёв" },
                    { 6, new DateTime(1988, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fedorova.olga@university.com", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ольга", "Сергеевна", "+7-900-111-2233", 1, "Фёдорова" },
                    { 7, new DateTime(1970, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "sidorov.andrey@university.com", new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрей", "Владимирович", "+7-900-444-5566", 4, "Сидоров" },
                    { 8, new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nikolaeva.lyudmila@university.com", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Людмила", "Александровна", "+7-900-777-8899", 5, "Николаева" }
                });

            migrationBuilder.InsertData(
                table: "cs_department",
                columns: new[] { "department_id", "f_head_id", "c_name" },
                values: new object[,]
                {
                    { 1, 1, "Кафедра математики" },
                    { 2, 2, "Кафедра физики" },
                    { 3, 3, "Кафедра информатики" },
                    { 4, 4, "Кафедра философии" }
                });

            migrationBuilder.InsertData(
                table: "cd_discipline",
                columns: new[] { "discipline_id", "f_department_id", "c_name" },
                values: new object[,]
                {
                    { 1, 1, "Математический анализ" },
                    { 2, 2, "Теоретическая механика" },
                    { 3, 3, "Программирование" },
                    { 4, 4, "История философии" }
                });

            migrationBuilder.InsertData(
                table: "cd_workload",
                columns: new[] { "workload_id", "f_discipline_id", "n_study_hours_count", "f_teacher_id" },
                values: new object[,]
                {
                    { 1, 1, 120, 1 },
                    { 2, 2, 90, 2 },
                    { 3, 3, 150, 3 },
                    { 4, 4, 60, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_discipline_fk_f_department_id",
                table: "cd_discipline",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_degree_id",
                table: "cd_teachers",
                column: "f_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_post_id",
                table: "cd_teachers",
                column: "f_post_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_workload_fk_f_discipline_id",
                table: "cd_workload",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_workload_fk_f_teacher_id",
                table: "cd_workload",
                column: "f_teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_cs_department_f_head_id",
                table: "cs_department",
                column: "f_head_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_workload");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cs_department");

            migrationBuilder.DropTable(
                name: "cd_teachers");

            migrationBuilder.DropTable(
                name: "cs_degree");

            migrationBuilder.DropTable(
                name: "cs_post");
        }
    }
}
