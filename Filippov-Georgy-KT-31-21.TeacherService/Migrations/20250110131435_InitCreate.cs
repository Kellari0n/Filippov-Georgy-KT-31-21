using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filippov_Georgy_KT_31_21.TeacherService.Migrations
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
                    degree_id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cs_post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_post_post_id", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_second_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    c_first_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    c_last_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    d_birthdate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    d_employment = table.Column<DateTime>(type: "timestamp", nullable: false),
                    c_email = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    c_phone = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    f_degree_id = table.Column<int>(type: "int4", nullable: true),
                    f_post_id = table.Column<int>(type: "int4", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
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
                columns: new[] { "teacher_id", "d_birthdate", "f_degree_id", "DepartmentId", "c_email", "d_employment", "c_first_name", "c_last_name", "c_phone", "f_post_id", "c_second_name" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "ivanov.aleksey@university.com", new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", "Петрович", "+7-900-123-4567", 3, "Иванов" },
                    { 2, new DateTime(1975, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "smirnova.elena@university.com", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Елена", "Васильевна", "+7-900-987-6543", 4, "Смирнова" },
                    { 3, new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "kuznetsov.dmitriy@university.com", new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитрий", "Иванович", "+7-900-222-3344", 2, "Кузнецов" },
                    { 4, new DateTime(1990, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "petrova.maria@university.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мария", "Андреевна", "+7-900-555-6677", 1, "Петрова" },
                    { 5, new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "vorobyev.sergey@university.com", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", "Николаевич", "+7-900-333-4455", 2, "Воробьёв" },
                    { 6, new DateTime(1988, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "fedorova.olga@university.com", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ольга", "Сергеевна", "+7-900-111-2233", 1, "Фёдорова" },
                    { 7, new DateTime(1970, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "sidorov.andrey@university.com", new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрей", "Владимирович", "+7-900-444-5566", 4, "Сидоров" },
                    { 8, new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "nikolaeva.lyudmila@university.com", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Людмила", "Александровна", "+7-900-777-8899", 5, "Николаева" }
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_degree_id",
                table: "cd_teachers",
                column: "f_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_post_id",
                table: "cd_teachers",
                column: "f_post_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_teachers");

            migrationBuilder.DropTable(
                name: "cs_degree");

            migrationBuilder.DropTable(
                name: "cs_post");
        }
    }
}
