using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filippov_Georgy_KT_31_21.DepartmentService.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cs_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    c_name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    f_head_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_department_department_id", x => x.department_id);
                });

            migrationBuilder.InsertData(
                table: "cs_department",
                columns: new[] { "department_id", "FoundationDate", "f_head_id", "c_name" },
                values: new object[,]
                {
                    { 1, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Кафедра математики" },
                    { 2, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Кафедра физики" },
                    { 3, new DateTime(1950, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Кафедра информатики" },
                    { 4, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Кафедра философии" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cs_department");
        }
    }
}
