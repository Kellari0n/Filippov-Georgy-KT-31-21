using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filippov_Georgy_KT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherForTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivanov.aleksey@university.com", new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-123-4567" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1975, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "smirnova.elena@university.com", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-987-6543" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthdate", "DegreeId", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "kuznetsov.dmitriy@university.com", new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-222-3344" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Birthdate", "DegreeId", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1990, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "petrova.maria@university.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-555-6677" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "vorobyev.sergey@university.com", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-333-4455" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1988, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "fedorova.olga@university.com", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-111-2233" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1970, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "sidorov.andrey@university.com", new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-444-5566" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Birthdate", "Email", "EmploymentDate", "Phone" },
                values: new object[] { new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikolaeva.lyudmila@university.com", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+7-900-777-8899" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                column: "DegreeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                column: "DegreeId",
                value: 1);
        }
    }
}
